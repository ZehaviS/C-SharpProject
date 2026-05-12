//using System;
//using System.Linq;
//using System.Windows.Forms;
//using BlApi;
//using BO;

//namespace UI.Forms
//{
//    public partial class CustomerListForm : Form
//    {
//        private readonly IBl _bl;

//        public CustomerListForm(IBl bl)
//        {
//            _bl = bl;
//            InitializeComponent();
//            LoadCustomers();
//        }

//        private void LoadCustomers(string? filter = null)
//        {
//            var list = _bl.Customer.ReadAll(filter == null ? null : new Func<Customer, bool>(c => c.CustomerName.Contains(filter, StringComparison.OrdinalIgnoreCase)));
//            dgvCustomers.DataSource = list.Select(c => new { Id = c?.CustomerId, Name = c?.CustomerName, Phone = c?.CustomerPhone }).ToList();
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            var f = new CustomerForm(_bl);
//            if (f.ShowDialog(this) == DialogResult.OK)
//                LoadCustomers(txtFilter.Text);
//        }

//        private void btnEdit_Click(object sender, EventArgs e)
//        {
//            if (dgvCustomers.CurrentRow == null) return;
//            var id = (int?)dgvCustomers.CurrentRow.Cells[0].Value;
//            if (id == null) return;
//            var cust = _bl.Customer.Read(id.Value);
//            if (cust == null) return;
//            var f = new CustomerForm(_bl, cust);
//            if (f.ShowDialog(this) == DialogResult.OK)
//                LoadCustomers(txtFilter.Text);
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (dgvCustomers.CurrentRow == null) return;
//            var id = (int?)dgvCustomers.CurrentRow.Cells[0].Value;
//            if (id == null) return;
//            var confirm = MessageBox.Show(this, "Delete customer?", "Confirm", MessageBoxButtons.YesNo);
//            if (confirm != DialogResult.Yes) return;
//            _bl.Customer.Delete(id.Value);
//            LoadCustomers(txtFilter.Text);
//        }

//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            LoadCustomers(txtFilter.Text);
//        }
//    }
//}
using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI.Forms
{
    public partial class CustomerListForm : Form
    {
        private readonly IBl _bl;

        public CustomerListForm(IBl bl)
        {
            _bl = bl;
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers(string? filter = null)
        {
            try
            {
                var list = _bl.Customer.ReadAll();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    list = list
                        .Where(c => c != null &&
                                    !string.IsNullOrEmpty(c.CustomerName) &&
                                    c.CustomerName.Contains(filter, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                dgvCustomers.DataSource = list
                    .Select(c => new
                    {
                        Id = c!.CustomerId,
                        Name = c.CustomerName,
                        Phone = c.CustomerPhone
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new CustomerForm(_bl);

            if (f.ShowDialog(this) == DialogResult.OK)
                LoadCustomers(txtFilter.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.CurrentRow == null) return;

                if (!int.TryParse(dgvCustomers.CurrentRow.Cells["Id"].Value?.ToString(), out int id))
                    return;

                var cust = _bl.Customer.Read(id);
                if (cust == null) return;

                var f = new CustomerForm(_bl, cust);

                if (f.ShowDialog(this) == DialogResult.OK)
                    LoadCustomers(txtFilter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit failed: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.CurrentRow == null) return;

                if (!int.TryParse(dgvCustomers.CurrentRow.Cells["Id"].Value?.ToString(), out int id))
                    return;

                var confirm = MessageBox.Show(this, "Delete customer?", "Confirm",
                    MessageBoxButtons.YesNo);

                if (confirm != DialogResult.Yes) return;

                _bl.Customer.Delete(id);

                LoadCustomers(txtFilter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtFilter.Text);
        }
    }
}
