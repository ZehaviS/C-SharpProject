using System.Windows.Forms;

namespace UI.Forms
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbProducts;
        private NumericUpDown numCount;
        private Button btnAddBySelect;
        private TextBox txtProductCode;
        private Button btnAddByCode;
        private DataGridView dgvOrderItems;
        private Button btnDoOrder;
        private Label lblTotal;

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
            cmbProducts = new ComboBox();
            numCount = new NumericUpDown();
            btnAddBySelect = new Button();
            txtProductCode = new TextBox();
            btnAddByCode = new Button();
            dgvOrderItems = new DataGridView();
            btnDoOrder = new Button();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)numCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.Location = new Point(12, 12);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(300, 28);
            cmbProducts.TabIndex = 7;
            // 
            // numCount
            // 
            numCount.Location = new Point(324, 12);
            numCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCount.Name = "numCount";
            numCount.Size = new Size(60, 27);
            numCount.TabIndex = 6;
            numCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numCount.ValueChanged += numCount_ValueChanged;
            // 
            // btnAddBySelect
            // 
            btnAddBySelect.Location = new Point(390, 10);
            btnAddBySelect.Name = "btnAddBySelect";
            btnAddBySelect.Size = new Size(100, 26);
            btnAddBySelect.TabIndex = 5;
            btnAddBySelect.Text = "Add";
            btnAddBySelect.Click += btnAddBySelect_Click;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(12, 46);
            txtProductCode.Multiline = true;
            txtProductCode.Name = "txtProductCode";
            txtProductCode.PlaceholderText = "Product code";
            txtProductCode.Size = new Size(150, 23);
            txtProductCode.TabIndex = 4;
            // 
            // btnAddByCode
            // 
            btnAddByCode.Location = new Point(170, 48);
            btnAddByCode.Name = "btnAddByCode";
            btnAddByCode.Size = new Size(80, 26);
            btnAddByCode.TabIndex = 3;
            btnAddByCode.Text = "Add";
            btnAddByCode.Click += btnAddByCode_Click;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.ColumnHeadersHeight = 29;
            dgvOrderItems.Location = new Point(12, 80);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.RowHeadersWidth = 51;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.Size = new Size(596, 249);
            dgvOrderItems.TabIndex = 2;
            // 
            // btnDoOrder
            // 
            btnDoOrder.Location = new Point(12, 350);
            btnDoOrder.Name = "btnDoOrder";
            btnDoOrder.Size = new Size(100, 30);
            btnDoOrder.TabIndex = 1;
            btnDoOrder.Text = "Complete";
            btnDoOrder.Click += btnDoOrder_Click;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(520, 350);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 30);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "0.00";
            // 
            // OrderForm
            // 
            ClientSize = new Size(640, 400);
            Controls.Add(lblTotal);
            Controls.Add(btnDoOrder);
            Controls.Add(dgvOrderItems);
            Controls.Add(btnAddByCode);
            Controls.Add(txtProductCode);
            Controls.Add(btnAddBySelect);
            Controls.Add(numCount);
            Controls.Add(cmbProducts);
            Name = "OrderForm";
            Text = "Order";
            ((System.ComponentModel.ISupportInitialize)numCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
