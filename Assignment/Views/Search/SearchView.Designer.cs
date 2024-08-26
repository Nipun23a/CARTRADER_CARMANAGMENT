namespace Assignment.Views.Search
{
    partial class SearchView
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
            radioCars = new RadioButton();
            radioParts = new RadioButton();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvResults = new DataGridView();
            btnOrder = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // radioCars
            // 
            radioCars.AutoSize = true;
            radioCars.Checked = true;
            radioCars.Location = new Point(12, 12);
            radioCars.Name = "radioCars";
            radioCars.Size = new Size(48, 19);
            radioCars.TabIndex = 0;
            radioCars.TabStop = true;
            radioCars.Text = "Cars";
            radioCars.UseVisualStyleBackColor = true;
            // 
            // radioParts
            // 
            radioParts.AutoSize = true;
            radioParts.Location = new Point(65, 12);
            radioParts.Name = "radioParts";
            radioParts.Size = new Size(72, 19);
            radioParts.TabIndex = 1;
            radioParts.Text = "Car Parts";
            radioParts.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(146, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(352, 11);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { btnOrder });
            dgvResults.Location = new Point(12, 40);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.Size = new Size(698, 357);
            dgvResults.TabIndex = 4;
            dgvResults.CellContentClick += dgvResults_CellContentClick;
            // 
            // btnOrder
            // 
            btnOrder.HeaderText = "Order";
            btnOrder.Name = "btnOrder";
            btnOrder.ReadOnly = true;
            btnOrder.Text = "Order";
            btnOrder.UseColumnTextForButtonValue = true;
            // 
            // SearchView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 409);
            Controls.Add(dgvResults);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(radioParts);
            Controls.Add(radioCars);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SearchView";
            Text = "7";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton radioCars;
        private System.Windows.Forms.RadioButton radioParts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewButtonColumn btnOrder;
    }
}