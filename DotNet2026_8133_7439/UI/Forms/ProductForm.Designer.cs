using System.Windows.Forms;

namespace UI.Forms
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtName;
        private TextBox txtPrice;
        private Button btnOk;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCount;

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
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtCount = new TextBox();
            cmbCategory = new ComboBox();
            btnOk = new Button();

            lblCategory = new Label();
            lblCount = new Label();

            SuspendLayout();

            // txtName
            txtName.Location = new System.Drawing.Point(12, 12);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Product Name";
            txtName.Size = new System.Drawing.Size(300, 27);

            // txtPrice
            txtPrice.Location = new System.Drawing.Point(12, 50);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new System.Drawing.Size(300, 27);

            // lblCategory
            lblCategory.Location = new System.Drawing.Point(12, 85);
            lblCategory.Size = new System.Drawing.Size(100, 20);
            lblCategory.Text = "Category:";

            // cmbCategory
            cmbCategory.Location = new System.Drawing.Point(12, 110);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new System.Drawing.Size(300, 28);

            // lblCount
            lblCount.Location = new System.Drawing.Point(12, 145);
            lblCount.Size = new System.Drawing.Size(100, 20);
            lblCount.Text = "Count:";

            // txtCount
            txtCount.Location = new System.Drawing.Point(12, 170);
            txtCount.Name = "txtCount";
            txtCount.PlaceholderText = "Product Count";
            txtCount.Size = new System.Drawing.Size(300, 27);

            // btnOk
            btnOk.Location = new System.Drawing.Point(12, 210);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(100, 30);
            btnOk.Text = "OK";
            btnOk.Click += btnOk_Click;

            // ProductForm
            ClientSize = new System.Drawing.Size(350, 260);
            Controls.Add(btnOk);
            Controls.Add(txtCount);
            Controls.Add(lblCount);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtName);

            Name = "ProductForm";
            Text = "Product";

            ResumeLayout(false);
            PerformLayout();
        }
    }
    }