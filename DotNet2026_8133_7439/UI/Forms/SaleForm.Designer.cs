using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeader;
        private ComboBox cmbProduct;
        private TextBox txtCount;
        private TextBox txtPrice;
        private TextBox txtDiscount;
        private DateTimePicker dtpDateStart;
        private DateTimePicker dtpDateEnd;
        private CheckBox chkClub;
        private Button btnOk;
        private Button btnCancel;
        private Label lblProductId;
        private Label lblCount;
        private Label lblPrice;
        private Label lblDiscount;
        private Label lblDateStart;
        private Label lblDateEnd;
        private Label lblClub;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new Label();
            this.cmbProduct = new ComboBox();
            this.txtCount = new TextBox();
            this.txtPrice = new TextBox();
            this.txtDiscount = new TextBox();
            this.dtpDateStart = new DateTimePicker();
            this.dtpDateEnd = new DateTimePicker();
            this.chkClub = new CheckBox();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.lblProductId = new Label();
            this.lblCount = new Label();
            this.lblPrice = new Label();
            this.lblDiscount = new Label();
            this.lblDateStart = new Label();
            this.lblDateEnd = new Label();
            this.lblClub = new Label();

            this.SuspendLayout();

            // lblHeader
            this.lblHeader.Location = new Point(12, 12);
            this.lblHeader.Size = new Size(300, 30);
            this.lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.FromArgb(91, 49, 27);
            this.lblHeader.Text = "Sale Details";

            // lblProductId
            this.lblProductId.Location = new Point(12, 55);
            this.lblProductId.Text = "Product:";
            this.lblProductId.Size = new Size(80, 20);
            this.lblProductId.ForeColor = Color.FromArgb(91, 49, 27);

            // cmbProduct
            this.cmbProduct.Location = new Point(100, 52);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new Size(220, 28);
            this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProduct.BackColor = Color.FromArgb(255, 244, 235);

            // lblCount
            this.lblCount.Location = new Point(12, 88);
            this.lblCount.Text = "Count:";
            this.lblCount.Size = new Size(80, 20);
            this.lblCount.ForeColor = Color.FromArgb(91, 49, 27);

            // txtCount
            this.txtCount.Location = new Point(100, 85);
            this.txtCount.Size = new Size(220, 28);
            this.txtCount.BackColor = Color.FromArgb(255, 244, 235);
            this.txtCount.BorderStyle = BorderStyle.FixedSingle;

            // lblPrice
            this.lblPrice.Location = new Point(12, 125);
            this.lblPrice.Text = "Price After Sale:";
            this.lblPrice.Size = new Size(110, 20);
            this.lblPrice.ForeColor = Color.FromArgb(91, 49, 27);

            // txtPrice
            this.txtPrice.Location = new Point(130, 122);
            this.txtPrice.Size = new Size(190, 28);
            this.txtPrice.BackColor = Color.FromArgb(255, 244, 235);
            this.txtPrice.BorderStyle = BorderStyle.FixedSingle;

            // lblDiscount
            this.lblDiscount.Location = new Point(12, 162);
            this.lblDiscount.Text = "Discount (%):";
            this.lblDiscount.Size = new Size(110, 20);
            this.lblDiscount.ForeColor = Color.FromArgb(91, 49, 27);

            // txtDiscount
            this.txtDiscount.Location = new Point(130, 159);
            this.txtDiscount.Size = new Size(190, 28);
            this.txtDiscount.BackColor = Color.FromArgb(255, 244, 235);
            this.txtDiscount.BorderStyle = BorderStyle.FixedSingle;

            // lblDateStart
            this.lblDateStart.Location = new Point(12, 199);
            this.lblDateStart.Text = "Start Date:";
            this.lblDateStart.Size = new Size(80, 20);
            this.lblDateStart.ForeColor = Color.FromArgb(91, 49, 27);

            // dtpDateStart
            this.dtpDateStart.Location = new Point(100, 196);
            this.dtpDateStart.Size = new Size(220, 28);
            this.dtpDateStart.Format = DateTimePickerFormat.Short;
            this.dtpDateStart.CalendarMonthBackground = Color.FromArgb(255, 244, 235);

            // lblDateEnd
            this.lblDateEnd.Location = new Point(12, 236);
            this.lblDateEnd.Text = "End Date:";
            this.lblDateEnd.Size = new Size(80, 20);
            this.lblDateEnd.ForeColor = Color.FromArgb(91, 49, 27);

            // dtpDateEnd
            this.dtpDateEnd.Location = new Point(100, 233);
            this.dtpDateEnd.Size = new Size(220, 28);
            this.dtpDateEnd.Format = DateTimePickerFormat.Short;
            this.dtpDateEnd.CalendarMonthBackground = Color.FromArgb(255, 244, 235);

            // lblClub
            this.lblClub.Location = new Point(12, 272);
            this.lblClub.Text = "Only Club Customers:";
            this.lblClub.Size = new Size(140, 20);
            this.lblClub.ForeColor = Color.FromArgb(91, 49, 27);

            // chkClub
            this.chkClub.Location = new Point(160, 272);
            this.chkClub.Size = new Size(22, 22);
            this.chkClub.BackColor = Color.Transparent;

            // btnOk
            this.btnOk.Location = new Point(100, 310);
            this.btnOk.Text = "Save";
            this.btnOk.Size = new Size(100, 32);
            this.btnOk.FlatStyle = FlatStyle.Flat;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.BackColor = Color.FromArgb(224, 131, 70);
            this.btnOk.ForeColor = Color.White;
            this.btnOk.Click += btnOk_Click;

            // btnCancel
            this.btnCancel.Location = new Point(220, 310);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Size = new Size(100, 32);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.BackColor = Color.FromArgb(171, 88, 54);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Click += (s, e) => this.Close();

            // SaleForm
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 248, 235);
            this.ClientSize = new Size(350, 360);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblDateStart);
            this.Controls.Add(this.dtpDateStart);
            this.Controls.Add(this.lblDateEnd);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.lblClub);
            this.Controls.Add(this.chkClub);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "SaleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Sale";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}