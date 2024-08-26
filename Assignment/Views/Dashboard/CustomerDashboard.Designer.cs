namespace Assignment.Views.Dashboard
{
    partial class CustomerDashboard
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
            sidePanel = new Panel();
            orderDetails = new Label();
            orderItem = new Label();
            quitButton = new Label();
            adminDashboardLink = new Label();
            headerPanel = new Panel();
            mainPanel = new Panel();
            sidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.BackColor = SystemColors.ActiveCaption;
            sidePanel.Controls.Add(orderDetails);
            sidePanel.Controls.Add(orderItem);
            sidePanel.Controls.Add(quitButton);
            sidePanel.Controls.Add(adminDashboardLink);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.ForeColor = SystemColors.ActiveCaption;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(219, 520);
            sidePanel.TabIndex = 1;
            // 
            // orderDetails
            // 
            orderDetails.AutoSize = true;
            orderDetails.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderDetails.ForeColor = SystemColors.Control;
            orderDetails.Location = new Point(38, 278);
            orderDetails.Name = "orderDetails";
            orderDetails.Size = new Size(125, 24);
            orderDetails.TabIndex = 8;
            orderDetails.Text = "Order-Details";
            orderDetails.Click += orderDetails_Click;
            // 
            // orderItem
            // 
            orderItem.AutoSize = true;
            orderItem.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderItem.ForeColor = SystemColors.Control;
            orderItem.Location = new Point(81, 159);
            orderItem.Name = "orderItem";
            orderItem.Size = new Size(58, 24);
            orderItem.TabIndex = 5;
            orderItem.Text = "Order";
            orderItem.Click += orderItem_Click;
            // 
            // quitButton
            // 
            quitButton.AutoSize = true;
            quitButton.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quitButton.ForeColor = SystemColors.Control;
            quitButton.Location = new Point(81, 455);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(46, 24);
            quitButton.TabIndex = 4;
            quitButton.Text = "Quit";
            quitButton.Click += quitButton_Click;
            // 
            // adminDashboardLink
            // 
            adminDashboardLink.AutoSize = true;
            adminDashboardLink.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            adminDashboardLink.ForeColor = Color.Gold;
            adminDashboardLink.Location = new Point(11, 41);
            adminDashboardLink.Name = "adminDashboardLink";
            adminDashboardLink.Size = new Size(192, 25);
            adminDashboardLink.TabIndex = 0;
            adminDashboardLink.Text = "Client Dashboard";
            adminDashboardLink.Click += adminDashboardLink_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.ActiveCaption;
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(219, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(754, 33);
            headerPanel.TabIndex = 2;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(219, 33);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(754, 487);
            mainPanel.TabIndex = 3;
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(973, 520);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerDashboard";
            Text = "CustomerDashboard";
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidePanel;
        private Label orderDetails;
        private Label partsLabel;
        private Label orderItem;
        private Label quitButton;
        private Label adminDashboardLink;
        private Panel headerPanel;
        private Panel mainPanel;
    }
}