using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class SaleListForm
    {
        private Panel panelHeader;
        private Label lblHeader;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvSales;
        private TextBox txtFilter;
        private Button btnSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblHeader = new Label();
            this.dgvSales = new DataGridView();
            this.txtFilter = new TextBox();
            this.btnSearch = new Button();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(191, 101, 45);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 90;
            this.panelHeader.Controls.Add(this.lblHeader);

            // lblHeader
            this.lblHeader.AutoSize = false;
            this.lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Location = new Point(20, 25);
            this.lblHeader.Size = new Size(500, 40);
            this.lblHeader.Text = "💰 Bakery Sales";

            // txtFilter
            this.txtFilter.Location = new Point(16, 110);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new Size(360, 28);
            this.txtFilter.PlaceholderText = "🔎 Search by sale id";
            this.txtFilter.BackColor = Color.FromArgb(255, 244, 235);
            this.txtFilter.BorderStyle = BorderStyle.FixedSingle;

            // btnSearch
            this.btnSearch.Location = new Point(390, 108);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(100, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.BackColor = Color.FromArgb(224, 131, 70);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // dgvSales
            this.dgvSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvSales.Location = new Point(16, 150);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new Size(740, 340);
            this.dgvSales.ReadOnly = true;
            this.dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.MultiSelect = false;
            this.dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.BackgroundColor = Color.FromArgb(255, 251, 244);
            this.dgvSales.BorderStyle = BorderStyle.None;
            this.dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(191, 101, 45);
            this.dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.dgvSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvSales.RowTemplate.Height = 30;
            this.dgvSales.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgvSales.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 222, 190);

            // btnAdd
            this.btnAdd.Location = new Point(760, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(110, 35);
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.BackColor = Color.FromArgb(255, 176, 109);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new Point(760, 195);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(110, 35);
            this.btnEdit.Text = "✏️ Edit";
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.BackColor = Color.FromArgb(224, 131, 70);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new Point(760, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(110, 35);
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.BackColor = Color.FromArgb(171, 88, 54);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // SaleListForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 248, 235);
            this.ClientSize = new Size(900, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.panelHeader);
            this.Name = "SaleListForm";
            this.Text = "Bakery Sales";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}