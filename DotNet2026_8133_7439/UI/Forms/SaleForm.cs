using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI.Forms
{
    public partial class SaleForm : Form
    {
        private readonly IBl _bl;
        private readonly Sale? _sale;
        private List<BO.Product?> _products = new();

        public SaleForm(IBl bl, Sale? sale = null)
        {
            _bl = bl;
            _sale = sale;
            InitializeComponent();

            LoadProducts();

            if (_sale != null)
                LoadForEdit();
            else
            {
                dtpDateStart.Value = DateTime.Now;
                dtpDateEnd.Value = DateTime.Now.AddMonths(1);
            }
        }

        private void LoadForEdit()
        {
            cmbProduct.DataSource = _products.Where(p => p != null).Select(p => p!).ToList();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductId";
            cmbProduct.SelectedItem = _products.FirstOrDefault(p => p?.ProductId == _sale!.ProductId);
            txtCount.Text = _sale.ProductsCountToSale.ToString();
            txtPrice.Text = _sale.PriceAfterSale.ToString();
            txtDiscount.Text = _sale.Discount.ToString();
            chkClub.Checked = _sale.OnlyClubCustomers;
            
            if (_sale.DateStart.HasValue)
                dtpDateStart.Value = _sale.DateStart.Value;
            else
                dtpDateStart.Value = DateTime.Now;
                
            if (_sale.DateEnd.HasValue)
                dtpDateEnd.Value = _sale.DateEnd.Value;
            else
                dtpDateEnd.Value = DateTime.Now.AddMonths(1);
        }

        private void LoadProducts()
        {
            _products = _bl.Product.ReadAll()
                .Where(p => p != null)
                .Select(p => p!)
                .ToList();

            cmbProduct.DataSource = _products;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductId";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduct.SelectedItem is not BO.Product selectedProduct)
                    throw new Exception("Please select a product");
                
                int productId = selectedProduct.ProductId;
                if (!int.TryParse(txtCount.Text, out int count))
                    throw new Exception("Count must be a valid number");
                
                if (!double.TryParse(txtPrice.Text, out double price))
                    throw new Exception("Price must be a valid number");
                
                if (!double.TryParse(txtDiscount.Text, out double discount))
                    throw new Exception("Discount must be a valid number");

                if (discount < 0 || discount > 100)
                    throw new Exception("Discount must be between 0 and 100");

                var sale = new Sale
                {
                    SaleId = _sale?.SaleId ?? 0,
                    ProductId = productId,
                    ProductsCountToSale = count,
                    PriceAfterSale = price,
                    Discount = discount,
                    OnlyClubCustomers = chkClub.Checked,
                    DateStart = dtpDateStart.Value,
                    DateEnd = dtpDateEnd.Value
                };

                if (_sale == null)
                    _bl.Sale.Create(sale);
                else
                {
                    _bl.Sale.Update(sale);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}