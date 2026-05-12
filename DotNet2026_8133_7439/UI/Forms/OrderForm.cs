//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;
//using BlApi;
//using BO;

//namespace UI.Forms
//{
//    public partial class OrderForm : Form
//    {
//        private readonly IBl _bl;
//        private readonly Order _order = new Order();

//        public OrderForm(IBl bl)
//        {
//            _bl = bl;
//            InitializeComponent();
//            dgvOrderItems.AutoGenerateColumns = false;
//            if (_order.ProductInOrder == null) _order.ProductInOrder = new System.Collections.Generic.List<ProductInOrder>();
//            RefreshOrderView();
//            LoadProducts();
//        }

//        private void LoadProducts()
//        {
//            var list = _bl.Product.ReadAll();
//            cmbProducts.DataSource = list.Where(p => p != null).Select(p => p!).ToList();
//            cmbProducts.DisplayMember = "ProductName";
//            cmbProducts.ValueMember = "ProductId";
//        }

//        private void RefreshOrderView()
//        {
//            dgvOrderItems.DataSource = (_order.ProductInOrder ?? new List<ProductInOrder>()).Select(p => new { p.ProductId, p.ProductName, p.Count, p.FinalPrice }).ToList();
//            lblTotal.Text = _order.TotalPrice.ToString("C");
//        }

//        private void btnAddByCode_Click(object sender, EventArgs e)
//        {
//            if (!int.TryParse(txtProductCode.Text, out var id))
//            {
//                MessageBox.Show(this, "Invalid product code");
//                return;
//            }
//            AddProductToOrder(id, (int)numCount.Value);
//        }

//        private void btnAddBySelect_Click(object sender, EventArgs e)
//        {
//            if (cmbProducts.SelectedItem == null) return;
//            var p = (Product)cmbProducts.SelectedItem;
//            AddProductToOrder(p.ProductId, (int)numCount.Value);
//        }

//        private void AddProductToOrder(int productId, int count)
//        {
//            try
//            {
//                var sales = _bl.Order.AddProductToOrder(_order, productId, count);
//                // BL updates order.ProductsInOrder and calculates totals according to architecture
//                RefreshOrderView();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(this, "Error adding product: " + ex.Message);
//            }
//        }

//        private void btnDoOrder_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                _bl.Order.DoOrder(_order);
//                MessageBox.Show(this, "Order completed");
//                (_order.ProductInOrder ?? new List<ProductInOrder>()).Clear();
//                RefreshOrderView();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(this, "Error completing order: " + ex.Message);
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI.Forms
{
    public partial class OrderForm : Form
    {
        private readonly IBl _bl;
        private readonly Order _order = new Order();

        public OrderForm(IBl bl)
        {
            _bl = bl;
            InitializeComponent();

            dgvOrderItems.AutoGenerateColumns = false;

            _order.ProductInOrder = new List<ProductInOrder>();

            LoadProducts();
            RefreshOrderView();
        }

        private void LoadProducts()
        {
            var list = _bl.Product.ReadAll()
                .Where(p => p != null)
                .Select(p => p!)
                .ToList();

            cmbProducts.DataSource = list;
            cmbProducts.DisplayMember = "ProductName";
            cmbProducts.ValueMember = "ProductId";
        }

        private void RefreshOrderView()
        {
            dgvOrderItems.DataSource =
                (_order.ProductInOrder ?? new List<ProductInOrder>())
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.Count,
                    p.FinalPrice
                })
                .ToList();

            lblTotal.Text = _order.TotalPrice.ToString("C");
        }

        private void btnAddByCode_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductCode.Text, out int id))
            {
                MessageBox.Show("Invalid product code");
                return;
            }

            AddProduct(id);
        }

        private void btnAddBySelect_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is not Product p)
            {
                MessageBox.Show("Select a product");
                return;
            }

            AddProduct(p.ProductId);
        }

        private void AddProduct(int productId)
        {
            try
            {
                if (numCount.Value <= 0)
                {
                    MessageBox.Show("Quantity must be greater than 0");
                    return;
                }

                _bl.Order.AddProductToOrder(_order, productId, (int)numCount.Value);

                RefreshOrderView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            try
            {
                _bl.Order.DoOrder(_order);

                MessageBox.Show("Order completed");

                _order.ProductInOrder.Clear();
                _order.TotalPrice = 0;

                RefreshOrderView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error completing order: " + ex.Message);
            }
        }

        private void numCount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}