namespace SegundoParcial.UI.Consulta
{
    partial class cInscripcion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ConsultaDataGridView = new System.Windows.Forms.DataGridView();
            this.CriterioTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FiltroComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaDesdeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaHastaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.RangoFechaCheckBox = new System.Windows.Forms.CheckBox();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsultaDataGridView
            // 
            this.ConsultaDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConsultaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultaDataGridView.Location = new System.Drawing.Point(168, 15);
            this.ConsultaDataGridView.Name = "ConsultaDataGridView";
            this.ConsultaDataGridView.Size = new System.Drawing.Size(464, 238);
            this.ConsultaDataGridView.TabIndex = 46;
            // 
            // CriterioTextBox
            // 
            this.CriterioTextBox.Location = new System.Drawing.Point(56, 38);
            this.CriterioTextBox.Name = "CriterioTextBox";
            this.CriterioTextBox.Size = new System.Drawing.Size(105, 20);
            this.CriterioTextBox.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Criterio";
            // 
            // FiltroComboBox
            // 
            this.FiltroComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FiltroComboBox.FormattingEnabled = true;
            this.FiltroComboBox.Items.AddRange(new object[] {
            "InscripcionId",
            "Fecha",
            "EstudianteId",
            "Monto"});
            this.FiltroComboBox.Location = new System.Drawing.Point(56, 15);
            this.FiltroComboBox.Name = "FiltroComboBox";
            this.FiltroComboBox.Size = new System.Drawing.Size(105, 21);
            this.FiltroComboBox.TabIndex = 43;
            this.FiltroComboBox.SelectedIndexChanged += new System.EventHandler(this.FiltroComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Filtro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(21, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(21, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Desde";
            // 
            // FechaDesdeDateTimePicker
            // 
            this.FechaDesdeDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaDesdeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaDesdeDateTimePicker.Location = new System.Drawing.Point(56, 64);
            this.FechaDesdeDateTimePicker.Name = "FechaDesdeDateTimePicker";
            this.FechaDesdeDateTimePicker.Size = new System.Drawing.Size(105, 20);
            this.FechaDesdeDateTimePicker.TabIndex = 50;
            // 
            // FechaHastaDateTimePicker
            // 
            this.FechaHastaDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaHastaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaHastaDateTimePicker.Location = new System.Drawing.Point(56, 86);
            this.FechaHastaDateTimePicker.Name = "FechaHastaDateTimePicker";
            this.FechaHastaDateTimePicker.Size = new System.Drawing.Size(105, 20);
            this.FechaHastaDateTimePicker.TabIndex = 51;
            // 
            // RangoFechaCheckBox
            // 
            this.RangoFechaCheckBox.AutoSize = true;
            this.RangoFechaCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RangoFechaCheckBox.Location = new System.Drawing.Point(56, 112);
            this.RangoFechaCheckBox.Name = "RangoFechaCheckBox";
            this.RangoFechaCheckBox.Size = new System.Drawing.Size(106, 17);
            this.RangoFechaCheckBox.TabIndex = 52;
            this.RangoFechaCheckBox.Text = "Rango de Fecha";
            this.RangoFechaCheckBox.UseVisualStyleBackColor = true;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.BackColor = System.Drawing.Color.White;
            this.Buscarbutton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Buscarbutton.Image = global::SegundoParcial.Properties.Resources.search_12841;
            this.Buscarbutton.Location = new System.Drawing.Point(101, 135);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(60, 41);
            this.Buscarbutton.TabIndex = 47;
            this.Buscarbutton.UseVisualStyleBackColor = false;
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // cInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(655, 269);
            this.Controls.Add(this.RangoFechaCheckBox);
            this.Controls.Add(this.FechaHastaDateTimePicker);
            this.Controls.Add(this.FechaDesdeDateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.ConsultaDataGridView);
            this.Controls.Add(this.CriterioTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FiltroComboBox);
            this.Controls.Add(this.label1);
            this.Name = "cInscripcion";
            this.Text = "Consulta de Inscripcion";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.DataGridView ConsultaDataGridView;
        private System.Windows.Forms.TextBox CriterioTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FiltroComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FechaDesdeDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaHastaDateTimePicker;
        private System.Windows.Forms.CheckBox RangoFechaCheckBox;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
    }
}