using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtProductId;
        private TextBox txtCount;
        private TextBox txtPrice;
        private CheckBox chkClub;
        private Button btnOk;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtProductId = new TextBox();
            this.txtCount = new TextBox();
            this.txtPrice = new TextBox();
            this.chkClub = new CheckBox();
            this.btnOk = new Button();

            this.SuspendLayout();

            // txtProductId
            this.txtProductId.Location = new Point(12, 12);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.PlaceholderText = "Product Id";

            // txtCount
            this.txtCount.Location = new Point(12, 45);
            this.txtCount.PlaceholderText = "Count";

            // txtPrice
            this.txtPrice.Location = new Point(12, 78);
            this.txtPrice.PlaceholderText = "Price After Sale";

            // chkClub
            this.chkClub.Location = new Point(12, 110);
            this.chkClub.Text = "Only Club Customers";

            // btnOk
            this.btnOk.Location = new Point(12, 150);
            this.btnOk.Text = "OK";
            this.btnOk.Click += btnOk_Click;

            // SaleForm
            this.ClientSize = new Size(300, 220);
            this.Controls.Add(txtProductId);
            this.Controls.Add(txtCount);
            this.Controls.Add(txtPrice);
            this.Controls.Add(chkClub);
            this.Controls.Add(btnOk);

            this.Text = "Sale";

            this.ResumeLayout(false);
        }
    }
}