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

		public Form1()
		{
			InitializeComponent();

			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
					excel_file_name.Text = openFileDialog.SafeFileName;
				}
			}
		}

		private void upload_button_Click(object sender, EventArgs e)
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			DataTable dt = GetExcelData(_excelPath);
			Debug.Write(stopwatch.Elapsed.ToString() + '\n');
			stopwatch.Restart();
			BulkInsert(dt, table_combo_box.Text);
			Debug.Write(stopwatch.Elapsed);
		}

		private DataTable GetExcelData(string excelFilePath)
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
							UseHeaderRow = true,
							FilterRow = rowReader => rowReader.Depth > 2
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

		private void BulkInsert(DataTable dataTable, string tableName)
		{
			StringBuilder comString = new StringBuilder($"INSERT INTO {tableName} VALUES ");

			using (var con = new MySqlConnection(CON_STRING))
			{
				con.Open();
				using (var tran = con.BeginTransaction(IsolationLevel.Serializable))
				{
					using (var com = new MySqlCommand($"TRUNCATE TABLE {tableName};", con))
					{
						com.CommandType = CommandType.Text;
						com.ExecuteNonQuery();
					}

					int currentBatchSize = 0;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						DataRow row = dataTable.Rows[i];

						currentBatchSize++;
						comString.Append($"({Convert.ToInt32(row[0])},'{row[1]}','{row[2]}','{MySqlHelper.EscapeString(row[3].ToString())}')");

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
			}
		}
	}
}