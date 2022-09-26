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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.load_excel_button = new System.Windows.Forms.Button();
			this.table_combo_box = new System.Windows.Forms.ComboBox();
			this.upload_button = new System.Windows.Forms.Button();
			this.excel_preview = new System.Windows.Forms.DataGridView();
			this.excel_filename = new System.Windows.Forms.TextBox();
			this.protocol_text = new System.Windows.Forms.TextBox();
			this.db_table_label = new System.Windows.Forms.Label();
			this.clear_table_chechBox = new System.Windows.Forms.CheckBox();
			this.skip_rows_numeric = new System.Windows.Forms.NumericUpDown();
			this.skip_rows_label = new System.Windows.Forms.Label();
			this.progressBar = new ExcelDataLoader.ColoredProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.reset_mapping_button = new System.Windows.Forms.Button();
			this.refresh_button = new System.Windows.Forms.Button();
			this.refreshTooltip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.excel_preview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.skip_rows_numeric)).BeginInit();
			this.panel1.SuspendLayout();
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
            "--выберите таблицу--"});
			this.table_combo_box.Location = new System.Drawing.Point(115, 41);
			this.table_combo_box.Name = "table_combo_box";
			this.table_combo_box.Size = new System.Drawing.Size(179, 23);
			this.table_combo_box.TabIndex = 2;
			this.table_combo_box.SelectedIndexChanged += new System.EventHandler(this.table_combo_box_SelectedIndexChanged);
			// 
			// upload_button
			// 
			this.upload_button.Location = new System.Drawing.Point(12, 339);
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
			this.excel_preview.Location = new System.Drawing.Point(0, 32);
			this.excel_preview.MultiSelect = false;
			this.excel_preview.Name = "excel_preview";
			this.excel_preview.ReadOnly = true;
			this.excel_preview.RowHeadersVisible = false;
			this.excel_preview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.excel_preview.RowTemplate.Height = 25;
			this.excel_preview.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.excel_preview.Size = new System.Drawing.Size(439, 101);
			this.excel_preview.TabIndex = 5;
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
			this.protocol_text.Location = new System.Drawing.Point(12, 227);
			this.protocol_text.Multiline = true;
			this.protocol_text.Name = "protocol_text";
			this.protocol_text.ReadOnly = true;
			this.protocol_text.Size = new System.Drawing.Size(438, 106);
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
			this.clear_table_chechBox.Checked = true;
			this.clear_table_chechBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clear_table_chechBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.clear_table_chechBox.Location = new System.Drawing.Point(300, 44);
			this.clear_table_chechBox.Name = "clear_table_chechBox";
			this.clear_table_chechBox.Size = new System.Drawing.Size(121, 19);
			this.clear_table_chechBox.TabIndex = 13;
			this.clear_table_chechBox.Text = "Очистка таблицы";
			this.clear_table_chechBox.UseVisualStyleBackColor = true;
			// 
			// skip_rows_numeric
			// 
			this.skip_rows_numeric.Location = new System.Drawing.Point(415, 13);
			this.skip_rows_numeric.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.skip_rows_numeric.Name = "skip_rows_numeric";
			this.skip_rows_numeric.Size = new System.Drawing.Size(35, 23);
			this.skip_rows_numeric.TabIndex = 14;
			this.skip_rows_numeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.skip_rows_numeric.ValueChanged += new System.EventHandler(this.skip_rows_numeric_ValueChanged);
			// 
			// skip_rows_label
			// 
			this.skip_rows_label.AutoSize = true;
			this.skip_rows_label.Location = new System.Drawing.Point(300, 16);
			this.skip_rows_label.Name = "skip_rows_label";
			this.skip_rows_label.Size = new System.Drawing.Size(109, 15);
			this.skip_rows_label.TabIndex = 15;
			this.skip_rows_label.Text = "Пропустить строк:";
			// 
			// progressBar
			// 
			this.progressBar.ForeColor = System.Drawing.Color.LimeGreen;
			this.progressBar.Location = new System.Drawing.Point(12, 370);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(438, 23);
			this.progressBar.TabIndex = 24;
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.excel_preview);
			this.panel1.Location = new System.Drawing.Point(11, 67);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(440, 155);
			this.panel1.TabIndex = 25;
			// 
			// reset_mapping_button
			// 
			this.reset_mapping_button.BackColor = System.Drawing.Color.Red;
			this.reset_mapping_button.Enabled = false;
			this.reset_mapping_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reset_mapping_button.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.reset_mapping_button.Location = new System.Drawing.Point(429, 42);
			this.reset_mapping_button.Name = "reset_mapping_button";
			this.reset_mapping_button.Size = new System.Drawing.Size(21, 23);
			this.reset_mapping_button.TabIndex = 27;
			this.reset_mapping_button.Text = "P";
			this.refreshTooltip.SetToolTip(this.reset_mapping_button, "Сбросить соответствия колонок");
			this.reset_mapping_button.UseVisualStyleBackColor = false;
			this.reset_mapping_button.Visible = false;
			this.reset_mapping_button.Click += new System.EventHandler(this.reset_mapping_button_Click);
			// 
			// refresh_button
			// 
			this.refresh_button.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.refresh_button.Location = new System.Drawing.Point(88, 41);
			this.refresh_button.Name = "refresh_button";
			this.refresh_button.Size = new System.Drawing.Size(21, 23);
			this.refresh_button.TabIndex = 26;
			this.refresh_button.Text = "P";
			this.refreshTooltip.SetToolTip(this.refresh_button, "Обновить список таблиц");
			this.refresh_button.UseVisualStyleBackColor = true;
			this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 404);
			this.Controls.Add(this.reset_mapping_button);
			this.Controls.Add(this.refresh_button);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.skip_rows_label);
			this.Controls.Add(this.skip_rows_numeric);
			this.Controls.Add(this.clear_table_chechBox);
			this.Controls.Add(this.db_table_label);
			this.Controls.Add(this.protocol_text);
			this.Controls.Add(this.excel_filename);
			this.Controls.Add(this.upload_button);
			this.Controls.Add(this.table_combo_box);
			this.Controls.Add(this.load_excel_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Загрузчик";
			((System.ComponentModel.ISupportInitialize)(this.excel_preview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.skip_rows_numeric)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button load_excel_button;
		private ComboBox table_combo_box;
		private Button upload_button;
		private DataGridView excel_preview;
		private TextBox excel_filename;
		private TextBox protocol_text;
		private Label db_table_label;
		private CheckBox clear_table_chechBox;
		private NumericUpDown skip_rows_numeric;
		private Label skip_rows_label;
		private ColoredProgressBar progressBar;
		private Panel panel1;
		private Button refresh_button;
		private ToolTip refreshTooltip;
		private Button reset_mapping_button;
	}
}