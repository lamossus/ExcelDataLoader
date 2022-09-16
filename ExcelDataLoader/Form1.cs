using ExcelDataReader;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace ExcelDataLoader
{
	public partial class Form1 : Form
	{
		private const string CON_STRING = "Server=localhost;Database=fns";
		private const int BATCH_SIZE = 25000;

		private string _excelPath = "";

		private Dictionary<string, int> _mapping = new Dictionary<string, int>() { { "id", 0 }, { "ogrn", 1 }, { "inn", 2 }, { "name", 3 } };
		private List<ComboBox> _mappingBoxes = new List<ComboBox>();

		public Form1()
		{
			InitializeComponent();

			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			_mappingBoxes.Add(map_column1);
			_mappingBoxes.Add(map_column2);
			_mappingBoxes.Add(map_column3);
			_mappingBoxes.Add(map_column4);

			for (int i = 0; i < _mappingBoxes.Count; i++)
				_mappingBoxes[i].SelectedIndex = i;
		}

		private void load_excel_button_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "C:\\";
				openFileDialog.Filter = "Excel files|*.xlsx;*.xls";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					_excelPath = openFileDialog.FileName;
					excel_filename.Text = openFileDialog.SafeFileName;
				}
				else
					return;
			}

			excel_preview.DataSource = GetExcelPreview(_excelPath, 4, 4, (int)skip_rows_numeric.Value);
		}

		private void upload_button_Click(object sender, EventArgs e)
		{
			string tableName = table_combo_box.Text;

			StringBuilder protocolStringBuiler = new StringBuilder("Протокол:\n");

			protocolStringBuiler.AppendLine($"Таблица-преемник: {tableName}");
			
			using (var con = new MySqlConnection(CON_STRING))
			{
				protocolStringBuiler.AppendLine($"Количество записей до очистки: {GetRowCount(tableName, con)}");
				protocolStringBuiler.AppendLine($"Имя загружаемого файла: {Path.GetFileName(_excelPath)}");
				DataTable dt = GetExcelData(_excelPath, (int)skip_rows_numeric.Value);
				BulkInsert(dt, table_combo_box.Text, con, clear_table_chechBox.Checked);
				protocolStringBuiler.AppendLine($"Количество записей после загрузки: {GetRowCount(tableName, con)}");
			}

			protocol_text.Text = protocolStringBuiler.ToString();
		}
		private DataTable GetExcelData(string excelFilePath, int skipRows = 0)
		{
			DataSet ds = new DataSet();

			using (var stream = File.Open(_excelPath, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					ds = reader.AsDataSet(new ExcelDataSetConfiguration()
					{
						ConfigureDataTable = _ => new ExcelDataTableConfiguration()
						{
							UseHeaderRow = false,
							FilterRow = rowReader => rowReader.Depth >= skipRows
						}
					});
				}
			}

			while (ds.Tables.Count > 1)
			{
				DataTable dt = ds.Tables[1];
				ds.Tables[0].Merge(dt);
				ds.Tables.Remove(dt);
			}

			return ds.Tables[0];
		}
		private DataTable GetExcelPreview(string excelFilePath, int columnCount, int rowCount, int skipRows = 0)
		{
			DataTable dt = new DataTable();

			for (int i = 0; i < columnCount; i++)
				dt.Columns.Add();

			using (var stream = File.Open(_excelPath, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					while(skipRows > 0)
					{
						reader.Read();
						skipRows--;
					}

					for (int i = 0; i < rowCount; i++)
					{
						bool end = reader.Read();
						if (!end)
							break;
						DataRow row = dt.NewRow();
						for (int j = 0; j < columnCount; j++)
						{
							object data = reader.GetValue(j);
							row[j] = data?.ToString();
						}
						dt.Rows.Add(row);
					}
				}
			}

			return dt;
		}
		private void BulkInsert(DataTable dataTable, string tableName, MySqlConnection con, bool clearTable = true)
		{
			StringBuilder comString = new StringBuilder($"INSERT INTO {tableName} VALUES ");

			con.Open();
			using (var tran = con.BeginTransaction(IsolationLevel.Serializable))
			{
				if (clearTable)
				{
					using (var com = new MySqlCommand($"TRUNCATE TABLE {tableName};", con))
					{
						com.CommandType = CommandType.Text;
						com.ExecuteNonQuery();
					}
				}

				int currentBatchSize = 0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow row = dataTable.Rows[i];

					currentBatchSize++;

					int id = Convert.ToInt32(row[_mapping["id"]]);
					string ogrn = row[_mapping["ogrn"]].ToString();
					string inn = row[_mapping["inn"]].ToString();
					string name = MySqlHelper.EscapeString(row[_mapping["name"]].ToString());

					comString.Append($"({id},'{ogrn}','{inn}','{name}')");

					if (currentBatchSize == BATCH_SIZE || i == dataTable.Rows.Count - 1)
					{
						comString.Append(';');

						using (var com = new MySqlCommand(comString.ToString(), con))
						{
							com.CommandType = CommandType.Text;
							com.Transaction = tran;
							com.ExecuteNonQuery();
						}

						currentBatchSize = 0;
						comString = new StringBuilder($"INSERT INTO {tableName} VALUES ");
					}
					else
						comString.Append(',');
				}

				tran.Commit();
			}
			con.Close();
		}
		private int GetRowCount(string tableName, MySqlConnection con)
		{
			int rows = 0;
			con.Open();
			using (MySqlCommand com = new MySqlCommand($"SELECT COUNT(1) FROM {tableName};", con))
			{
				com.CommandType = CommandType.Text;
				rows = Convert.ToInt32(com.ExecuteScalar());
			}
			con.Close();
			return rows;
		}
		private void MappingChanged(object sender, EventArgs e)
		{
			ComboBox changedBox = (ComboBox)sender;

			_mapping[changedBox.Text] = Convert.ToInt32(changedBox.Tag);

			List<int> possibleValues = Enumerable.Range(0, _mappingBoxes.Count).ToList();
			foreach (var box in _mappingBoxes)
				possibleValues.Remove(box.SelectedIndex);

			if (possibleValues.Count == 0)
				return;

			foreach (var box in _mappingBoxes)
			{
				if (box != changedBox && box.SelectedIndex == changedBox.SelectedIndex)
				{
					box.SelectedIndex = possibleValues[0];
					break;
				}
			}
		}
		private void skip_rows_numeric_ValueChanged(object sender, EventArgs e)
		{
			var numeric = (NumericUpDown)sender;

			if (numeric.Value < 0)
			{
				numeric.Value = 0;
				return;
			}

			if ((numeric.Value % 1) != 0)
			{
				numeric.Value = (int)numeric.Value;
				return;
			}

			if (_excelPath != "")
				excel_preview.DataSource = GetExcelPreview(_excelPath, 4, 4, (int)skip_rows_numeric.Value);
		}
	}
}