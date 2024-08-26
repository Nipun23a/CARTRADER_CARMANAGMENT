namespace Assignment.Views.Dashboard
{
    partial class Dashboard
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
            report = new Label();
            orderDetails = new Label();
            userDetails = new Label();
            partsLabel = new Label();
            carMenu = new Label();
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
            sidePanel.Controls.Add(report);
            sidePanel.Controls.Add(orderDetails);
            sidePanel.Controls.Add(userDetails);
            sidePanel.Controls.Add(partsLabel);
            sidePanel.Controls.Add(carMenu);
            sidePanel.Controls.Add(quitButton);
            sidePanel.Controls.Add(adminDashboardLink);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.ForeColor = SystemColors.ActiveCaption;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(219, 520);
            sidePanel.TabIndex = 0;
            // 
            // report
            // 
            report.AutoSize = true;
            report.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            report.ForeColor = SystemColors.Control;
            report.Location = new Point(67, 308);
            report.Name = "report";
            report.Size = new Size(76, 24);
            report.TabIndex = 10;
            report.Text = "Reports";
            report.Click += report_Click;
            // 
            // orderDetails
            // 
            orderDetails.AutoSize = true;
            orderDetails.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderDetails.ForeColor = SystemColors.Control;
            orderDetails.Location = new Point(38, 252);
            orderDetails.Name = "orderDetails";
            orderDetails.Size = new Size(125, 24);
            orderDetails.TabIndex = 8;
            orderDetails.Text = "Order-Details";
            orderDetails.Click += orderDetails_Click;
            // 
            // userDetails
            // 
            userDetails.AutoSize = true;
            userDetails.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userDetails.ForeColor = SystemColors.Control;
            userDetails.Location = new Point(47, 202);
            userDetails.Name = "userDetails";
            userDetails.Size = new Size(116, 24);
            userDetails.TabIndex = 7;
            userDetails.Text = "User-Details";
            userDetails.Click += userDetails_Click;
            // 
            // partsLabel
            // 
            partsLabel.AutoSize = true;
            partsLabel.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            partsLabel.ForeColor = SystemColors.Control;
            partsLabel.Location = new Point(61, 145);
            partsLabel.Name = "partsLabel";
            partsLabel.Size = new Size(82, 24);
            partsLabel.TabIndex = 6;
            partsLabel.Text = "Car-Part";
            partsLabel.Click += partsLabel_Click;
            // 
            // carMenu
            // 
            carMenu.AutoSize = true;
            carMenu.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            carMenu.ForeColor = SystemColors.Control;
            carMenu.Location = new Point(81, 91);
            carMenu.Name = "carMenu";
            carMenu.Size = new Size(39, 24);
            carMenu.TabIndex = 5;
            carMenu.Text = "Car";
            carMenu.Click += carMenu_Click;
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
            adminDashboardLink.Size = new Size(198, 25);
            adminDashboardLink.TabIndex = 0;
            adminDashboardLink.Text = "Admin Dashboard";
            adminDashboardLink.Click += adminDashboardLink_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.ActiveCaption;
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(219, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(754, 33);
            headerPanel.TabIndex = 1;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(219, 33);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(754, 487);
            mainPanel.TabIndex = 2;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(973, 520);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Text = "Dashboard";
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidePanel;
        private Label adminDashboardLink;
        private Label quitButton;
        private Panel headerPanel;
        private Label orderDetails;
        private Label userDetails;
        private Label partsLabel;
        private Label carMenu;
        private Label report;
        private Panel mainPanel;
    }
}