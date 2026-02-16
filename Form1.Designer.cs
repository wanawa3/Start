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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(438, 263);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCoaches);
            this.Controls.Add(this.btnSportsmen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSportsmen;
        private System.Windows.Forms.Button btnCoaches;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

