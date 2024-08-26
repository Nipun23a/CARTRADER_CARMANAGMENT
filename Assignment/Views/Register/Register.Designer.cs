namespace Assignment.Views.Register
{
    partial class Register
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
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            userNameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            confirmPasswordTextBox = new TextBox();
            emailTextBox = new TextBox();
            RegisterButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            BackButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 36F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(295, 9);
            label1.Name = "label1";
            label1.Size = new Size(237, 80);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(64, 128);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.PlaceholderText = "First Name";
            firstNameTextBox.Size = new Size(301, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(427, 128);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.PlaceholderText = "Last Name";
            lastNameTextBox.Size = new Size(301, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(64, 214);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.PlaceholderText = "Username";
            userNameTextBox.Size = new Size(301, 23);
            userNameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(64, 372);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(301, 23);
            passwordTextBox.TabIndex = 4;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(427, 372);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PlaceholderText = "Confirm-Password";
            confirmPasswordTextBox.Size = new Size(301, 23);
            confirmPasswordTextBox.TabIndex = 5;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(64, 289);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "E-mail";
            emailTextBox.Size = new Size(487, 23);
            emailTextBox.TabIndex = 6;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.LimeGreen;
            RegisterButton.Font = new Font("Courier New", 11F, FontStyle.Bold);
            RegisterButton.Location = new Point(688, 450);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(112, 33);
            RegisterButton.TabIndex = 7;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(64, 102);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 8;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(427, 102);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 9;
            label3.Text = "Last Name ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(64, 263);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 10;
            label4.Text = "E-Mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(64, 346);
            label5.Name = "label5";
            label5.Size = new Size(77, 23);
            label5.TabIndex = 11;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(427, 346);
            label6.Name = "label6";
            label6.Size = new Size(137, 23);
            label6.TabIndex = 12;
            label6.Text = "Confirm Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(64, 188);
            label7.Name = "label7";
            label7.Size = new Size(79, 23);
            label7.TabIndex = 13;
            label7.Text = "Username";
            // 
            // BackButton
            // 
            BackButton.BackColor = SystemColors.ActiveCaption;
            BackButton.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            BackButton.Location = new Point(12, 9);
            BackButton.Margin = new Padding(0);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(52, 47);
            BackButton.TabIndex = 14;
            BackButton.Text = "<-";
            BackButton.UseVisualStyleBackColor = false;
            BackButton.Click += BackButton_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 483);
            Controls.Add(BackButton);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(RegisterButton);
            Controls.Add(emailTextBox);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(userNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private TextBox confirmPasswordTextBox;
        private TextBox emailTextBox;
        private Button RegisterButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button BackButton;
    }
}