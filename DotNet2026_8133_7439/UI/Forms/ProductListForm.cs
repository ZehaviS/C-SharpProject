using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;

namespace UI.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly IBl _bl;

        public ProductListForm(IBl bl)
        {
            _bl = bl;
            InitializeComponent();
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(txtFilter.Text);
        }

        private void LoadProducts(string? filter = null)
        {
            var list = _bl.Product.ReadAll(
                string.IsNullOrWhiteSpace(filter)
                ? null
                : new Func<BO.Product, bool>(p =>
                    p.ProductName.Contains(filter, StringComparison.OrdinalIgnoreCase))
            );

            dgvProducts.DataSource = list.Select(p => new
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Price = p.ProductPrice,
                Count = p.ProductCount,
                Category = p.ProductCategory
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm(_bl);

            if (form.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            int id = (int)dgvProducts.CurrentRow.Cells["Id"].Value;

            BO.Product product = _bl.Product.Read(id);

            // ✅ תיקון: אין as, אין nullable cast
            ProductForm form = new ProductForm(_bl, product);

            if (form.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            int id = (int)dgvProducts.CurrentRow.Cells["Id"].Value;

            try
            {
                _bl.Product.Delete(id);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}