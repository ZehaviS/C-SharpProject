using System.Windows.Forms;

namespace UI
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel panelLeft;
        private Label lblAppTitle;
        private Label lblWelcome;
        private Button btnCustomers;
        private Button btnProducts;
        private Button btnSales;
        private Button btnOrder;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelLeft = new Panel();
            this.lblAppTitle = new Label();
            this.btnCustomers = new Button();
            this.btnProducts = new Button();
            this.btnSales = new Button();
            this.btnOrder = new Button();
            this.lblWelcome = new Label();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(165, 88, 54);
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Width = 260;
            this.panelLeft.Controls.Add(this.btnOrder);
            this.panelLeft.Controls.Add(this.btnSales);
            this.panelLeft.Controls.Add(this.btnProducts);
            this.panelLeft.Controls.Add(this.btnCustomers);
            this.panelLeft.Controls.Add(this.lblAppTitle);
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAppTitle.Text = "Sweet Bakery";
            // 
            // btnCustomers
            // 
            this.btnCustomers.FlatStyle = FlatStyle.Flat;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(255, 176, 109);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCustomers.Location = new System.Drawing.Point(20, 100);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(220, 50);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "👥 Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatStyle = FlatStyle.Flat;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(255, 194, 132);
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProducts.Location = new System.Drawing.Point(20, 165);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(220, 50);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "🥐 Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnSales
            // 
            this.btnSales.FlatStyle = FlatStyle.Flat;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.BackColor = System.Drawing.Color.FromArgb(224, 131, 70);
            this.btnSales.ForeColor = System.Drawing.Color.White;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSales.Location = new System.Drawing.Point(20, 230);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(220, 50);
            this.btnSales.TabIndex = 2;
            this.btnSales.Text = "💰 Sales";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.FlatStyle = FlatStyle.Flat;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(255, 149, 85);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrder.Location = new System.Drawing.Point(20, 295);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(220, 50);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "🛒 Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(92, 57, 42);
            this.lblWelcome.Location = new System.Drawing.Point(290, 120);
            this.lblWelcome.Size = new System.Drawing.Size(650, 120);
            this.lblWelcome.Text = "Welcome to the bakery dashboard. Choose a section to manage products, customers and sales in a warm bakery style.";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 235);
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.panelLeft);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bakery Dashboard";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
