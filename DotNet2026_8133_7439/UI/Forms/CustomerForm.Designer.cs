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
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(12, 12);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id";
            txtId.Size = new Size(200, 27);
            txtId.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 45);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(300, 27);
            txtName.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(12, 78);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone";
            txtPhone.Size = new Size(200, 27);
            txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(12, 111);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(400, 27);
            txtAddress.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 150);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 30);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.Click += btnOk_Click;
            // 
            // CustomerForm
            // 
            ClientSize = new Size(459, 219);
            Controls.Add(btnOk);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Name = "CustomerForm";
            Text = "Customer";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
