using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtPrice;
        private Button btnOk;
        private ComboBox cmbCategory;
        private TextBox txtCount;
        private Label lblCategory;
        private Label lblCount;
        private Label lblHeader;

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
            lblHeader = new Label();

            SuspendLayout();

            // lblHeader
            lblHeader.Location = new Point(12, 12);
            lblHeader.Size = new Size(320, 30);
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(91, 49, 27);
            lblHeader.Text = "Product Details";

            // txtName
            txtName.Location = new Point(12, 52);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Product Name";
            txtName.Size = new Size(320, 28);
            txtName.BackColor = Color.FromArgb(255, 244, 235);
            txtName.BorderStyle = BorderStyle.FixedSingle;

            // txtPrice
            txtPrice.Location = new Point(12, 92);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new Size(320, 28);
            txtPrice.BackColor = Color.FromArgb(255, 244, 235);
            txtPrice.BorderStyle = BorderStyle.FixedSingle;

            // lblCategory
            lblCategory.Location = new Point(12, 132);
            lblCategory.Size = new Size(100, 20);
            lblCategory.Text = "Category:";
            lblCategory.ForeColor = Color.FromArgb(91, 49, 27);

            // cmbCategory
            cmbCategory.Location = new Point(12, 156);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(320, 28);
            cmbCategory.BackColor = Color.FromArgb(255, 244, 235);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblCount
            lblCount.Location = new Point(12, 196);
            lblCount.Size = new Size(100, 20);
            lblCount.Text = "Count:";
            lblCount.ForeColor = Color.FromArgb(91, 49, 27);

            // txtCount
            txtCount.Location = new Point(12, 220);
            txtCount.Name = "txtCount";
            txtCount.PlaceholderText = "Product Count";
            txtCount.Size = new Size(320, 28);
            txtCount.BackColor = Color.FromArgb(255, 244, 235);
            txtCount.BorderStyle = BorderStyle.FixedSingle;

            // btnOk
            btnOk.Location = new Point(12, 260);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 32);
            btnOk.Text = "Save";
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.BackColor = Color.FromArgb(224, 131, 70);
            btnOk.ForeColor = Color.White;
            btnOk.Click += btnOk_Click;

            // ProductForm
            ClientSize = new Size(360, 310);
            Controls.Add(btnOk);
            Controls.Add(lblHeader);
            Controls.Add(txtCount);
            Controls.Add(lblCount);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Name = "ProductForm";
            Text = "Product";
            BackColor = Color.FromArgb(255, 248, 235);
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 9F);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
