namespace Assignment.Views.Car
{
    partial class newCarPanel
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            modelTextBox = new TextBox();
            label4 = new Label();
            DateTimePicker = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            stockQuality = new NumericUpDown();
            priceBox = new NumericUpDown();
            addCarButton = new Button();
            brandTextBox = new TextBox();
            priceBox.Maximum = 1000000m;  // Set maximum to 1 million
            priceBox.DecimalPlaces = 2;   // Show 2 decimal places
            priceBox.Increment = 0.01m;   // Increment by 0.01
            ((System.ComponentModel.ISupportInitialize)stockQuality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Banner", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 9);
            label1.Name = "label1";
            label1.Size = new Size(161, 35);
            label1.TabIndex = 0;
            label1.Text = "ADD NEW CAR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(65, 63);
            label2.Name = "label2";
            label2.Size = new Size(51, 18);
            label2.TabIndex = 1;
            label2.Text = "Brand";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(65, 120);
            label3.Name = "label3";
            label3.Size = new Size(52, 18);
            label3.TabIndex = 3;
            label3.Text = "Model";
            // 
            // modelTextBox
            // 
            modelTextBox.Location = new Point(81, 141);
            modelTextBox.Multiline = true;
            modelTextBox.Name = "modelTextBox";
            modelTextBox.Size = new Size(311, 23);
            modelTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(65, 177);
            label4.Name = "label4";
            label4.Size = new Size(40, 18);
            label4.TabIndex = 5;
            label4.Text = "Year";
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(81, 198);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(311, 23);
            DateTimePicker.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(62, 233);
            label5.Name = "label5";
            label5.Size = new Size(43, 18);
            label5.TabIndex = 7;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(65, 289);
            label6.Name = "label6";
            label6.Size = new Size(119, 18);
            label6.TabIndex = 9;
            label6.Text = "Stock Quantity";
            // 
            // stockQuality
            // 
            stockQuality.Location = new Point(81, 321);
            stockQuality.Name = "stockQuality";
            stockQuality.Size = new Size(311, 23);
            stockQuality.TabIndex = 10;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(81, 254);
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(311, 23);
            priceBox.TabIndex = 11;
            // 
            // addCarButton
            // 
            addCarButton.BackColor = Color.LimeGreen;
            addCarButton.Font = new Font("Courier New", 11F, FontStyle.Bold);
            addCarButton.Location = new Point(626, 388);
            addCarButton.Name = "addCarButton";
            addCarButton.Size = new Size(112, 33);
            addCarButton.TabIndex = 13;
            addCarButton.Text = "Add Car";
            addCarButton.UseVisualStyleBackColor = false;
            addCarButton.Click += addCarButton_Click;
            // 
            // brandTextBox
            // 
            brandTextBox.Location = new Point(81, 84);
            brandTextBox.Multiline = true;
            brandTextBox.Name = "brandTextBox";
            brandTextBox.Size = new Size(311, 23);
            brandTextBox.TabIndex = 14;
            // 
            // newCarPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(brandTextBox);
            Controls.Add(addCarButton);
            Controls.Add(priceBox);
            Controls.Add(stockQuality);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(DateTimePicker);
            Controls.Add(label4);
            Controls.Add(modelTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "newCarPanel";
            Text = "NewCar";
            ((System.ComponentModel.ISupportInitialize)stockQuality).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox modelTextBox;
        private Label label4;
        private DateTimePicker DateTimePicker;
        private Label label5;
        private Label label6;
        private NumericUpDown stockQuality;
        private NumericUpDown priceBox;
        private Button addCarButton;
        private TextBox brandTextBox;
    }
}