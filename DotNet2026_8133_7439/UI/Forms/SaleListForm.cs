using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI.Forms
{
    public partial class SaleListForm : Form
    {
        private readonly IBl _bl;

        public SaleListForm(IBl bl)
        {
            _bl = bl;
            InitializeComponent();
            LoadSales();
        }

        private void LoadSales(string? filter = null)
        {
            var list = _bl.Sale.ReadAll(
                filter == null
                ? null
                : new Func<Sale, bool>(s =>
                    s != null &&
                    s.SaleId.ToString().Contains(filter))
            );

            dgvSales.DataSource = list.Select(s => new
            {
                s.SaleId,
                s.ProductId,
                s.ProductsCountToSale,
                s.PriceAfterSale,
                s.OnlyClubCustomers,
                s.DateStart,
                s.DateEnd
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var text = string.IsNullOrWhiteSpace(txtFilter.Text)
                ? null
                : txtFilter.Text;

            LoadSales(text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new SaleForm(_bl); // αμι ID
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadSales(txtFilter.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;

            int id = (int)dgvSales.CurrentRow.Cells[0].Value;
            var sale = _bl.Sale.Read(id);
            if (sale == null) return;

            var f = new SaleForm(_bl, sale);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadSales(txtFilter.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;

            int id = (int)dgvSales.CurrentRow.Cells[0].Value;

            var result = MessageBox.Show(
                "Delete sale?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            _bl.Sale.Delete(id);
            LoadSales(txtFilter.Text);
        }
    }
}