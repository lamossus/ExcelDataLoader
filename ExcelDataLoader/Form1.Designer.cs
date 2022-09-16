namespace ExcelDataLoader
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.load_excel_button = new System.Windows.Forms.Button();
			this.table_combo_box = new System.Windows.Forms.ComboBox();
			this.upload_button = new System.Windows.Forms.Button();
			this.excel_preview = new System.Windows.Forms.DataGridView();
			this.map_column1 = new System.Windows.Forms.ComboBox();
			this.map_column2 = new System.Windows.Forms.ComboBox();
			this.map_column3 = new System.Windows.Forms.ComboBox();
			this.map_column4 = new System.Windows.Forms.ComboBox();
			this.excel_filename = new System.Windows.Forms.TextBox();
			this.protocol_text = new System.Windows.Forms.TextBox();
			this.db_table_label = new System.Windows.Forms.Label();
			this.clear_table_chechBox = new System.Windows.Forms.CheckBox();
			this.skip_rows_numeric = new System.Windows.Forms.NumericUpDown();
			this.skip_rows_label = new System.Windows.Forms.Label();
			this.login_label = new System.Windows.Forms.Label();
			this.login_textBox = new System.Windows.Forms.TextBox();
			this.password_label = new System.Windows.Forms.Label();
			this.password_textBox = new System.Windows.Forms.TextBox();
			this.db_label = new System.Windows.Forms.Label();
			this.db_name_textBox = new System.Windows.Forms.TextBox();
			this.server_label = new System.Windows.Forms.Label();
			this.server_textBox = new System.Windows.Forms.TextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.excel_preview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.skip_rows_numeric)).BeginInit();
			this.SuspendLayout();
			// 
			// load_excel_button
			// 
			this.load_excel_button.Location = new System.Drawing.Point(12, 12);
			this.load_excel_button.Name = "load_excel_button";
			this.load_excel_button.Size = new System.Drawing.Size(97, 23);
			this.load_excel_button.TabIndex = 0;
			this.load_excel_button.Text = "Выбрать файл";
			this.load_excel_button.UseVisualStyleBackColor = true;
			this.load_excel_button.Click += new System.EventHandler(this.load_excel_button_Click);
			// 
			// table_combo_box
			// 
			this.table_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.table_combo_box.FormattingEnabled = true;
			this.table_combo_box.Items.AddRange(new object[] {
            "fond_debts",
            "fond_not_boo"});
			this.table_combo_box.Location = new System.Drawing.Point(115, 41);
			this.table_combo_box.Name = "table_combo_box";
			this.table_combo_box.Size = new System.Drawing.Size(179, 23);
			this.table_combo_box.TabIndex = 2;
			// 
			// upload_button
			// 
			this.upload_button.Location = new System.Drawing.Point(12, 357);
			this.upload_button.Name = "upload_button";
			this.upload_button.Size = new System.Drawing.Size(438, 25);
			this.upload_button.TabIndex = 3;
			this.upload_button.Text = "Загрузить данные";
			this.upload_button.UseVisualStyleBackColor = true;
			this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
			// 
			// excel_preview
			// 
			this.excel_preview.AllowUserToAddRows = false;
			this.excel_preview.AllowUserToDeleteRows = false;
			this.excel_preview.AllowUserToResizeColumns = false;
			this.excel_preview.AllowUserToResizeRows = false;
			this.excel_preview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.excel_preview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.excel_preview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.excel_preview.ColumnHeadersVisible = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.excel_preview.DefaultCellStyle = dataGridViewCellStyle2;
			this.excel_preview.Location = new System.Drawing.Point(12, 99);
			this.excel_preview.MultiSelect = false;
			this.excel_preview.Name = "excel_preview";
			this.excel_preview.ReadOnly = true;
			this.excel_preview.RowHeadersVisible = false;
			this.excel_preview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.excel_preview.RowTemplate.Height = 25;
			this.excel_preview.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.excel_preview.Size = new System.Drawing.Size(438, 101);
			this.excel_preview.TabIndex = 5;
			// 
			// map_column1
			// 
			this.map_column1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.map_column1.FormattingEnabled = true;
			this.map_column1.Items.AddRange(new object[] {
            "id",
            "ogrn",
            "inn",
            "name"});
			this.map_column1.Location = new System.Drawing.Point(12, 70);
			this.map_column1.Name = "map_column1";
			this.map_column1.Size = new System.Drawing.Size(105, 23);
			this.map_column1.TabIndex = 6;
			this.map_column1.Tag = "0";
			this.map_column1.SelectedIndexChanged += new System.EventHandler(this.MappingChanged);
			// 
			// map_column2
			// 
			this.map_column2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.map_column2.FormattingEnabled = true;
			this.map_column2.Items.AddRange(new object[] {
            "id",
            "ogrn",
            "inn",
            "name"});
			this.map_column2.Location = new System.Drawing.Point(123, 70);
			this.map_column2.Name = "map_column2";
			this.map_column2.Size = new System.Drawing.Size(105, 23);
			this.map_column2.TabIndex = 7;
			this.map_column2.Tag = "1";
			this.map_column2.SelectedIndexChanged += new System.EventHandler(this.MappingChanged);
			// 
			// map_column3
			// 
			this.map_column3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.map_column3.FormattingEnabled = true;
			this.map_column3.Items.AddRange(new object[] {
            "id",
            "ogrn",
            "inn",
            "name"});
			this.map_column3.Location = new System.Drawing.Point(234, 70);
			this.map_column3.Name = "map_column3";
			this.map_column3.Size = new System.Drawing.Size(105, 23);
			this.map_column3.TabIndex = 8;
			this.map_column3.Tag = "2";
			this.map_column3.SelectedIndexChanged += new System.EventHandler(this.MappingChanged);
			// 
			// map_column4
			// 
			this.map_column4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.map_column4.FormattingEnabled = true;
			this.map_column4.Items.AddRange(new object[] {
            "id",
            "ogrn",
            "inn",
            "name"});
			this.map_column4.Location = new System.Drawing.Point(345, 70);
			this.map_column4.Name = "map_column4";
			this.map_column4.Size = new System.Drawing.Size(105, 23);
			this.map_column4.TabIndex = 9;
			this.map_column4.Tag = "3";
			this.map_column4.SelectedIndexChanged += new System.EventHandler(this.MappingChanged);
			// 
			// excel_filename
			// 
			this.excel_filename.Location = new System.Drawing.Point(115, 12);
			this.excel_filename.Name = "excel_filename";
			this.excel_filename.ReadOnly = true;
			this.excel_filename.Size = new System.Drawing.Size(179, 23);
			this.excel_filename.TabIndex = 10;
			// 
			// protocol_text
			// 
			this.protocol_text.Location = new System.Drawing.Point(12, 206);
			this.protocol_text.Multiline = true;
			this.protocol_text.Name = "protocol_text";
			this.protocol_text.ReadOnly = true;
			this.protocol_text.Size = new System.Drawing.Size(438, 87);
			this.protocol_text.TabIndex = 11;
			// 
			// db_table_label
			// 
			this.db_table_label.AutoSize = true;
			this.db_table_label.Location = new System.Drawing.Point(12, 44);
			this.db_table_label.Name = "db_table_label";
			this.db_table_label.Size = new System.Drawing.Size(75, 15);
			this.db_table_label.TabIndex = 12;
			this.db_table_label.Text = "Таблица БД:";
			// 
			// clear_table_chechBox
			// 
			this.clear_table_chechBox.AutoSize = true;
			this.clear_table_chechBox.Checked = true;
			this.clear_table_chechBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clear_table_chechBox.Location = new System.Drawing.Point(300, 15);
			this.clear_table_chechBox.Name = "clear_table_chechBox";
			this.clear_table_chechBox.Size = new System.Drawing.Size(123, 19);
			this.clear_table_chechBox.TabIndex = 13;
			this.clear_table_chechBox.Text = "Очистка таблицы";
			this.clear_table_chechBox.UseVisualStyleBackColor = true;
			// 
			// skip_rows_numeric
			// 
			this.skip_rows_numeric.Location = new System.Drawing.Point(415, 41);
			this.skip_rows_numeric.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.skip_rows_numeric.Name = "skip_rows_numeric";
			this.skip_rows_numeric.Size = new System.Drawing.Size(35, 23);
			this.skip_rows_numeric.TabIndex = 14;
			this.skip_rows_numeric.ValueChanged += new System.EventHandler(this.skip_rows_numeric_ValueChanged);
			// 
			// skip_rows_label
			// 
			this.skip_rows_label.AutoSize = true;
			this.skip_rows_label.Location = new System.Drawing.Point(300, 44);
			this.skip_rows_label.Name = "skip_rows_label";
			this.skip_rows_label.Size = new System.Drawing.Size(109, 15);
			this.skip_rows_label.TabIndex = 15;
			this.skip_rows_label.Text = "Пропустить строк:";
			// 
			// login_label
			// 
			this.login_label.AutoSize = true;
			this.login_label.Location = new System.Drawing.Point(12, 302);
			this.login_label.Name = "login_label";
			this.login_label.Size = new System.Drawing.Size(44, 15);
			this.login_label.TabIndex = 16;
			this.login_label.Text = "Логин:";
			// 
			// login_textBox
			// 
			this.login_textBox.Location = new System.Drawing.Point(75, 299);
			this.login_textBox.Name = "login_textBox";
			this.login_textBox.Size = new System.Drawing.Size(153, 23);
			this.login_textBox.TabIndex = 17;
			// 
			// password_label
			// 
			this.password_label.AutoSize = true;
			this.password_label.Location = new System.Drawing.Point(12, 331);
			this.password_label.Name = "password_label";
			this.password_label.Size = new System.Drawing.Size(52, 15);
			this.password_label.TabIndex = 18;
			this.password_label.Text = "Пароль:";
			// 
			// password_textBox
			// 
			this.password_textBox.Location = new System.Drawing.Point(75, 328);
			this.password_textBox.Name = "password_textBox";
			this.password_textBox.PasswordChar = '*';
			this.password_textBox.Size = new System.Drawing.Size(153, 23);
			this.password_textBox.TabIndex = 19;
			// 
			// db_label
			// 
			this.db_label.AutoSize = true;
			this.db_label.Location = new System.Drawing.Point(234, 302);
			this.db_label.Name = "db_label";
			this.db_label.Size = new System.Drawing.Size(25, 15);
			this.db_label.TabIndex = 20;
			this.db_label.Text = "БД:";
			// 
			// db_name_textBox
			// 
			this.db_name_textBox.Location = new System.Drawing.Point(297, 297);
			this.db_name_textBox.Name = "db_name_textBox";
			this.db_name_textBox.Size = new System.Drawing.Size(153, 23);
			this.db_name_textBox.TabIndex = 21;
			// 
			// server_label
			// 
			this.server_label.AutoSize = true;
			this.server_label.Location = new System.Drawing.Point(234, 331);
			this.server_label.Name = "server_label";
			this.server_label.Size = new System.Drawing.Size(50, 15);
			this.server_label.TabIndex = 22;
			this.server_label.Text = "Сервер:";
			// 
			// server_textBox
			// 
			this.server_textBox.Location = new System.Drawing.Point(297, 326);
			this.server_textBox.Name = "server_textBox";
			this.server_textBox.Size = new System.Drawing.Size(153, 23);
			this.server_textBox.TabIndex = 23;
			this.server_textBox.Text = "localhost";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 390);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(438, 23);
			this.progressBar.TabIndex = 24;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 425);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.server_textBox);
			this.Controls.Add(this.server_label);
			this.Controls.Add(this.db_name_textBox);
			this.Controls.Add(this.db_label);
			this.Controls.Add(this.password_textBox);
			this.Controls.Add(this.password_label);
			this.Controls.Add(this.login_textBox);
			this.Controls.Add(this.login_label);
			this.Controls.Add(this.skip_rows_label);
			this.Controls.Add(this.skip_rows_numeric);
			this.Controls.Add(this.clear_table_chechBox);
			this.Controls.Add(this.db_table_label);
			this.Controls.Add(this.protocol_text);
			this.Controls.Add(this.excel_filename);
			this.Controls.Add(this.map_column4);
			this.Controls.Add(this.map_column3);
			this.Controls.Add(this.map_column2);
			this.Controls.Add(this.map_column1);
			this.Controls.Add(this.excel_preview);
			this.Controls.Add(this.upload_button);
			this.Controls.Add(this.table_combo_box);
			this.Controls.Add(this.load_excel_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Загрузчик";
			((System.ComponentModel.ISupportInitialize)(this.excel_preview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.skip_rows_numeric)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button load_excel_button;
		private ComboBox table_combo_box;
		private Button upload_button;
		private DataGridView excel_preview;
		private ComboBox map_column1;
		private ComboBox map_column2;
		private ComboBox map_column3;
		private ComboBox map_column4;
		private TextBox excel_filename;
		private TextBox protocol_text;
		private Label db_table_label;
		private CheckBox clear_table_chechBox;
		private NumericUpDown skip_rows_numeric;
		private Label skip_rows_label;
		private Label login_label;
		private TextBox login_textBox;
		private Label password_label;
		private TextBox password_textBox;
		private Label db_label;
		private TextBox db_name_textBox;
		private Label server_label;
		private TextBox server_textBox;
		private ProgressBar progressBar;
	}
}