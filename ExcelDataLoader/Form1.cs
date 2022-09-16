using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ExcelDataLoader
{
	public partial class Form1 : Form
	{
		private const string CON_STRING = "Server={0};uid={1};pwd={2};Database={3};";

		private string _excelPath = "";

		private Dictionary<string, int> _mapping = new Dictionary<string, int>() { { "id", 0 }, { "ogrn", 1 }, { "inn", 2 }, { "name", 3 } };
		private List<ComboBox> _mappingBoxes = new List<ComboBox>();

		private DataTable _cachedPreview = new DataTable();
		private int _cachedStartIndex = 0;
		private const int FORWARD_CACHE_COUNT = 50;
		private const int BACKWARD_CACHE_COUNT = 50;

		private SqlLoader _sqlLoader;
		private ExcelLoader _excelLoader;

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

			_sqlLoader = new SqlLoader();
			_excelLoader = new ExcelLoader();
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

			UpdatePreview();
		}
		private void upload_button_Click(object sender, EventArgs e)
		{
			string tableName = table_combo_box.Text;

			if (tableName == "")
			{
				protocol_text.Text = "Укажите таблицу БД.";
				return;
			}
			if (_excelPath == "")
			{
				protocol_text.Text = "Выберите файл Excel для загрузки.";
				return;
			}

			string server = server_textBox.Text;
			if (server == "")
			{
				protocol_text.Text = "Введите адрес сервера БД.";
				return;
			}
			string login = login_textBox.Text;
			string password = password_textBox.Text;
			string database = db_name_textBox.Text;
			if (database == "")
			{
				protocol_text.Text = "Введите название БД.";
				return;
			}

			StringBuilder protocolStringBuiler = new StringBuilder("Протокол:");
			protocolStringBuiler.AppendLine();

			protocolStringBuiler.AppendLine($"Таблица-преемник: {tableName}");


			string conString = string.Format(CON_STRING, server, login, password, database);
			using (var con = new MySqlConnection(conString))
			{
				try
				{
					protocolStringBuiler.AppendLine($"Количество записей до очистки: {_sqlLoader.GetRowCount(tableName, con)}");
					protocolStringBuiler.AppendLine($"Имя загружаемого файла: {Path.GetFileName(_excelPath)}");
					DataTable dt;

					int progressMade = 0;
					EventHandler<double> progressBarUpdate = (s, e) => progressBar.Value = (int)(progressMade + e * 50);
					_excelLoader.OnProgress += progressBarUpdate;
					dt = _excelLoader.GetExcelData(_excelPath, (int)skip_rows_numeric.Value);
					_excelLoader.OnProgress -= progressBarUpdate;
					progressMade = 50;
					_sqlLoader.OnProgress += progressBarUpdate;
					_sqlLoader.BulkInsert(dt, table_combo_box.Text, con, _mapping, clear_table_chechBox.Checked);
					_sqlLoader.OnProgress -= progressBarUpdate;
					protocolStringBuiler.AppendLine($"Количество записей после загрузки: {_sqlLoader.GetRowCount(tableName, con)}");
				}
				catch (Exception exc)
				{
					protocol_text.Text = $"Ошибка: {exc.Message}";
					if (con.State == ConnectionState.Open)
						con.Close();
					return;
				}
			}

			protocol_text.Text = protocolStringBuiler.ToString();
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
				UpdatePreview(false);
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

		private DataTable GetPreview()
		{
			DataTable dt = new DataTable();
			for (int i = 0; i < 4; i++)
				dt.Columns.Add();
			int skipRows = (int)skip_rows_numeric.Value;

			if (_cachedStartIndex + _cachedPreview.Rows.Count - skipRows < 4 || _cachedStartIndex > skipRows)
				LoadNewPreview();

			for (int i = 0; i < 4; i++)
			{
				DataRow destRow = dt.NewRow();
				DataRow sourceRow = _cachedPreview.Rows[skipRows - _cachedStartIndex + i];
				destRow.ItemArray = (object[])sourceRow.ItemArray.Clone();
				dt.Rows.Add(destRow);
			}

			return dt;
		}
		private void UpdatePreview(bool newFile = true)
		{
			if (newFile)
				LoadNewPreview();

			DataTable preview = GetPreview();
			excel_preview.DataSource = preview;
		}
		private void LoadNewPreview()
		{
			int skipRows = (int)skip_rows_numeric.Value;

			int start = Math.Max(0, skipRows - BACKWARD_CACHE_COUNT);
			int length = skipRows + FORWARD_CACHE_COUNT - start;

			_cachedPreview = _excelLoader.GetExcelPreview(_excelPath, 4, length, start);

			_cachedStartIndex = start;
		}
	}
}