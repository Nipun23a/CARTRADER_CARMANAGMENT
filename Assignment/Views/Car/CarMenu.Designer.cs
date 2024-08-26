namespace Assignment.Views.Car
{
    partial class CarMenu
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
            addnewCarButton = new Button();
            viewCarDetailsButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(287, 9);
            label1.Name = "label1";
            label1.Size = new Size(220, 48);
            label1.TabIndex = 0;
            label1.Text = "Car Menu";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // addnewCarButton
            // 
            addnewCarButton.BackColor = Color.MistyRose;
            addnewCarButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addnewCarButton.Location = new Point(117, 157);
            addnewCarButton.Name = "addnewCarButton";
            addnewCarButton.Size = new Size(187, 182);
            addnewCarButton.TabIndex = 1;
            addnewCarButton.Text = "Add New Car";
            addnewCarButton.UseVisualStyleBackColor = false;
            addnewCarButton.Click += addnewCarButton_Click;
            // 
            // viewCarDetailsButton
            // 
            viewCarDetailsButton.BackColor = Color.MistyRose;
            viewCarDetailsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewCarDetailsButton.Location = new Point(421, 157);
            viewCarDetailsButton.Name = "viewCarDetailsButton";
            viewCarDetailsButton.Size = new Size(187, 182);
            viewCarDetailsButton.TabIndex = 2;
            viewCarDetailsButton.Text = "View Car Details";
            viewCarDetailsButton.UseVisualStyleBackColor = false;
            viewCarDetailsButton.Click += viewCarDetailsButton_Click;
            // 
            // CarMenu
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(757, 522);
            Controls.Add(viewCarDetailsButton);
            Controls.Add(addnewCarButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CarMenu";
            Text = "CarMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button addnewCarButton;
        private Button viewCarDetailsButton;
    }
}