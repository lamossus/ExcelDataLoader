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
			this.load_excel_button = new System.Windows.Forms.Button();
			this.excel_file_name = new System.Windows.Forms.Label();
			this.table_combo_box = new System.Windows.Forms.ComboBox();
			this.upload_button = new System.Windows.Forms.Button();
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
			// excel_file_name
			// 
			this.excel_file_name.Location = new System.Drawing.Point(115, 16);
			this.excel_file_name.Name = "excel_file_name";
			this.excel_file_name.Size = new System.Drawing.Size(314, 15);
			this.excel_file_name.TabIndex = 1;
			// 
			// table_combo_box
			// 
			this.table_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.table_combo_box.FormattingEnabled = true;
			this.table_combo_box.Items.AddRange(new object[] {
            "fond_debts",
            "fond_not_boo"});
			this.table_combo_box.Location = new System.Drawing.Point(12, 41);
			this.table_combo_box.Name = "table_combo_box";
			this.table_combo_box.Size = new System.Drawing.Size(417, 23);
			this.table_combo_box.TabIndex = 2;
			// 
			// upload_button
			// 
			this.upload_button.Location = new System.Drawing.Point(359, 272);
			this.upload_button.Name = "upload_button";
			this.upload_button.Size = new System.Drawing.Size(70, 68);
			this.upload_button.TabIndex = 3;
			this.upload_button.Text = "Загрузить данные";
			this.upload_button.UseVisualStyleBackColor = true;
			this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 352);
			this.Controls.Add(this.upload_button);
			this.Controls.Add(this.table_combo_box);
			this.Controls.Add(this.excel_file_name);
			this.Controls.Add(this.load_excel_button);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private Button load_excel_button;
		private Label excel_file_name;
		private ComboBox table_combo_box;
		private Button upload_button;
	}
}