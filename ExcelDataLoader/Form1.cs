using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ExcelDataLoader
{
	public partial class Form1 : Form
	{
		private string _excelPath = "";

		private Dictionary<int, int> _mapping = new Dictionary<int, int>();
		private List<string> _columnNames = new List<string>();
		private int _columnCount = 0;

		private List<ComboBox> _mappingBoxes = new List<ComboBox>();

		private const string CON_STRING = "Server={0};uid={1};pwd={2};Database={3};";

		private DataTable _cachedPreview = new DataTable();
		private int _cachedStartIndex = 0;
		private const int FORWARD_CACHE_COUNT = 50;
		private const int BACKWARD_CACHE_COUNT = 50;

		private const int COLUMN_WIDTH = 110;

		private SqlLoader _sqlLoader;
		private ExcelLoader _excelLoader;

		public Form1()
		{
			InitializeComponent();

			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

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
		private void table_combo_box_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				using (var con = new MySqlConnection(GenerateConnectionString()))
					_columnNames = _sqlLoader.GetColumnNames(table_combo_box.Text, con);
				_columnCount = Math.Max(_columnNames.Count, _columnCount);
				UpdatePreview(false);
			}
			catch (Exception exc)
			{
				protocol_text.Text = exc.Message;
			}
		}
		private void upload_button_Click(object sender, EventArgs e)
		{
			progressBar.Value = 0;
			progressBar.ForeColor = Color.Green;
			progressBar.Refresh();

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

			string conString = "";

			try
			{
				conString = GenerateConnectionString();
			}
			catch (Exception exc)
			{
				protocol_text.Text = exc.Message;
				return;
			}

			protocol_text.Text = "Загрузка...";
			protocol_text.Refresh();

			StringBuilder protocolStringBuiler = new StringBuilder("Протокол:");
			protocolStringBuiler.AppendLine();

			protocolStringBuiler.AppendLine($"Таблица-преемник: {tableName}");
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
					protocolStringBuiler.AppendLine($"Количество загруженных листов: {_excelLoader.LastReadSheetCount}");
				}
				catch (Exception exc)
				{
					protocol_text.Text = $"Ошибка: {exc.Message}";
					if (con.State == ConnectionState.Open)
						con.Close();
					progressBar.ForeColor = Color.Red; 
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
		private void MappingChanged(object? sender, EventArgs e)
		{
			if (sender == null)
				return;

			ComboBox changedBox = (ComboBox)sender;

			if (changedBox.SelectedIndex == 0)
				return;

			_mapping[changedBox.SelectedIndex - 1] = Convert.ToInt32(changedBox.Tag);

			List<int> possibleValues = Enumerable.Range(1, _columnNames.Count).ToList();
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

		private void GenerateComboBoxes()
		{
			_mapping.Clear();
			foreach (ComboBox box in _mappingBoxes)
			{
				box.Dispose();
				panel1.Controls.Remove(box);
			}
			_mappingBoxes.Clear();

			for (int i = 0; i < _columnCount; i++)
			{
				ComboBox comboBox = new ComboBox();

				comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBox.FormattingEnabled = true;
				comboBox.Items.Add("--не загружать--");
				comboBox.Items.AddRange(_columnNames.ToArray());
				comboBox.Location = new Point(COLUMN_WIDTH * i, 3);
				comboBox.Name = "map_column3";
				comboBox.Size = new Size(COLUMN_WIDTH, 23);
				comboBox.Tag = i;
				comboBox.SelectedIndexChanged += new EventHandler(MappingChanged);

				if (i + 1 < comboBox.Items.Count)
					comboBox.SelectedIndex = i + 1;
				else
					comboBox.SelectedIndex = 0;

				_mappingBoxes.Add(comboBox);
				panel1.Controls.Add(comboBox);
			}
		}

		private string GenerateConnectionString()
		{
			string server = server_textBox.Text;
			if (server == "")
				throw new Exception("Введите адрес сервера БД.");

			string login = login_textBox.Text;
			string password = password_textBox.Text;
			string database = db_name_textBox.Text;
			if (database == "")
				throw new Exception("Введите название БД.");

			return string.Format(CON_STRING, server, login, password, database);
		}

		private void UpdatePreview(bool newFile = true)
		{
			if (_excelPath == "")
				return;

			if (_columnCount == 0)
			{
				excel_preview.Rows.Clear();
				excel_preview.Refresh();
				return;
			}

			if (newFile || _columnNames.Count > _columnCount)
				LoadNewPreview(_columnCount);

			GenerateComboBoxes();

			DataTable preview = GetPreview();
			excel_preview.DataSource = preview;
			excel_preview.Width = COLUMN_WIDTH * _columnCount;
		}
		private DataTable GetPreview()
		{
			DataTable dt = new DataTable();
			for (int i = 0; i < _columnCount; i++)
				dt.Columns.Add();
			int skipRows = (int)skip_rows_numeric.Value;

			if (_cachedStartIndex + _cachedPreview.Rows.Count - skipRows < 4 || _cachedStartIndex > skipRows)
				LoadNewPreview(_columnCount);

			for (int i = 0; i < 4; i++)
			{
				DataRow destRow = dt.NewRow();
				DataRow sourceRow = _cachedPreview.Rows[skipRows - _cachedStartIndex + i];
				destRow.ItemArray = (object[])sourceRow.ItemArray.Clone();
				dt.Rows.Add(destRow);
			}

			return dt;
		}
		private void LoadNewPreview(int columns)
		{
			int skipRows = (int)skip_rows_numeric.Value;

			int start = Math.Max(0, skipRows - BACKWARD_CACHE_COUNT);
			int length = skipRows + FORWARD_CACHE_COUNT - start;

			_cachedPreview = _excelLoader.GetExcelPreview(_excelPath, columns, length, start);

			_cachedStartIndex = start;
		}
	}
}