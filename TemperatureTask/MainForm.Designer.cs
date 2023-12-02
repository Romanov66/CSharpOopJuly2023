namespace TemperatureTask
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            fromComboBox = new ComboBox();
            toComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            inputText = new TextBox();
            outputText = new TextBox();
            conversion = new Button();
            SuspendLayout();
            // 
            // fromComboBox
            // 
            fromComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fromComboBox.FormattingEnabled = true;
            fromComboBox.Items.AddRange(new object[] { "Градус Цельсия", "Градус Фаренгейта", "Кельвин" });
            fromComboBox.Location = new Point(12, 156);
            fromComboBox.Name = "fromComboBox";
            fromComboBox.Size = new Size(151, 28);
            fromComboBox.TabIndex = 0;
            // 
            // toComboBox
            // 
            toComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toComboBox.FormattingEnabled = true;
            toComboBox.Items.AddRange(new object[] { "Градус Цельсия", "Градус Фаренгейта", "Кельвин" });
            toComboBox.Location = new Point(346, 156);
            toComboBox.Name = "toComboBox";
            toComboBox.Size = new Size(151, 28);
            toComboBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 2;
            label1.Text = "Введите значение:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 9);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Результат:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 4;
            label3.Text = "Выберете шкалу:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(346, 123);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 5;
            label4.Text = "Выберете шкалу";
            // 
            // inputText
            // 
            inputText.Location = new Point(12, 32);
            inputText.Name = "inputText";
            inputText.Size = new Size(150, 27);
            inputText.TabIndex = 6;
            // 
            // outputText
            // 
            outputText.Location = new Point(346, 32);
            outputText.Name = "outputText";
            outputText.ReadOnly = true;
            outputText.Size = new Size(151, 27);
            outputText.TabIndex = 7;
            // 
            // conversion
            // 
            conversion.Location = new Point(192, 72);
            conversion.Name = "conversion";
            conversion.Size = new Size(124, 47);
            conversion.TabIndex = 8;
            conversion.Text = "Перевести";
            conversion.UseVisualStyleBackColor = true;
            conversion.Click += conversion_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 251);
            Controls.Add(conversion);
            Controls.Add(outputText);
            Controls.Add(inputText);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(toComboBox);
            Controls.Add(fromComboBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Temperature Conversion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox fromComboBox;
        private ComboBox toComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox inputText;
        private TextBox outputText;
        private Button conversion;
    }
}