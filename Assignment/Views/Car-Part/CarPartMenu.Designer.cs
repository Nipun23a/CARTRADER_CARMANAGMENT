namespace Assignment.Views.Car_Part
{
    partial class CarPartMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            addNewPartButton = new Button();
            partsButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(266, 9);
            label1.Name = "label1";
            label1.Size = new Size(270, 48);
            label1.TabIndex = 0;
            label1.Text = "Parts Menu";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // addNewPartButton
            // 
            addNewPartButton.BackColor = Color.MistyRose;
            addNewPartButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addNewPartButton.Location = new Point(117, 157);
            addNewPartButton.Name = "addNewPartButton";
            addNewPartButton.Size = new Size(187, 182);
            addNewPartButton.TabIndex = 1;
            addNewPartButton.Text = "Add New Part";
            addNewPartButton.UseVisualStyleBackColor = false;
            addNewPartButton.Click += addNewPartButton_Click;
            // 
            // partsButton
            // 
            partsButton.BackColor = Color.MistyRose;
            partsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            partsButton.Location = new Point(421, 157);
            partsButton.Name = "partsButton";
            partsButton.Size = new Size(187, 182);
            partsButton.TabIndex = 2;
            partsButton.Text = "View Parts Details";
            partsButton.UseVisualStyleBackColor = false;
            partsButton.Click += partsButton_Click;
            // 
            // CarPartMenu
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(757, 522);
            Controls.Add(partsButton);
            Controls.Add(addNewPartButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CarPartMenu";
            Text = "CarMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button addNewPartButton;
        private Button partsButton;
    }
}