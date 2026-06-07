using System;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI.Forms
{
    public partial class SaleForm : Form
    {
        private readonly IBl _bl;
        private readonly Sale? _sale;

        public SaleForm(IBl bl, Sale? sale = null)
        {
            _bl = bl;
            _sale = sale;
            InitializeComponent();

            if (_sale != null)
                LoadForEdit();
        }

        private void LoadForEdit()
        {
            txtProductId.Text = _sale!.ProductId.ToString();
            txtCount.Text = _sale.ProductsCountToSale.ToString();
            txtPrice.Text = _sale.PriceAfterSale.ToString();
            chkClub.Checked = _sale.OnlyClubCustomers;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var sale = new Sale
                {
                    SaleId = _sale?.SaleId ?? 0,
                    ProductId = int.Parse(txtProductId.Text),
                    ProductsCountToSale = int.Parse(txtCount.Text),
                    PriceAfterSale = double.Parse(txtPrice.Text),
                    OnlyClubCustomers = chkClub.Checked,
                    DateStart = _sale?.DateStart,
                    DateEnd = _sale?.DateEnd
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