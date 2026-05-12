using System;
using System.Windows.Forms;
using BlApi;

namespace UI.Forms
{
    public partial class ProductForm : Form
    {
        private readonly IBl _bl;
        private readonly BO.Product? _product;

        public ProductForm(IBl bl, BO.Product? product = null)
        {
            InitializeComponent();

            _bl = bl;
            _product = product;

            cmbCategory.DataSource = Enum.GetValues(typeof(BO.ProductsCategories));

            if (_product != null)
            {
                txtName.Text = _product.ProductName;
                txtPrice.Text = _product.ProductPrice.ToString();
                txtCount.Text = _product.ProductCount.ToString();
                cmbCategory.SelectedItem = _product.ProductCategory;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new BO.Product
                {
                    ProductId = _product?.ProductId ?? 0,
                    ProductName = txtName.Text,
                    ProductCategory = (BO.ProductsCategories)cmbCategory.SelectedItem,
                    ProductPrice = double.Parse(txtPrice.Text),
                    ProductCount = int.Parse(txtCount.Text)
                };

                if (_product == null)
                    _bl.Product.Create(product);
                else
                    _bl.Product.Update(product);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }
        }
    }
}