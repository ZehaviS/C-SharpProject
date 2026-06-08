using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnOk;
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
            txtId = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnOk = new Button();
            lblHeader = new Label();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Location = new Point(12, 12);
            lblHeader.Size = new Size(300, 30);
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(91, 49, 27);
            lblHeader.Text = "Customer Details";
            // 
            // txtId
            // 
            txtId.Location = new Point(12, 50);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id";
            txtId.Size = new Size(200, 28);
            txtId.TabIndex = 4;
            txtId.BackColor = Color.FromArgb(255, 244, 235);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 86);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(400, 28);
            txtName.TabIndex = 3;
            txtName.BackColor = Color.FromArgb(255, 244, 235);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(12, 122);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone";
            txtPhone.Size = new Size(250, 28);
            txtPhone.TabIndex = 2;
            txtPhone.BackColor = Color.FromArgb(255, 244, 235);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(12, 158);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(400, 28);
            txtAddress.TabIndex = 1;
            txtAddress.BackColor = Color.FromArgb(255, 244, 235);
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 200);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 32);
            btnOk.TabIndex = 0;
            btnOk.Text = "Save";
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.BackColor = Color.FromArgb(224, 131, 70);
            btnOk.ForeColor = Color.White;
            btnOk.Click += btnOk_Click;
            // 
            // CustomerForm
            // 
            ClientSize = new Size(440, 250);
            Controls.Add(btnOk);
            Controls.Add(lblHeader);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Name = "CustomerForm";
            Text = "Customer";
            BackColor = Color.FromArgb(255, 248, 235);
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 9F);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
