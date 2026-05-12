//using System;
//using System.Windows.Forms;
//using BlApi;
//using BO;

//namespace UI.Forms
//{
//    public partial class CustomerForm : Form
//    {
//        private readonly IBl _bl;
//        private readonly Customer? _customer;

//        public CustomerForm(IBl bl, Customer? customer = null)
//        {
//            _bl = bl;
//            _customer = customer;
//            InitializeComponent();
//            if (_customer != null) LoadForEdit();
//        }

//        private void LoadForEdit()
//        {
//            txtId.Text = _customer!.CustomerId.ToString();
//            txtName.Text = _customer.CustomerName;
//            txtPhone.Text = _customer.CustomerPhone;
//            txtAddress.Text = _customer.CustomerAddress;
//            txtId.ReadOnly = true;
//        }

//        private void btnOk_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtName.Text))
//            {
//                MessageBox.Show(this, "Name required");
//                return;
//            }
//            if (string.IsNullOrWhiteSpace(txtPhone.Text))
//            {
//                MessageBox.Show(this, "Phone required");
//                return;
//            }

//            Customer c;
//            if (_customer == null)
//            {
//                if (!int.TryParse(txtId.Text, out var id))
//                {
//                    MessageBox.Show(this, "Id must be numeric");
//                    return;
//                }
//                c = new Customer { CustomerId = id, CustomerName = txtName.Text, CustomerPhone = txtPhone.Text, CustomerAddress = txtAddress.Text };
//                _bl.Customer.Create(c);
//            }
//            else
//            {
//                c = new Customer { CustomerId = _customer.CustomerId, CustomerName = txtName.Text, CustomerPhone = txtPhone.Text, CustomerAddress = txtAddress.Text };
//                _bl.Customer.Update(c);
//            }

//            DialogResult = DialogResult.OK;
//            Close();
//        }
//    }
//}using System;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly IBl _bl;
        private readonly Customer? _customer;

        public CustomerForm(IBl bl, Customer? customer = null)
        {
            _bl = bl;
            _customer = customer;
            InitializeComponent();

            if (_customer != null)
                LoadForEdit();
        }

        private void LoadForEdit()
        {
            txtId.Text = _customer!.CustomerId.ToString();
            txtName.Text = _customer.CustomerName;
            txtPhone.Text = _customer.CustomerPhone;
            txtAddress.Text = _customer.CustomerAddress ?? "";

            txtId.ReadOnly = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // -------- VALIDATION --------
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("Id must be numeric");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Phone required");
                    return;
                }

                // -------- CREATE OBJECT --------
                var c = new Customer
                {
                    CustomerId = id,
                    CustomerName = txtName.Text,
                    CustomerPhone = txtPhone.Text,
                    CustomerAddress = txtAddress.Text ?? ""
                };

                // -------- CALL BL --------
                if (_customer == null)
                    _bl.Customer.Create(c);
                else
                    _bl.Customer.Update(c);

                MessageBox.Show("Saved successfully");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed:\n" + ex.Message);
            }
        }
    }
}
