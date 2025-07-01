using Receipt.MenuScreenDatas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Receipt.Form1;


namespace Receipt.FilesControlPanel
{
    public partial class MenuNewScreen : Form
    {

        private const string JsonFilePath = "products.json";
        public MenuNewScreen()
        {
            InitializeComponent();
            this.Resize += new EventHandler(MenuNewScreen_Resize);
            //AttachResizeEventHandlers();
            LoadOrders();
        }

        private void MenuNewScreen_Resize(object sender, EventArgs e)
        {
            int totalWidth = this.ClientSize.Width - 306 - 30; // Formun genişliği            

            int totalPanelWidth = panel1.Width + panel2.Width + panel3.Width + panel4.Width;
            int availableWidth = totalWidth - totalPanelWidth;
            int dynamicSpacing = availableWidth / 3; // 3 boşluk var

            panel2.Left = panel1.Right + dynamicSpacing;
            panel3.Left = panel2.Right + dynamicSpacing;
            panel4.Left = panel3.Right + dynamicSpacing;
            panel5.Left = panel2.Right + dynamicSpacing;
            panel6.Left = panel3.Right + dynamicSpacing;

        }

        public void LoadProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                AddProductToPanel(product);
            }
        }

        public void LoadOrders()
        {
            showordersflowpanel.Controls.Clear();

            foreach (var orderItem in SharedData.Siparisler)
            {
                var siparisControl = new menusiparislist
                {
                    ProductName = orderItem.ProductName,
                    Price = $"{orderItem.Price:C}"
                };

                showordersflowpanel.Controls.Add(siparisControl);
            }

            toplamnumberlabel.Text = $"{SharedData.TotalPrice:C}";
        }

        private void AddProductToPanel(Product product)
        {
            // Ürünü ID'sine göre ilgili FlowLayoutPanel'e ekleyin
            FlowLayoutPanel targetPanel = null;

            switch (product.Id)
            {
                case 1:
                    pid1.Text = $"{product.Price:C}";
                    break;
                case 2:
                    pid2.Text = $"{product.Price:C}";
                    break;
                case 3:
                    pid3.Text = $"{product.Price:C}";
                    break;
                case 4:
                    pid4.Text = $"{product.Price:C}";
                    break;
                case 5:
                    pid5.Text = $"{product.Price:C}";
                    break;
                case 6:
                    pid6.Text = $"{product.Price:C}";
                    break;
                case 7:
                    pid7.Text = $"{product.Price:C}";
                    break;
                case 8:
                    pid8.Text = $"{product.Price:C}";
                    break;
                case 9:
                    pid9.Text = $"{product.Price:C}";
                    break;
                case 10:
                    pid10.Text = $"{product.Price:C}";
                    break;
                case 11:
                    pid11.Text = $"{product.Price:C}";
                    break;
                case 12:
                    pid12.Text = $"{product.Price:C}";
                    break;
                case 13:
                    pid13.Text = $"{product.Price:C}";
                    break;
                case 14:
                    pid14.Text = $"{product.Price:C}";
                    break;
                case 15:
                    pid15.Text = $"{product.Price:C}";
                    break;
                case 16:
                    pid16.Text = $"{product.Price:C}";
                    break;
                case 17:
                    pid17.Text = $"{product.Price:C}";
                    break;
                case 18:
                    pid18.Text = $"{product.Price:C}";
                    break;
                case 19:
                    pid19.Text = $"{product.Price:C}";
                    break;
                case 20:
                    pid20.Text = $"{product.Price:C}";
                    break;
                case 21:
                    pid21.Text = $"{product.Price:C}";
                    break;
                case 22:
                    pid22.Text = $"{product.Price:C}";
                    break;
                case 23:
                    pid23.Text = $"{product.Price:C}";
                    break;
                case 24:
                    pid24.Text = $"{product.Price:C}";
                    break;
                case 25:
                    pid25.Text = $"{product.Price:C}";
                    break;
                case 26:
                    pid26.Text = $"{product.Price:C}";
                    break;
                case 27:
                    pid27.Text = $"{product.Price:C}";
                    break;
                case 28:
                    pid28.Text = $"{product.Price:C}";
                    break;
                case 29:
                    pid29.Text = $"{product.Price:C}";
                    break;
                case 30:
                    pid30.Text = $"{product.Price:C}";
                    break;
                case 31:
                    pid31.Text = $"{product.Price:C}";
                    break;
                case 32:
                    pid32.Text = $"{product.Price:C}";
                    break;
                case 33:
                    pid33.Text = $"{product.Price:C}";
                    break;
                case 34:
                    pid34.Text = $"{product.Price:C}";
                    break;
                case 35:
                    pid35.Text = $"{product.Price:C}";
                    break;
                case 36:
                    pid36.Text = $"{product.Price:C}";
                    break;
                case 37:
                    pid37.Text = $"{product.Price:C}";
                    break;
                case 38:
                    pid38.Text = $"{product.Price:C}";
                    break;
                case 39:
                    pid39.Text = $"{product.Price:C}";
                    break;
                case 40:
                    pid40.Text = $"{product.Price:C}";
                    break;
                case 41:
                    pid41.Text = $"{product.Price:C}";
                    break;
                case 42:
                    pid42.Text = $"{product.Price:C}";
                    break;
                case 43:
                    pid43.Text = $"{product.Price:C}";
                    break;
                case 44:
                    pid44.Text = $"{product.Price:C}";
                    break;
                case 45:
                    pid45.Text = $"{product.Price:C}";
                    break;
                case 46:
                    pid46.Text = $"{product.Price:C}";
                    break;
                case 47:
                    pid47.Text = $"{product.Price:C}";
                    break;
                case 48:
                    pid48.Text = $"{product.Price:C}";
                    break;
                case 49:
                    pid49.Text = $"{product.Price:C}";
                    break;
                case 50:
                    pid50.Text = $"{product.Price:C}";
                    break;
                case 51:
                    pid51.Text = $"{product.Price:C}";
                    break;
                case 52:
                    pid52.Text = $"{product.Price:C}";
                    break;
                case 53:
                    pid53.Text = $"{product.Price:C}";
                    break;
                case 54:
                    pid54.Text = $"{product.Price:C}";
                    break;
                case 55:
                    pid55.Text = $"{product.Price:C}";
                    break;
                case 56:
                    pid56.Text = $"{product.Price:C}";
                    break;
                case 57:
                    pid57.Text = $"{product.Price:C}";
                    break;
                case 58:
                    pid58.Text = $"{product.Price:C}";
                    break;
                case 59:
                    pid59.Text = $"{product.Price:C}";
                    break;
                case 60:
                    pid60.Text = $"{product.Price:C}";
                    break;
                case 61:
                    pid61.Text = $"{product.Price:C}";
                    break;
                case 62:
                    pid62.Text = $"{product.Price:C}";
                    break;
                case 63:
                    pid63.Text = $"{product.Price:C}";
                    break;
                case 64:
                    pid64.Text = $"{product.Price:C}";
                    break;
                case 65:
                    pid65.Text = $"{product.Price:C}";
                    break;
                case 66:
                    pid66.Text = $"{product.Price:C}";
                    break;
                case 67:
                    pid67.Text = $"{product.Price:C}";
                    break;
                case 68:
                    pid68.Text = $"{product.Price:C}";
                    break;
                case 69:
                    pid69.Text = $"{product.Price:C}";
                    break;
                case 70:
                    pid70.Text = $"{product.Price:C}";
                    break;
                case 71:
                    pid71.Text = $"{product.Price:C}";
                    break;
                case 72:
                    pid72.Text = $"{product.Price:C}";
                    break;
                case 73:
                    pid73.Text = $"{product.Price:C}";
                    break;
                case 74:
                    pid74.Text = $"{product.Price:C}";
                    break;
                case 75:
                    pid75.Text = $"{product.Price:C}";
                    break;
                case 76:
                    pid76.Text = $"{product.Price:C}";
                    break;
                case 77:
                    pid77.Text = $"{product.Price:C}";
                    break;
                case 78:
                    pid78.Text = $"{product.Price:C}";
                    break;
                case 79:
                    pid79.Text = $"{product.Price:C}";
                    break;
                case 80:
                    pid80.Text = $"{product.Price:C}";
                    break;
                case 81:
                    pid81.Text = $"{product.Price:C}";
                    break;
                case 82:
                    pid82.Text = $"{product.Price:C}";
                    break;
                case 83:
                    pid83.Text = $"{product.Price:C}";
                    break;
                case 84:
                    pid84.Text = $"{product.Price:C}";
                    break;
                case 85:
                    pid85.Text = $"{product.Price:C}";
                    break;
            }

        }
    }

}

