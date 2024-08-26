namespace Assignment.Views.Reports
{
    partial class OrderReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            generateReportButton = new Button();
            SuspendLayout();
            // 
            // generateReportButton
            // 
            generateReportButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            generateReportButton.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            generateReportButton.Location = new Point(14, 14);
            generateReportButton.Margin = new Padding(4, 3, 4, 3);
            generateReportButton.Name = "generateReportButton";
            generateReportButton.Size = new Size(710, 35);
            generateReportButton.TabIndex = 0;
            generateReportButton.Text = "Generate Report";
            generateReportButton.UseVisualStyleBackColor = true;
            generateReportButton.Click += generateReportButton_Click;
            // 
            // OrderReportView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(738, 448);
            Controls.Add(generateReportButton);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderReportView";
            Text = "Order Report";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button generateReportButton;
    }
}