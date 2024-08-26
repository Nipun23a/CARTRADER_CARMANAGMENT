namespace Assignment.Views.Car
{
    partial class ViewAllCar
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
            dgvCars = new DataGridView();
            btnAction = new DataGridViewButtonColumn();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(dgvCars);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(738, 448);
            mainPanel.TabIndex = 0;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Columns.AddRange(new DataGridViewColumn[] { btnAction });
            dgvCars.Dock = DockStyle.Fill;
            dgvCars.Location = new Point(0, 0);
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.Size = new Size(714, 384);
            dgvCars.TabIndex = 0;
            dgvCars.CellContentClick += dgvCars_CellContentClick;
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
            Name = "ViewAllCar";
            Text = "ViewAllCar";
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.DataGridViewButtonColumn btnAction;
    }
}
