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
        private Panel panelHeader;
        private Label lblHeader;
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
            this.panelHeader = new Panel();
            this.lblHeader = new Label();
            this.dgvProducts = new DataGridView();
            this.txtFilter = new TextBox();
            this.btnSearch = new Button();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(191, 101, 45);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 90;
            this.panelHeader.Controls.Add(this.lblHeader);

            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = false;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 25);
            this.lblHeader.Size = new System.Drawing.Size(500, 40);
            this.lblHeader.Text = "🥐 Bakery Products";

            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(16, 110);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(360, 28);
            this.txtFilter.PlaceholderText = "🔎 Search by product name";
            this.txtFilter.BackColor = System.Drawing.Color.FromArgb(255, 244, 235);
            this.txtFilter.BorderStyle = BorderStyle.FixedSingle;

            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(390, 108);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(224, 131, 70);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // dgvProducts
            // 
            this.dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvProducts.Location = new System.Drawing.Point(16, 150);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(740, 340);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(255, 251, 244);

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(760, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 35);
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(255, 176, 109);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(760, 195);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 35);
            this.btnEdit.Text = "✏️ Edit";
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(224, 131, 70);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(760, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(171, 88, 54);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // ProductListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 235);
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.panelHeader);

            this.Name = "ProductListForm";
            this.Text = "Bakery Products";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

