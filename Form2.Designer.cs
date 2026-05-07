namespace LB1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.buttonBegin = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbMinX = new System.Windows.Forms.TextBox();
            this.tbMaxX = new System.Windows.Forms.TextBox();
            this.tbNN = new System.Windows.Forms.TextBox();
            this.tbCountStream = new System.Windows.Forms.TextBox();
            this.tbMaxY = new System.Windows.Forms.TextBox();
            this.tbMinY = new System.Windows.Forms.TextBox();
            this.labelBegin = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBegin
            // 
            this.buttonBegin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBegin.Location = new System.Drawing.Point(139, 270);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(160, 43);
            this.buttonBegin.TabIndex = 0;
            this.buttonBegin.Text = "Начать";
            this.buttonBegin.UseVisualStyleBackColor = false;
            this.buttonBegin.Click += new System.EventHandler(this.buttonBegin_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonExit.Location = new System.Drawing.Point(861, 270);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(160, 43);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Закрыть";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Начальное значение Х";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label2.Location = new System.Drawing.Point(38, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Начальное значение Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label3.Location = new System.Drawing.Point(254, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Конечное значение Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label4.Location = new System.Drawing.Point(251, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Конечное значение Х";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label5.Location = new System.Drawing.Point(464, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Размерность массивов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label6.Location = new System.Drawing.Point(471, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Количество потоков";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label7.Location = new System.Drawing.Point(716, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "Начало";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label8.Location = new System.Drawing.Point(825, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 21);
            this.label8.TabIndex = 9;
            this.label8.Text = "Окончание";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.label9.Location = new System.Drawing.Point(969, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "Продолжительность";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(720, 158);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(409, 23);
            this.progressBar.TabIndex = 11;
            // 
            // tbMinX
            // 
            this.tbMinX.Location = new System.Drawing.Point(52, 64);
            this.tbMinX.Name = "tbMinX";
            this.tbMinX.Size = new System.Drawing.Size(142, 22);
            this.tbMinX.TabIndex = 12;
            // 
            // tbMaxX
            // 
            this.tbMaxX.Location = new System.Drawing.Point(263, 64);
            this.tbMaxX.Name = "tbMaxX";
            this.tbMaxX.Size = new System.Drawing.Size(142, 22);
            this.tbMaxX.TabIndex = 13;
            // 
            // tbNN
            // 
            this.tbNN.Location = new System.Drawing.Point(476, 64);
            this.tbNN.Name = "tbNN";
            this.tbNN.Size = new System.Drawing.Size(142, 22);
            this.tbNN.TabIndex = 14;
            // 
            // tbCountStream
            // 
            this.tbCountStream.Location = new System.Drawing.Point(475, 158);
            this.tbCountStream.Name = "tbCountStream";
            this.tbCountStream.Size = new System.Drawing.Size(142, 22);
            this.tbCountStream.TabIndex = 15;
            // 
            // tbMaxY
            // 
            this.tbMaxY.Location = new System.Drawing.Point(263, 159);
            this.tbMaxY.Name = "tbMaxY";
            this.tbMaxY.Size = new System.Drawing.Size(142, 22);
            this.tbMaxY.TabIndex = 16;
            // 
            // tbMinY
            // 
            this.tbMinY.Location = new System.Drawing.Point(52, 159);
            this.tbMinY.Name = "tbMinY";
            this.tbMinY.Size = new System.Drawing.Size(142, 22);
            this.tbMinY.TabIndex = 17;
            // 
            // labelBegin
            // 
            this.labelBegin.AutoSize = true;
            this.labelBegin.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.labelBegin.Location = new System.Drawing.Point(728, 65);
            this.labelBegin.Name = "labelBegin";
            this.labelBegin.Size = new System.Drawing.Size(40, 21);
            this.labelBegin.TabIndex = 18;
            this.labelBegin.Text = "000";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.labelEnd.Location = new System.Drawing.Point(847, 65);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(40, 21);
            this.labelEnd.TabIndex = 19;
            this.labelEnd.Text = "000";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Sitka Text", 9F);
            this.labelTime.Location = new System.Drawing.Point(1023, 65);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(40, 21);
            this.labelTime.TabIndex = 20;
            this.labelTime.Text = "000";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1195, 354);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelBegin);
            this.Controls.Add(this.tbMinY);
            this.Controls.Add(this.tbMaxY);
            this.Controls.Add(this.tbCountStream);
            this.Controls.Add(this.tbNN);
            this.Controls.Add(this.tbMaxX);
            this.Controls.Add(this.tbMinX);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBegin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "z = e^x · √(1 − e^{2x}) + arcsin(y)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox tbMinX;
        private System.Windows.Forms.TextBox tbMaxX;
        private System.Windows.Forms.TextBox tbNN;
        private System.Windows.Forms.TextBox tbCountStream;
        private System.Windows.Forms.TextBox tbMaxY;
        private System.Windows.Forms.TextBox tbMinY;
        private System.Windows.Forms.Label labelBegin;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label labelTime;
    }
}