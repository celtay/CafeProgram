using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Receipt.FilesControlPanel
{
    public partial class controlOrders : UserControl
    {
        public string CustomerName
        {
            get => getisim.Text;
            set => getisim.Text = value;
        }

        public List<string> ProductNames
        {
            set
            {
                siparislistbox.Items.Clear();
                foreach (var productName in value)
                {
                    siparislistbox.Items.Add($"1 x {productName}");
                    siparislistbox.Items.Add("");
                }
            }
        }

        public controlOrders()
        {
            InitializeComponent();
            //teslimbutton.Click += Teslimbutton_Click;
        }

        private void Teslimbutton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void hazirbutton_Click(object sender, EventArgs e)
        {
            hazirbutton.FillColor = System.Drawing.Color.Green;
        }
    }
}
