using System;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class SaleListForm
    {
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
            this.dgvSales = new DataGridView();
            this.txtFilter = new TextBox();
            this.btnSearch = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();

            // dgvSales
            this.dgvSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvSales.Location = new System.Drawing.Point(12, 50);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new System.Drawing.Size(560, 300);
            this.dgvSales.ReadOnly = true;
            this.dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // txtFilter
            this.txtFilter.Location = new System.Drawing.Point(12, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(300, 23);
            this.txtFilter.PlaceholderText = "Search by saleId";

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(320, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // btnAdd
            this.btnAdd = new Button();
            this.btnAdd.Location = new System.Drawing.Point(410, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit = new Button();
            this.btnEdit.Location = new System.Drawing.Point(490, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete = new Button();
            this.btnDelete.Location = new System.Drawing.Point(570, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // ⚠️ קריטי: חייב להתאים ל־btnSearch_Click בקוד
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // SaleListForm
            this.ClientSize = new System.Drawing.Size(700, 370);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Name = "SaleListForm";
            this.Text = "Sales";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}