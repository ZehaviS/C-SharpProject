using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblHeader;
        private ComboBox cmbProducts;
        private NumericUpDown numCount;
        private Button btnAddBySelect;
        private TextBox txtProductCode;
        private Button btnAddByCode;
        private DataGridView dgvOrderItems;
        private Button btnDoOrder;
        private Label lblTotal;
        private Label lblTotalLabel;
        private Label lblDiscount;
        private Label lblDiscountLabel;

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
            this.panelHeader = new Panel();
            this.lblHeader = new Label();
            this.cmbProducts = new ComboBox();
            this.numCount = new NumericUpDown();
            this.btnAddBySelect = new Button();
            this.txtProductCode = new TextBox();
            this.btnAddByCode = new Button();
            this.dgvOrderItems = new DataGridView();
            this.btnDoOrder = new Button();
            this.lblTotal = new Label();
            this.lblTotalLabel = new Label();
            this.lblDiscount = new Label();
            this.lblDiscountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)this.numCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrderItems).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(191, 101, 45);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 80;
            this.panelHeader.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = false;
            this.lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Location = new Point(16, 20);
            this.lblHeader.Size = new Size(400, 40);
            this.lblHeader.Text = "🧺 Create Order";
            // 
            // cmbProducts
            // 
            this.cmbProducts.Location = new Point(16, 100);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new Size(320, 28);
            this.cmbProducts.TabIndex = 7;
            this.cmbProducts.BackColor = Color.FromArgb(255, 244, 235);
            this.cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // numCount
            // 
            this.numCount.Location = new Point(350, 100);
            this.numCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCount.Name = "numCount";
            this.numCount.Size = new Size(70, 28);
            this.numCount.TabIndex = 6;
            this.numCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCount.ValueChanged += numCount_ValueChanged;
            // 
            // btnAddBySelect
            // 
            this.btnAddBySelect.Location = new Point(430, 100);
            this.btnAddBySelect.Name = "btnAddBySelect";
            this.btnAddBySelect.Size = new Size(110, 28);
            this.btnAddBySelect.TabIndex = 5;
            this.btnAddBySelect.Text = "➕ Add";
            this.btnAddBySelect.FlatStyle = FlatStyle.Flat;
            this.btnAddBySelect.FlatAppearance.BorderSize = 0;
            this.btnAddBySelect.BackColor = Color.FromArgb(224, 131, 70);
            this.btnAddBySelect.ForeColor = Color.White;
            this.btnAddBySelect.Click += btnAddBySelect_Click;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new Point(16, 138);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.PlaceholderText = "Product code";
            this.txtProductCode.Size = new Size(200, 28);
            this.txtProductCode.TabIndex = 4;
            this.txtProductCode.BackColor = Color.FromArgb(255, 244, 235);
            this.txtProductCode.BorderStyle = BorderStyle.FixedSingle;
            // 
            // btnAddByCode
            // 
            this.btnAddByCode.Location = new Point(230, 138);
            this.btnAddByCode.Name = "btnAddByCode";
            this.btnAddByCode.Size = new Size(110, 28);
            this.btnAddByCode.TabIndex = 3;
            this.btnAddByCode.Text = "➕ Add";
            this.btnAddByCode.FlatStyle = FlatStyle.Flat;
            this.btnAddByCode.FlatAppearance.BorderSize = 0;
            this.btnAddByCode.BackColor = Color.FromArgb(255, 176, 109);
            this.btnAddByCode.ForeColor = Color.White;
            this.btnAddByCode.Click += btnAddByCode_Click;
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeight = 29;
            this.dgvOrderItems.Location = new Point(16, 180);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.Size = new Size(640, 180);
            this.dgvOrderItems.TabIndex = 2;
            this.dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItems.BackgroundColor = Color.FromArgb(255, 251, 244);
            this.dgvOrderItems.BorderStyle = BorderStyle.None;
            this.dgvOrderItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrderItems.EnableHeadersVisualStyles = false;
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(191, 101, 45);
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvOrderItems.RowTemplate.Height = 28;
            this.dgvOrderItems.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgvOrderItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 222, 190);
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Location = new Point(16, 370);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new Size(100, 25);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "Total:";
            this.lblTotalLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTotalLabel.ForeColor = Color.FromArgb(91, 49, 27);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new Point(120, 370);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(150, 25);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "0.00";
            this.lblTotal.ForeColor = Color.FromArgb(91, 49, 27);
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.Location = new Point(300, 370);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new Size(100, 25);
            this.lblDiscountLabel.TabIndex = 0;
            this.lblDiscountLabel.Text = "Discount:";
            this.lblDiscountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDiscountLabel.ForeColor = Color.FromArgb(91, 49, 27);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Location = new Point(400, 370);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new Size(150, 25);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "0.00";
            this.lblDiscount.ForeColor = Color.FromArgb(91, 49, 27);
            // 
            // btnDoOrder
            // 
            this.btnDoOrder.Location = new Point(560, 370);
            this.btnDoOrder.Name = "btnDoOrder";
            this.btnDoOrder.Size = new Size(96, 32);
            this.btnDoOrder.TabIndex = 1;
            this.btnDoOrder.Text = "Complete";
            this.btnDoOrder.FlatStyle = FlatStyle.Flat;
            this.btnDoOrder.FlatAppearance.BorderSize = 0;
            this.btnDoOrder.BackColor = Color.FromArgb(224, 131, 70);
            this.btnDoOrder.ForeColor = Color.White;
            this.btnDoOrder.Click += btnDoOrder_Click;
            // 
            // OrderForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 248, 235);
            this.ClientSize = new Size(680, 420);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblDiscountLabel);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnDoOrder);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.btnAddByCode);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.btnAddBySelect);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.cmbProducts);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "OrderForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)this.numCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrderItems).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}