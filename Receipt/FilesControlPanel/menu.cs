using System;
using System.Windows.Forms;

namespace Receipt
{
    public partial class menu : UserControl
    {
        public string ProductName
        {
            get { return foodname.Text; }
            set { foodname.Text = value; }
        }

        public decimal ProductPrice
        {
            get { return decimal.Parse(gradientprice.Controls[0].Text); }
            set { gradientprice.Text = value.ToString("C"); }
        }

        public event EventHandler ProductButtonClick
        {
            add { guna2Button1.Click += value; }
            remove { guna2Button1.Click -= value; }
        }

        public menu()
        {
            InitializeComponent();
        }

        public void UpdatePriceDisplay()
        {
            // Ürün fiyatını güncelle ve arayüzde göster
            this.gradientprice.Text = $"{this.ProductPrice:C}";
        }

        private void menu_Load(object sender, EventArgs e)
        {
            foodname.MouseClick += (s, ev) => guna2Button1.PerformClick();
            gradientprice.MouseClick += (s, ev) => guna2Button1.PerformClick();
            guna2Panel1.MouseClick += (s, ev) => guna2Button1.PerformClick();
            guna2Button1.Controls.Add(foodname);
            guna2Button1.Controls.Add(gradientprice);

            // Fare üzerine geldiğinde ve ayrıldığında renk değiştirme olaylarını ekle
            foodname.MouseEnter += (s, ev) => ChangeLabelColorOnHover(foodname);
            gradientprice.MouseEnter += (s, ev) => ChangeLabelColorOnHover(gradientprice);

            foodname.MouseLeave += (s, ev) => ResetLabelColor(foodname);
            gradientprice.MouseLeave += (s, ev) => ResetLabelColor1(gradientprice);
        }

        private void ChangeLabelColorOnHover(Label label)
        {
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(200))))); // Fare üzerine geldiğinde kırmızı renk
        }

        private void ResetLabelColor(Label label)
        {
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(73))))); // Fare ayrıldığında siyah renk
        }
        private void ResetLabelColor1(Label label)
        {
            label.ForeColor = System.Drawing.Color.Purple; // Fare ayrıldığında siyah renk
        }
    }
}