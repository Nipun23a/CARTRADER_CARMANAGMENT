namespace Assignment.Views.Car_Part
{
    partial class NewCarPart
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
            descriptionTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            stockBox = new NumericUpDown();
            priceBox = new NumericUpDown();
            addCarPartButton = new Button();
            carPartNameTextBox = new TextBox();
            priceBox.Maximum = 1000000m;  
            priceBox.DecimalPlaces = 2;   
            priceBox.Increment = 0.01m;   
            ((System.ComponentModel.ISupportInitialize)stockBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Banner", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 9);
            label1.Name = "label1";
            label1.Size = new Size(220, 35);
            label1.TabIndex = 0;
            label1.Text = "ADD NEW CAR PART";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(65, 63);
            label2.Name = "label2";
            label2.Size = new Size(52, 18);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(65, 120);
            label3.Name = "label3";
            label3.Size = new Size(90, 18);
            label3.TabIndex = 3;
            label3.Text = "Description";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(81, 141);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(311, 89);
            descriptionTextBox.TabIndex = 4;
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
            // stockBox
            // 
            stockBox.Location = new Point(81, 321);
            stockBox.Name = "stockBox";
            stockBox.Size = new Size(311, 23);
            stockBox.TabIndex = 10;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(81, 263);
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(311, 23);
            priceBox.TabIndex = 11;
            // 
            // addCarPartButton
            // 
            addCarPartButton.BackColor = Color.LimeGreen;
            addCarPartButton.Font = new Font("Courier New", 11F, FontStyle.Bold);
            addCarPartButton.Location = new Point(626, 388);
            addCarPartButton.Name = "addCarPartButton";
            addCarPartButton.Size = new Size(112, 33);
            addCarPartButton.TabIndex = 13;
            addCarPartButton.Text = "Add  Part";
            addCarPartButton.UseVisualStyleBackColor = false;
            addCarPartButton.Click += addCarPartButton_Click;
            // 
            // carPartNameTextBox
            // 
            carPartNameTextBox.Location = new Point(81, 84);
            carPartNameTextBox.Name = "carPartNameTextBox";
            carPartNameTextBox.Size = new Size(311, 23);
            carPartNameTextBox.TabIndex = 14;
            // 
            // NewCarPart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(carPartNameTextBox);
            Controls.Add(addCarPartButton);
            Controls.Add(priceBox);
            Controls.Add(stockBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(descriptionTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewCarPart";
            Text = "NewCar";
            ((System.ComponentModel.ISupportInitialize)stockBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox carPartNameComboBox;
        private Label label3;
        private TextBox descriptionTextBox;
        private Label label5;
        private Label label6;
        private NumericUpDown stockBox;
        private NumericUpDown priceBox;
        private Button addCarPartButton;
        private TextBox carPartNameTextBox;
    }
}