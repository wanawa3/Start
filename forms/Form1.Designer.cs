namespace Start
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSportsmen = new System.Windows.Forms.Button();
            this.btnCoaches = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSportsmen
            // 
            this.btnSportsmen.Location = new System.Drawing.Point(132, 92);
            this.btnSportsmen.Name = "btnSportsmen";
            this.btnSportsmen.Size = new System.Drawing.Size(194, 42);
            this.btnSportsmen.TabIndex = 0;
            this.btnSportsmen.Text = "Спортсмены";
            this.btnSportsmen.UseVisualStyleBackColor = true;
            this.btnSportsmen.Click += new System.EventHandler(this.btnSportsmen_Click_1);
            // 
            // btnCoaches
            // 
            this.btnCoaches.Location = new System.Drawing.Point(438, 92);
            this.btnCoaches.Name = "btnCoaches";
            this.btnCoaches.Size = new System.Drawing.Size(194, 42);
            this.btnCoaches.TabIndex = 1;
            this.btnCoaches.Text = "Тренеры";
            this.btnCoaches.UseVisualStyleBackColor = true;
            this.btnCoaches.Click += new System.EventHandler(this.btnCoaches_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Location = new System.Drawing.Point(132, 263);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(194, 42);
            this.btnAttendance.TabIndex = 2;
            this.btnAttendance.Text = "Посещения";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(438, 263);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(194, 42);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Отчёты/Статистика";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.btnCoaches);
            this.Controls.Add(this.btnSportsmen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSportsmen;
        private System.Windows.Forms.Button btnCoaches;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnReports;
    }
}

