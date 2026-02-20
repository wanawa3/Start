namespace Start
{
    partial class ReportsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.dgvReport1 = new System.Windows.Forms.DataGridView();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.dtpTo1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvReport2 = new System.Windows.Forms.DataGridView();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.dtpTo2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbChild = new System.Windows.Forms.ComboBox();
            this.dtpTo3 = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom3 = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate3 = new System.Windows.Forms.Button();
            this.dgvReport3 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReports);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.dgvReport1);
            this.tabReports.Controls.Add(this.btnGenerate1);
            this.tabReports.Controls.Add(this.dtpTo1);
            this.tabReports.Controls.Add(this.label2);
            this.tabReports.Controls.Add(this.dtpFrom1);
            this.tabReports.Controls.Add(this.label1);
            this.tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(792, 424);
            this.tabReports.TabIndex = 0;
            this.tabReports.Text = "Отчет прогульщиков";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // dgvReport1
            // 
            this.dgvReport1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReport1.Location = new System.Drawing.Point(3, 128);
            this.dgvReport1.Name = "dgvReport1";
            this.dgvReport1.Size = new System.Drawing.Size(786, 293);
            this.dgvReport1.TabIndex = 5;
            // 
            // btnGenerate1
            // 
            this.btnGenerate1.Location = new System.Drawing.Point(31, 72);
            this.btnGenerate1.Name = "btnGenerate1";
            this.btnGenerate1.Size = new System.Drawing.Size(93, 31);
            this.btnGenerate1.TabIndex = 4;
            this.btnGenerate1.Text = "Найти";
            this.btnGenerate1.UseVisualStyleBackColor = true;
            this.btnGenerate1.Click += new System.EventHandler(this.btnGenerate1_Click_1);
            // 
            // dtpTo1
            // 
            this.dtpTo1.Location = new System.Drawing.Point(401, 24);
            this.dtpTo1.Name = "dtpTo1";
            this.dtpTo1.Size = new System.Drawing.Size(200, 20);
            this.dtpTo1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по какое";
            // 
            // dtpFrom1
            // 
            this.dtpFrom1.Location = new System.Drawing.Point(118, 24);
            this.dtpFrom1.Name = "dtpFrom1";
            this.dtpFrom1.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "С какого числа";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvReport2);
            this.tabPage2.Controls.Add(this.btnGenerate2);
            this.tabPage2.Controls.Add(this.dtpTo2);
            this.tabPage2.Controls.Add(this.dtpFrom2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Статистика по тренерам";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvReport2
            // 
            this.dgvReport2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReport2.Location = new System.Drawing.Point(3, 149);
            this.dgvReport2.Name = "dgvReport2";
            this.dgvReport2.Size = new System.Drawing.Size(786, 272);
            this.dgvReport2.TabIndex = 5;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.Location = new System.Drawing.Point(38, 88);
            this.btnGenerate2.Name = "btnGenerate2";
            this.btnGenerate2.Size = new System.Drawing.Size(92, 30);
            this.btnGenerate2.TabIndex = 4;
            this.btnGenerate2.Text = "Найти";
            this.btnGenerate2.UseVisualStyleBackColor = true;
            this.btnGenerate2.Click += new System.EventHandler(this.btnGenerate2_Click_1);
            // 
            // dtpTo2
            // 
            this.dtpTo2.Location = new System.Drawing.Point(399, 35);
            this.dtpTo2.Name = "dtpTo2";
            this.dtpTo2.Size = new System.Drawing.Size(200, 20);
            this.dtpTo2.TabIndex = 3;
            // 
            // dtpFrom2
            // 
            this.dtpFrom2.Location = new System.Drawing.Point(111, 35);
            this.dtpFrom2.Name = "dtpFrom2";
            this.dtpFrom2.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "по какое";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "С какого числа";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbChild);
            this.tabPage1.Controls.Add(this.dtpTo3);
            this.tabPage1.Controls.Add(this.dtpFrom3);
            this.tabPage1.Controls.Add(this.btnGenerate3);
            this.tabPage1.Controls.Add(this.dgvReport3);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Активность ребенка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbChild
            // 
            this.cmbChild.FormattingEnabled = true;
            this.cmbChild.Location = new System.Drawing.Point(97, 23);
            this.cmbChild.Name = "cmbChild";
            this.cmbChild.Size = new System.Drawing.Size(182, 21);
            this.cmbChild.TabIndex = 7;
            // 
            // dtpTo3
            // 
            this.dtpTo3.Location = new System.Drawing.Point(448, 58);
            this.dtpTo3.Name = "dtpTo3";
            this.dtpTo3.Size = new System.Drawing.Size(200, 20);
            this.dtpTo3.TabIndex = 6;
            // 
            // dtpFrom3
            // 
            this.dtpFrom3.Location = new System.Drawing.Point(131, 58);
            this.dtpFrom3.Name = "dtpFrom3";
            this.dtpFrom3.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom3.TabIndex = 5;
            // 
            // btnGenerate3
            // 
            this.btnGenerate3.Location = new System.Drawing.Point(44, 112);
            this.btnGenerate3.Name = "btnGenerate3";
            this.btnGenerate3.Size = new System.Drawing.Size(122, 30);
            this.btnGenerate3.TabIndex = 4;
            this.btnGenerate3.Text = "Найти";
            this.btnGenerate3.UseVisualStyleBackColor = true;
            this.btnGenerate3.Click += new System.EventHandler(this.btnGenerate3_Click_1);
            // 
            // dgvReport3
            // 
            this.dgvReport3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReport3.Location = new System.Drawing.Point(3, 160);
            this.dgvReport3.Name = "dgvReport3";
            this.dgvReport3.Size = new System.Drawing.Size(786, 261);
            this.dgvReport3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "по какое";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "С какого числа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ребёнок";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.tabControl1.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvReport1;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.DateTimePicker dtpTo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReport2;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.DateTimePicker dtpTo2;
        private System.Windows.Forms.DateTimePicker dtpFrom2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbChild;
        private System.Windows.Forms.DateTimePicker dtpTo3;
        private System.Windows.Forms.DateTimePicker dtpFrom3;
        private System.Windows.Forms.Button btnGenerate3;
        private System.Windows.Forms.DataGridView dgvReport3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}