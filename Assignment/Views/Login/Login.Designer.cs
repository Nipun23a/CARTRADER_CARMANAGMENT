using System.Drawing.Drawing2D;


namespace Assignment.Views
{

    
    partial class Login
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
            UserNameBox = new TextBox();
            PasswordBox = new TextBox();
            label2 = new Label();
            Password = new Label();
            loginButton = new Button();
            NewAccount = new LinkLabel();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe Script", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gold;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            label1.Location = new Point(111, 20);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(174, 80);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // UserNameBox
            // 
            UserNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserNameBox.Location = new Point(37, 145);
            UserNameBox.MaxLength = 20;
            UserNameBox.MinimumSize = new Size(307, 30);
            UserNameBox.Name = "UserNameBox";
            UserNameBox.PlaceholderText = "Username";
            UserNameBox.Size = new Size(307, 30);
            UserNameBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(37, 217);
            PasswordBox.MaxLength = 20;
            PasswordBox.MinimumSize = new Size(307, 30);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PlaceholderText = "Password";
            PasswordBox.Size = new Size(307, 30);
            PasswordBox.TabIndex = 2;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 119);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Password.Location = new Point(37, 187);
            Password.Name = "Password";
            Password.Size = new Size(87, 23);
            Password.TabIndex = 4;
            Password.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.LimeGreen;
            loginButton.Font = new Font("Courier New", 11F, FontStyle.Bold);
            loginButton.ForeColor = SystemColors.ActiveCaptionText;
            loginButton.Location = new Point(139, 271);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(103, 38);
            loginButton.TabIndex = 5;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // NewAccount
            // 
            NewAccount.AutoSize = true;
            NewAccount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            NewAccount.Location = new Point(209, 338);
            NewAccount.Name = "NewAccount";
            NewAccount.Size = new Size(105, 19);
            NewAccount.TabIndex = 6;
            NewAccount.TabStop = true;
            NewAccount.Text = "Create Account";
            NewAccount.LinkClicked += NewAccount_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(49, 338);
            label3.Name = "label3";
            label3.Size = new Size(163, 19);
            label3.TabIndex = 7;
            label3.Text = "Don't Have a Account ?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(400, 450);
            Controls.Add(label3);
            Controls.Add(NewAccount);
            Controls.Add(loginButton);
            Controls.Add(Password);
            Controls.Add(label2);
            Controls.Add(PasswordBox);
            Controls.Add(UserNameBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Login";
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserNameBox;
        private TextBox PasswordBox;
        private Label label2;
        private Label Password;
        private Button loginButton;
        private LinkLabel NewAccount;
        private Label label3;
        private LinkLabel AdminLink;
    }
}