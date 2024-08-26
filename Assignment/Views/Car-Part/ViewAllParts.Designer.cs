namespace Assignment.Views.Car_Part
{
    partial class ViewAllParts
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
            mainPanel = new Panel();
            dgvParts = new DataGridView();
            btnAction = new DataGridViewButtonColumn();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParts).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(dgvParts);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(738, 448);
            mainPanel.TabIndex = 0;
            // 
            // dgvParts
            // 
            dgvParts.AllowUserToAddRows = false;
            dgvParts.AllowUserToDeleteRows = false;
            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParts.Columns.AddRange(new DataGridViewColumn[] { btnAction });
            dgvParts.Dock = DockStyle.Fill;
            dgvParts.Location = new Point(0, 0);
            dgvParts.Name = "dgvParts";
            dgvParts.ReadOnly = true;
            dgvParts.Size = new Size(714, 384);
            dgvParts.TabIndex = 0;
            dgvParts.CellContentClick += dgvParts_CellContentClick;
            // 
            // btnAction
            // 
            btnAction.HeaderText = "Action";
            btnAction.Name = "btnAction";
            btnAction.ReadOnly = true;
            btnAction.Text = "Action";
            btnAction.UseColumnTextForButtonValue = true;
            // 
            // ViewAllCar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(722, 409);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewAllCarParts";
            Text = "ViewAllCarParts";
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvParts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.DataGridViewButtonColumn btnAction;

    }
}