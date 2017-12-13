namespace Classification
{
    partial class MainForm
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
            this.documentTextBox = new System.Windows.Forms.RichTextBox();
            this.teachButton = new System.Windows.Forms.Button();
            this.getClassButton = new System.Windows.Forms.Button();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // documentTextBox
            // 
            this.documentTextBox.Location = new System.Drawing.Point(12, 12);
            this.documentTextBox.Name = "documentTextBox";
            this.documentTextBox.Size = new System.Drawing.Size(744, 422);
            this.documentTextBox.TabIndex = 1;
            this.documentTextBox.Text = "";
            // 
            // teachButton
            // 
            this.teachButton.Location = new System.Drawing.Point(173, 440);
            this.teachButton.Name = "teachButton";
            this.teachButton.Size = new System.Drawing.Size(142, 60);
            this.teachButton.TabIndex = 2;
            this.teachButton.Text = "Teach";
            this.teachButton.UseVisualStyleBackColor = true;
            this.teachButton.Click += new System.EventHandler(this.teachButton_Click);
            // 
            // getClassButton
            // 
            this.getClassButton.Location = new System.Drawing.Point(12, 440);
            this.getClassButton.Name = "getClassButton";
            this.getClassButton.Size = new System.Drawing.Size(132, 60);
            this.getClassButton.TabIndex = 3;
            this.getClassButton.Text = "Get possible class";
            this.getClassButton.UseVisualStyleBackColor = true;
            this.getClassButton.Click += new System.EventHandler(this.getClassButton_Click);
            // 
            // classBox
            // 
            this.classBox.FormattingEnabled = true;
            this.classBox.Location = new System.Drawing.Point(515, 440);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(241, 21);
            this.classBox.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 512);
            this.Controls.Add(this.classBox);
            this.Controls.Add(this.getClassButton);
            this.Controls.Add(this.teachButton);
            this.Controls.Add(this.documentTextBox);
            this.Name = "MainForm";
            this.Text = "Classifier";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox documentTextBox;
        private System.Windows.Forms.Button teachButton;
        private System.Windows.Forms.Button getClassButton;
        private System.Windows.Forms.ComboBox classBox;
    }
}

