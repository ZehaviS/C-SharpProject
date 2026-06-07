//using System.Windows.Forms;

//namespace UI.Forms
//{
//    partial class ProductListForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private DataGridView dgvProducts;
//        private TextBox txtFilter;
//        private Button btnSearch;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.dgvProducts = new DataGridView();
//            this.txtFilter = new TextBox();
//            this.btnSearch = new Button();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // dgvProducts
//            // 
//            this.dgvProducts.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
//            this.dgvProducts.Location = new System.Drawing.Point(12, 50);
//            this.dgvProducts.Name = "dgvProducts";
//            this.dgvProducts.Size = new System.Drawing.Size(560, 300);
//            this.dgvProducts.ReadOnly = true;
//            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//            // 
//            // txtFilter
//            // 
//            this.txtFilter.Location = new System.Drawing.Point(12, 12);
//            this.txtFilter.Name = "txtFilter";
//            this.txtFilter.Size = new System.Drawing.Size(300, 23);
//            // 
//            // btnSearch
//            // 
//            this.btnSearch.Location = new System.Drawing.Point(320, 10);
//            this.btnSearch.Name = "btnSearch";
//            this.btnSearch.Size = new System.Drawing.Size(75, 25);
//            this.btnSearch.Text = "Search";
//            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);            // 
//            // ProductListForm
//            // 
//            this.ClientSize = new System.Drawing.Size(700, 370);
//            this.Controls.Add(this.btnSearch);
//            this.Controls.Add(this.txtFilter);
//            this.Controls.Add(this.dgvProducts);
//            this.Name = "ProductListForm";
//            this.Text = "Products";
//            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }
//    }
//}
using System.Windows.Forms;

namespace UI.Forms
{
    partial class ProductListForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvProducts;
        private TextBox txtFilter;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProducts = new DataGridView();
            this.txtFilter = new TextBox();
            this.btnSearch = new Button();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvProducts
            // 
            this.dgvProducts.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                      | AnchorStyles.Left)
                                      | AnchorStyles.Right;

            this.dgvProducts.Location = new System.Drawing.Point(12, 50);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(560, 300);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(12, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(300, 23);
            this.txtFilter.PlaceholderText = "Search by product name";

            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(320, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(580, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(580, 90);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(580, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // ProductListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 370);

            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.dgvProducts);

            this.Name = "ProductListForm";
            this.Text = "Products";

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

