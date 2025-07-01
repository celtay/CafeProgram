using OfficeOpenXml; // EPPlus kütüphanesi için gerekli
using Receipt.FilesControlPanel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Receipt
{
    //tayfun Celebi
    public partial class Form1 : Form
    {
        private decimal totalPrice = 0;
        private bool adminMode = false;
        private const string JsonFilePath = "products.json";
        private List<string> employees = new List<string>(); // Çalışan listesi
        private const string EmployeeFilePath = "Files/Employee.txt";
        private MenuNewScreen menuNewScreen;
        private bool guncellemeModu = false;
        private List<TextBox> stokTextBoxlari = new List<TextBox>();


        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            //test license
            //test2

            // EPPlus lisans bağlamını ayarla
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // MenuNewScreen formunu oluştur ve göster
            menuNewScreen = new MenuNewScreen();
            menuNewScreen.Show();
            // Ürünleri yükle ve MenuNewScreen formuna aktar
            List<Product> products = LoadProducts();
            menuNewScreen.LoadProducts(products);
            LoadEmployees();
            totalPrice = SharedData.TotalPrice;
            labelTotalPrice.Text = $"{totalPrice:C}";
            SharedData.TotalPrice = 0;
            StokTextBoxlariDoldur();
            StokVerileriniYukle();

        }
        public static class SharedData
        {
            public static List<OrderItem> Siparisler = new List<OrderItem>();
            public static decimal TotalPrice = 0;
        }

        private void StokTextBoxlariDoldur()
        {
            for (int i = 1; i <= 50; i++)
            {
                TextBox tb = Controls.Find("sid" + i, true).FirstOrDefault() as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = true;
                    stokTextBoxlari.Add(tb);
                }
            }
        }

        private void StokVerileriniYukle()
        {
            string filePath = Path.Combine(Application.StartupPath, "Files", "stoksave.xlsx");

            // Eğer dosya yoksa fonksiyondan çık
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Stok verisi bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet stokWs = package.Workbook.Worksheets["Stoklar"];

                // Eğer "Stoklar" sayfası yoksa çık
                if (stokWs == null)
                {
                    MessageBox.Show("Excel'de 'Stoklar' çalışma sayfası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int rowCount = stokWs.Dimension?.Rows ?? 0;

                // Eğer satır yoksa çık
                if (rowCount < 2) return;

                // Excel'deki stok verilerini ilgili TextBox'lara ata
                for (int i = 2; i <= rowCount; i++)
                {
                    string stokAdi = stokWs.Cells[i, 1].Text;  // Örn: "sid1"
                    string stokMiktari = stokWs.Cells[i, 2].Text;

                    TextBox tb = Controls.Find(stokAdi, true).FirstOrDefault() as TextBox;
                    if (tb != null)
                    {
                        tb.Text = stokMiktari;
                    }
                }
            }
        }

        private List<Product> LoadProducts()
        {
            List<Product> products;

            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                products = new List<Product>
                {
                    new Product { Id = 1, Name = "Türk Kahvesi\n(Küçük)", Price = 10.0m, type = 1, Price2 = 12.0m },
                    new Product { Id = 2, Name = "Türk Kahvesi\n(Büyük)", Price = 10.0m, type = 1, Price2 = 12.0m },
                    new Product { Id = 3, Name = "Damla Sakızlı\nTürk Kahvesi (K)", Price = 10.0m, type = 1, Price2 = 10.0m },
                    new Product { Id = 4, Name = "Damla Sakızlı\nTürk Kahvesi (B)", Price = 10.0m, type = 1, Price2 = 10.0m },
                    new Product { Id = 5, Name = "Sütlü Türk Kahvesi\n(Küçük)", Price = 10.0m, type = 1, Price2 = 10.0m },
                    new Product { Id = 6, Name = "Sütlü Türk Kahvesi\n(Büyük)", Price = 10.0m, type = 1, Price2 = 10.0m },
                    new Product { Id = 7, Name = "Menengiç Kahvesi", Price = 12.0m, type = 1, Price2 = 12.0m },
                    new Product { Id = 8, Name = "Espresso (Küçük)", Price = 15.0m, type = 1, Price2 = 15.0m },
                    new Product { Id = 9, Name = "Espresso (Büyük)", Price = 15.0m, type = 1, Price2 = 15.0m },
                    new Product { Id = 10, Name = "Americano (Küçük)", Price = 15.0m, type = 1, Price2 = 15.0m },
                    new Product { Id = 11, Name = "Americano (Büyük)", Price = 15.0m, type = 1, Price2 = 15.0m },
                    new Product { Id = 12, Name = "Latte (Küçük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 13, Name = "Latte (Büyük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 14, Name = "Chia Tea Latte\n(Küçük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 15, Name = "Chia Tea Latte\n(Büyük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 16, Name = "Pumpkin Spice\nLatte (Küçük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 17, Name = "Pumpkin Spice\nLatte (Büyük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 18, Name = "Filtre Kahve\n(Küçük)", Price = 14.0m, type = 1, Price2 = 14.0m },
                    new Product { Id = 19, Name = "Filtre Kahve\n(Büyük)", Price = 14.0m, type = 1, Price2 = 14.0m },
                    new Product { Id = 20, Name = "Cafe Mista\n(Küçük)", Price = 14.0m, type = 1, Price2 = 14.0m },
                    new Product { Id = 21, Name = "Cafe Mista\n(Büyük)", Price = 14.0m, type = 1, Price2 = 14.0m },
                    new Product { Id = 22, Name = "Cappuccino (Küçük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 23, Name = "Cappuccino (Büyük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 24, Name = "Black Mocha\n(Küçük)", Price = 20.0m, type = 1, Price2 = 20.0m },
                    new Product { Id = 25, Name = "Black Mocha\n(Büyük)", Price = 20.0m, type = 1, Price2 = 20.0m },
                    new Product { Id = 26, Name = "White Mocha\n(Küçük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 27, Name = "White Mocha\n(Büyük)", Price = 18.0m, type = 1, Price2 = 18.0m },
                    new Product { Id = 28, Name = "Caramel Macchiato\n(Küçük)", Price = 22.0m, type = 1, Price2 = 22.0m },
                    new Product { Id = 29, Name = "Caramel Macchiato\n(Büyük)", Price = 22.0m, type = 1, Price2 = 22.0m },
                    new Product { Id = 30, Name = "Flat White\n(Küçük)", Price = 22.0m, type = 1, Price2 = 22.0m },
                    new Product { Id = 31, Name = "Flat White\n(Büyük)", Price = 22.0m, type = 1, Price2 = 22.0m },
                    new Product { Id = 32, Name = "Ice Latte", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 33, Name = "Ice Filtre", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 34, Name = "Ice Cafe Mista", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 35, Name = "Ice Flat White", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 36, Name = "Ice Chai Tea\nLatte", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 37, Name = "Ice Americano", Price = 15.0m, type = 2, Price2 = 15.0m },
                    new Product { Id = 38, Name = "Ice Cappuccino", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 39, Name = "Ice Caramel Mocha", Price = 22.0m, type = 2, Price2 = 22.0m },
                    new Product { Id = 40, Name = "Ice Black Mocha", Price = 22.0m, type = 2, Price2 = 22.0m },
                    new Product { Id = 41, Name = "Ice White Mocha", Price = 22.0m, type = 2, Price2 = 22.0m },
                    new Product { Id = 42, Name = "Antep Fıstıklı Latte", Price = 20.0m, type = 2, Price2 = 20.0m },
                    new Product { Id = 43, Name = "Cold Brew", Price = 18.0m, type = 2, Price2 = 18.0m },
                    new Product { Id = 44, Name = "Demleme Çay", Price = 8.0m, type = 3, Price2 = 8.0m },
                    new Product { Id = 45, Name = "Melisa Çayı", Price = 10.0m, type = 3, Price2 = 10.0m },
                    new Product { Id = 46, Name = "Ada Çayı", Price = 10.0m, type = 3, Price2 = 10.0m },
                    new Product { Id = 47, Name = "Ihlamur Çayı", Price = 10.0m, type = 3, Price2 = 10.0m },
                    new Product { Id = 48, Name = "Atom Çayı", Price = 12.0m, type = 3, Price2 = 12.0m },
                    new Product { Id = 49, Name = "Sahlep (Küçük)", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 50, Name = "Sahlep (Büyük)", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 51, Name = "Klasik Sıcak\nÇikolata (Küçük)", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 52, Name = "Klasik Sıcak\nÇikolata (Büyük)", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 53, Name = "Beyaz Sıcak\nÇikolata (Küçük)", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 54, Name = "Beyaz Sıcak\nÇikolata (Büyük)", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 55, Name = "Muzlu Süt", Price = 12.0m, type = 4, Price2 = 12.0m },
                    new Product { Id = 56, Name = "Muzlu Çilekli Süt", Price = 12.0m, type = 4, Price2 = 12.0m },
                    new Product { Id = 57, Name = "Muzlu Nutellalı Süt", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 58, Name = "Muzlu Fıstıklı Süt", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 59, Name = "Çilekli Süt", Price = 15.0m, type = 3, Price2 = 15.0m },
                    new Product { Id = 60, Name = "Atom", Price = 15.0m, type = 4, Price2 = 15.0m },
                    new Product { Id = 61, Name = "Azzurro (Mavi)", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 62, Name = "Rosso (Kırmızı)", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 63, Name = "Verde (Yeşil)", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 64, Name = "Karışık İtalyan\nSoda", Price = 18.0m, type = 4, Price2 = 18.0m},
                    new Product { Id = 65, Name = "Çilekli Milk Shake", Price = 20.0m, type = 4, Price2 = 20.0m },
                    new Product { Id = 66, Name = "Frambuazlı\nMilk Shake", Price = 20.0m, type = 4, Price2 = 20.0m },
                    new Product { Id = 67, Name = "Çikolatalı\nMilk Shake", Price = 20.0m, type = 4, Price2 = 20.0m },
                    new Product { Id = 68, Name = "Muzlu\nMilk Shake", Price = 20.0m, type = 4, Price2 = 20.0m },
                    new Product { Id = 69, Name = "Espresso\nMilk Shake", Price = 22.0m, type = 4, Price2 = 22.0m },
                    new Product { Id = 70, Name = "Cool Lime", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 71, Name = "Cool Berry", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 72, Name = "Limonata", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 73, Name = "Coca Cola", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 74, Name = "Cola Zero", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 75, Name = "Fanta", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 76, Name = "Ice Tea", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 77, Name = "Soda", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 78, Name = "Su", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 79, Name = "Külah", Price = 25.0m, type = 6, Price2 = 25.0m },
                    new Product { Id = 80, Name = "Cornet", Price = 25.0m, type = 6, Price2 = 25.0m },
                    new Product { Id = 81, Name = "Bardak", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 82, Name = "Affan Haytalı", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 83, Name = "Bardak Waffle", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 84, Name = "Dilim Pasta", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 85, Name = "Ekler", Price = 18.0m, type = 4, Price2 = 18.0m },
                    new Product { Id = 86, Name = "Sos", Price = 18.0m, type = 4, Price2 = 18.0m }
                };

                SaveProductsToJson(products);
            }

            foreach (var product in products)
            {
                AddProductToUI(product);
            }

            return products;
        }
        private void AddProductToUI(Product product)
        {
            menu productControl = new menu
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
                //ImagePath = product.ImagePath
            };

            productControl.ProductButtonClick += (sender, e) =>
            {
                if (adminMode)
                {
                    // Admin modunda fiyat değiştirme işlemi
                    UpdatePriceForm updateForm = new UpdatePriceForm(product);
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        product.Price = updateForm.NewPrice;
                        UpdateProductPriceInJson(product.Name, product.Price);
                        // FlowLayoutPanel'deki ürün fiyatını güncelle
                        productControl.ProductPrice = product.Price;
                    }
                }
                else
                {
                    if (comboBoxEmployees.SelectedItem == null)
                    {
                        MessageBox.Show("Çalışan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (musteriname.Text == "")
                    {
                        MessageBox.Show("Müşteri ismi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var orderItem = new OrderItem
                    {
                        ProductName = product.Name,
                        Price = product.Price,
                        ID = product.Id
                    };

                    // FlowLayoutPanel'e sipariş öğesini ekle
                    flpOrders.Controls.Add(orderItem);

                    // Toplam fiyatı güncelle
                    totalPrice += product.Price;
                    labelTotalPrice.Text = $"{totalPrice:C}";

                    // MenuNewScreen formunda siparişleri güncelle
                    // SharedData sınıfını güncelle
                    SharedData.Siparisler.Add(orderItem);
                    SharedData.TotalPrice += product.Price;
                    menuNewScreen.LoadOrders();

                    orderItem.RemoveClicked += (s, args) =>
                    {
                        flpOrders.Controls.Remove(orderItem);
                        SharedData.Siparisler.Remove(orderItem);
                        SharedData.TotalPrice -= product.Price;
                        totalPrice -= product.Price;
                        labelTotalPrice.Text = $"{totalPrice:C}";

                        // MenuNewScreen formunda siparişleri güncelle
                        menuNewScreen.LoadOrders();
                    };
                }
            };

            flowLayoutPanel1.Controls.Add(productControl);
        }

        private void StokGuncelleByOrder(OrderItem orderItem)
        {
            switch (orderItem.ID)
            {
                case 1:
                    StokGuncelle("sid2", 10);
                    StokGuncelle("sid47", 1);
                    break;
                case 2:
                    StokGuncelle("sid2", 20);
                    StokGuncelle("sid48", 1);
                    break;
                case 3:
                    StokGuncelle("sid2", 10);
                    StokGuncelle("sid47", 1);
                    break;
                case 4:
                    StokGuncelle("sid2", 20);
                    StokGuncelle("sid48", 1);
                    break;
                case 5:
                    StokGuncelle("sid2", 10);
                    StokGuncelle("sid47", 1);
                    break;
                case 6:
                    StokGuncelle("sid2", 20);
                    StokGuncelle("sid48", 1);
                    break;
                case 7:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid3", 20);
                    StokGuncelle("sid4", 200);
                    break;
                case 8:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid1", 15);
                    break;
                case 9:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 30);
                    break;
                case 10:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid1", 30);
                    break;
                case 11:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid1", 60);
                    break;
                case 12:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid4", 200);
                    break;
                case 13:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 30);
                    StokGuncelle("sid4", 300);
                    break;
                case 14://Chia Tea Latte kucuk
                    StokGuncelle("sid47", 1);
                    break;
                case 15:// buyuk chia tea latte
                    StokGuncelle("sid48", 1);
                    break;
                case 16://pumpkin spice latte kucuk
                    StokGuncelle("sid47", 1);
                    break;
                case 17://pumpkin spice latte buyuk
                    StokGuncelle("sid48", 1);
                    break;
                case 18:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid1", 20);
                    break;
                case 19:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 30);
                    break;
                case 20://cafe mista kucuk
                    StokGuncelle("sid47", 1);
                    break;
                case 21://cafe mista buyuk
                    StokGuncelle("sid48", 1);
                    break;
                case 22:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid1", 20);
                    break;
                case 23:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 30);
                    break;
                case 24:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid4", 200);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid5", 15);
                    break;
                case 25:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 300);
                    StokGuncelle("sid1", 30);
                    StokGuncelle("sid5", 30);
                    break;
                case 26://white mocha kucuk
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid4", 200);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid5", 15);
                    break;
                case 27://white mocha buyuk
                    StokGuncelle("sid48", 1); // buyuk bardak
                    StokGuncelle("sid4", 300); // sut
                    StokGuncelle("sid1", 30); //cekirdek kahve
                    StokGuncelle("sid5", 30); //cikolata sosu
                    break;
                case 28:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid4", 200);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid5", 15);
                    break;
                case 29:
                    StokGuncelle("sid48", 1); // buyuk bardak
                    StokGuncelle("sid4", 300); // sut
                    StokGuncelle("sid1", 30); //cekirdek kahve
                    StokGuncelle("sid5", 30); //cikolata sosu
                    break;
                case 30: //flat white kucuk
                    StokGuncelle("sid47", 1);
                    break;
                case 31: //flat white buyuk
                    StokGuncelle("sid48", 1);
                    break;
                case 32:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 15);
                    break;
                case 33://ice filtre
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 15);
                    break;
                case 34://ice cafe mista
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 15);
                    break;
                case 35://ice flat white
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 15);
                    break;
                case 36://ice chai tea latte
                    StokGuncelle("sid48", 1);
                    break;
                case 37:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 30);
                    break;
                case 38:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 15);
                    break;
                case 39:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid5", 10); //cikolata sosu
                    StokGuncelle("sid7", 30); //caramel sosu
                    break;
                case 40://ice black mocha
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid5", 10); //cikolata sosu
                    break;
                case 41://ice white mocha
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 15);
                    StokGuncelle("sid6", 15); //beyaz cikolata sosu                    
                    break;
                case 42:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid1", 10);
                    StokGuncelle("sid8", 30);//antep fıstigi sosu
                    break;
                case 43:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid1", 30);
                    break;
                case 44:
                    StokGuncelle("sid9", 10); //Çay
                    StokGuncelle("sid26", 2); // Küp Şeker
                    StokGuncelle("sid42", 1); // karıştırıcı
                    break;
                case 45:
                    StokGuncelle("sid10", 15); //melisa çayı
                    break;
                case 46:
                    StokGuncelle("sid11", 15); //ada çayı
                    break;
                case 47:
                    StokGuncelle("sid12", 15); //ıhlamur çayı
                    break;
                case 48:
                    StokGuncelle("sid13", 1); //atom çayı
                    break;
                case 49:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid4", 200);
                    StokGuncelle("sid14", 3);
                    StokGuncelle("sid27", 30);
                    break;
                case 50:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid14", 4);
                    StokGuncelle("sid27", 40);
                    break;
                case 51:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid4", 200);
                    StokGuncelle("sid15", 20);
                    break;
                case 52:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid15", 25);
                    break;
                case 53:
                    StokGuncelle("sid47", 1);
                    StokGuncelle("sid4", 200);
                    StokGuncelle("sid6", 20);//beyaz çikolata sosu
                    break;
                case 54:
                    StokGuncelle("sid48", 1);
                    StokGuncelle("sid4", 250);
                    StokGuncelle("sid6", 25);//beyaz çikolata sosu
                    break;
                case 55:
                    StokGuncelle("sid4", 150);//süt
                    StokGuncelle("sid49", 100);//donmuş süt
                    StokGuncelle("sid32", 1);//muz
                    StokGuncelle("sid27", 20); // toz şeker
                    break;
                case 56:
                    StokGuncelle("sid4", 150);//süt
                    StokGuncelle("sid49", 100);//donmuş süt
                    StokGuncelle("sid32", 1);//muz
                    StokGuncelle("sid27", 20); // toz şeker
                    StokGuncelle("sid22", 50); // çilekli sos
                    break;
                case 57://muzlu nutellalı süt
                    StokGuncelle("sid4", 150);//süt
                    StokGuncelle("sid49", 100);//donmuş süt
                    StokGuncelle("sid32", 1);//muz
                    StokGuncelle("sid27", 20); // toz şeker
                    break;
                case 58://muzlu fıstıklı süt
                    StokGuncelle("sid4", 150);//süt
                    StokGuncelle("sid49", 100);//donmuş süt
                    StokGuncelle("sid32", 1);//muz
                    StokGuncelle("sid27", 20); // toz şeker
                    break;
                case 59:
                    StokGuncelle("sid4", 150);//süt
                    StokGuncelle("sid49", 100);//donmuş süt                    
                    StokGuncelle("sid27", 20); // toz şeker
                    StokGuncelle("sid22", 50); // çilekli sos
                    break;
                case 60:
                    StokGuncelle("sid4", 150);//süt
                    StokGuncelle("sid49", 100);//donmuş süt
                    StokGuncelle("sid32", 0.5);//muz
                    StokGuncelle("sid27", 20); // toz şeker
                    StokGuncelle("sid22", 25); // çilekli sos
                    StokGuncelle("sid29", 15); // fındık
                    StokGuncelle("sid30", 15); // badem
                    break;
                case 61:
                    StokGuncelle("sid16", 45); // mavi frambuazlı surup
                    StokGuncelle("sid36", 1); // limonlu soda
                    break;
                case 62:
                    StokGuncelle("sid17", 45); // kırmızı frambuazlı surup
                    StokGuncelle("sid37", 1); // limonlu soda
                    break;
                case 63:
                    StokGuncelle("sid19", 45); // elma surubu
                    StokGuncelle("sid38", 1); // elmalı soda
                    break;
                case 64://karisik italyan soda
                    StokGuncelle("sid50", 50); // karışık şurup
                    break;
                case 65://cilekli milk shake
                    break;
                case 66://frambuazlı milk shake
                    break;
                case 67://cikolatali milk shake
                    break;
                case 68://muzlu milk shake
                    break;
                case 69://espresso milk shake
                    break;
                case 70:
                    StokGuncelle("sid20", 45); // cool lime özü
                    break;
                case 71:
                    StokGuncelle("sid21", 45); // cool berry özü
                    break;
                case 72:
                    break;
                case 73:
                    break;
                case 74:
                    break;
                case 75:
                    break;
                case 76:
                    break;
                case 77:
                    break;
                case 78:
                    break;
                case 79:
                    StokGuncelle("sid24", 1); //külah
                    break;
                case 80:
                    StokGuncelle("sid25", 1); //külah cornet
                    break;
                case 81:
                    break;
                case 82:
                    break;
                case 83:
                    StokGuncelle("sid39", 50); // waffle hamuru
                    StokGuncelle("sid46", 45); //çikolata
                    StokGuncelle("sid40", 1); //çatal
                    StokGuncelle("sid48", 1); //bıçak
                    break;
                case 84:
                    break;
                case 85:
                    break;
                case 86:
                    break;
                default:
                    MessageBox.Show($"Bilinmeyen ürün ID: {orderItem.ID}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void StokGuncelle(string stokAdi, double miktar)
        {
            TextBox tb = Controls.Find(stokAdi, true).FirstOrDefault() as TextBox;
            if (tb != null && double.TryParse(tb.Text, out double mevcutMiktar))
            {
                tb.Text = (mevcutMiktar + miktar).ToString();
            }
        }

        private void ExcelKaydet()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo("Files/stoksave.xlsx")))
            {
                ExcelWorksheet stokWs;

                // 'Stoklar' çalışma sayfasını oluştur veya al
                if (package.Workbook.Worksheets["Stoklar"] == null)
                {
                    stokWs = package.Workbook.Worksheets.Add("Stoklar");
                    stokWs.Cells[1, 1].Value = "Stok Adı";
                    stokWs.Cells[1, 2].Value = "Miktar";
                }
                else
                {
                    stokWs = package.Workbook.Worksheets["Stoklar"];
                }

                // Stok verilerini yaz
                for (int i = 0; i < stokTextBoxlari.Count; i++)
                {
                    stokWs.Cells[i + 2, 1].Value = "sid" + (i + 1);
                    stokWs.Cells[i + 2, 2].Value = stokTextBoxlari[i].Text;
                }

                package.Save();
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            if (labelTotalPrice.Text != "₺0,00")
            {
                using (paymentypeselection paymentForm = new paymentypeselection())
                {
                    int formWidth = this.Width;
                    int formHeight = this.Height;
                    paymentForm.StartPosition = FormStartPosition.CenterScreen;
                    paymentForm.Location = new Point(flpOrders.Location.X, flpOrders.Location.Y); // İstediğiniz konumu buraya

                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPaymentType = paymentForm.SelectedPaymentType;
                        string selectedEmployee = comboBoxEmployees.SelectedItem.ToString(); // ComboBox'tan seçili elemanı al
                        string customerName = musteriname.Text;

                        // Siparişleri FlowLayoutPanel'e aktar
                        List<OrderItem> orders = new List<OrderItem>();
                        foreach (OrderItem item in flpOrders.Controls)
                        {
                            orders.Add(item);
                            StokGuncelleByOrder(item);
                        }

                        ExcelKaydet();

                        // Excel dosyasına yazma işlemi
                        try
                        {
                            using (ExcelPackage package = new ExcelPackage(new FileInfo("Orders.xlsx")))
                            {
                                ExcelWorksheet siparislerWs;
                                ExcelWorksheet gunlukToplamWs;
                                ExcelWorksheet aylikToplamWs;

                                // 'Siparişler' çalışma sayfasını oluştur veya al
                                if (package.Workbook.Worksheets["Siparişler"] == null)
                                {
                                    siparislerWs = package.Workbook.Worksheets.Add("Siparişler");
                                    siparislerWs.Cells[1, 2].Value = "Tarih";
                                    siparislerWs.Cells[1, 3].Value = "Eleman";
                                    siparislerWs.Cells[1, 4].Value = "Toplam";
                                    siparislerWs.Cells[1, 5].Value = "Ödeme Yöntemi";
                                }
                                else
                                {
                                    siparislerWs = package.Workbook.Worksheets["Siparişler"];
                                }

                                // 'Günlük Toplam' çalışma sayfasını oluştur veya al
                                if (package.Workbook.Worksheets["Günlük Toplam"] == null)
                                {
                                    gunlukToplamWs = package.Workbook.Worksheets.Add("Günlük Toplam");
                                    gunlukToplamWs.Cells[1, 2].Value = "Tarih";
                                    gunlukToplamWs.Cells[1, 3].Value = "Kart Ödeme";
                                    gunlukToplamWs.Cells[1, 4].Value = "Nakit Ödeme";
                                    gunlukToplamWs.Cells[1, 5].Value = "Toplam";
                                }
                                else
                                {
                                    gunlukToplamWs = package.Workbook.Worksheets["Günlük Toplam"];
                                }

                                // 'Aylık Toplam' çalışma sayfasını oluştur veya al
                                if (package.Workbook.Worksheets["Aylık Toplam"] == null)
                                {
                                    aylikToplamWs = package.Workbook.Worksheets.Add("Aylık Toplam");
                                    aylikToplamWs.Cells[1, 2].Value = "Ay";
                                    aylikToplamWs.Cells[1, 3].Value = "Kart Ödeme";
                                    aylikToplamWs.Cells[1, 4].Value = "Nakit Ödeme";
                                    aylikToplamWs.Cells[1, 5].Value = "Toplam";
                                }
                                else
                                {
                                    aylikToplamWs = package.Workbook.Worksheets["Aylık Toplam"];
                                }

                                // 'Siparişler' çalışma sayfasına veri ekle
                                int row = siparislerWs.Dimension?.End.Row + 1 ?? 2;
                                siparislerWs.Cells[row, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                siparislerWs.Cells[row, 3].Value = selectedEmployee; // Seçili elemanı yaz
                                siparislerWs.Cells[row, 4].Value = totalPrice;
                                siparislerWs.Cells[row, 5].Value = selectedPaymentType;

                                // Günlük toplamları güncelleme
                                string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                                int dailyRow = -1;

                                for (int i = 2; i <= gunlukToplamWs.Dimension.End.Row; i++)
                                {
                                    if (gunlukToplamWs.Cells[i, 2].Value?.ToString() == currentDate)
                                    {
                                        dailyRow = i;
                                        break;
                                    }
                                }

                                if (dailyRow == -1)
                                {
                                    dailyRow = gunlukToplamWs.Dimension.End.Row + 1;
                                    gunlukToplamWs.Cells[dailyRow, 2].Value = currentDate;
                                }

                                if (selectedPaymentType == "Kart")
                                {
                                    gunlukToplamWs.Cells[dailyRow, 3].Value = (gunlukToplamWs.Cells[dailyRow, 3].Value == null ? 0 : Convert.ToDouble(gunlukToplamWs.Cells[dailyRow, 3].Value)) + Convert.ToDouble(totalPrice);
                                }
                                else if (selectedPaymentType == "Nakit")
                                {
                                    gunlukToplamWs.Cells[dailyRow, 4].Value = (gunlukToplamWs.Cells[dailyRow, 4].Value == null ? 0 : Convert.ToDouble(gunlukToplamWs.Cells[dailyRow, 4].Value)) + Convert.ToDouble(totalPrice);
                                }

                                gunlukToplamWs.Cells[dailyRow, 5].Value = (gunlukToplamWs.Cells[dailyRow, 5].Value == null ? 0 : Convert.ToDouble(gunlukToplamWs.Cells[dailyRow, 5].Value)) + Convert.ToDouble(totalPrice);

                                // Aylık toplamları güncelleme
                                string currentMonth = DateTime.Now.ToString("MM/yyyy");
                                int monthlyRow = -1;

                                for (int i = 2; i <= aylikToplamWs.Dimension.End.Row; i++)
                                {
                                    if (aylikToplamWs.Cells[i, 2].Value?.ToString() == currentMonth)
                                    {
                                        monthlyRow = i;
                                        break;
                                    }
                                }

                                if (monthlyRow == -1)
                                {
                                    monthlyRow = aylikToplamWs.Dimension.End.Row + 1;
                                    aylikToplamWs.Cells[monthlyRow, 2].Value = currentMonth;
                                }

                                if (selectedPaymentType == "Kart")
                                {
                                    aylikToplamWs.Cells[monthlyRow, 3].Value = (aylikToplamWs.Cells[monthlyRow, 3].Value == null ? 0 : Convert.ToDouble(aylikToplamWs.Cells[monthlyRow, 3].Value)) + Convert.ToDouble(totalPrice);
                                }
                                else if (selectedPaymentType == "Nakit")
                                {
                                    aylikToplamWs.Cells[monthlyRow, 4].Value = (aylikToplamWs.Cells[monthlyRow, 4].Value == null ? 0 : Convert.ToDouble(aylikToplamWs.Cells[monthlyRow, 4].Value)) + Convert.ToDouble(totalPrice);
                                }

                                aylikToplamWs.Cells[monthlyRow, 5].Value = (aylikToplamWs.Cells[monthlyRow, 5].Value == null ? 0 : Convert.ToDouble(aylikToplamWs.Cells[monthlyRow, 5].Value)) + Convert.ToDouble(totalPrice);

                                package.Save();

                                var orderControl = new controlOrders
                                {
                                    CustomerName = customerName,
                                    ProductNames = orders.Select(o => o.ProductName).ToList()
                                };
                                flpCurrentOrders.Controls.Add(orderControl);
                            }
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Excel dosyası açık. Lütfen dosyayı kapatın ve tekrar deneyin.\n\nHata mesajı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Listeyi temizle ve toplamı sıfırla
                        musteriname.Text = "";
                        flpOrders.Controls.Clear();
                        totalPrice = 0;
                        labelTotalPrice.Text = $"{totalPrice:C}";

                        //MEnuNewscreen deki siparisleri sil ve ücreti sıfırla
                        SharedData.Siparisler.Clear();
                        SharedData.TotalPrice = 0;
                        menuNewScreen.LoadOrders();

                        // Mevcut Siparişler sayfasına geç
                        tabControl1.SelectedTab = tabPage2;





                    }
                }
            }
        }
        private void LoadEmployees()
        {

            EnsureEmployeeDirectoryExists();
            if (File.Exists(EmployeeFilePath))
            {
                employees = new List<string>(File.ReadAllLines(EmployeeFilePath));
            }
            comboBoxEmployees.Items.Clear();
            foreach (var employee in employees)
            {
                comboBoxEmployees.Items.Add(employee);
            }
        }
        private void EnsureEmployeeDirectoryExists()
        {
            if (!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }
        }
        private void SaveProductsToJson(List<Product> products)
        {
            string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, json);
        }
        private void clearorderlist_Click(object sender, EventArgs e)
        {
            // FlowLayoutPanel'deki tüm öğeleri sil
            flpOrders.Controls.Clear();

            //MEnuNewscreen deki siparisleri sil ve ücreti sıfırla
            SharedData.Siparisler.Clear();
            SharedData.TotalPrice = 0;
            menuNewScreen.LoadOrders();

            // Toplam fiyatı sıfırla
            totalPrice = 0;
            labelTotalPrice.Text = $"{totalPrice:C}";
        }
        private void UpdateProductPriceInJson(string productName, decimal newPrice)
        {
            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                var products = JsonSerializer.Deserialize<List<Product>>(json);

                foreach (var product in products)
                {
                    if (product.Name == productName)
                    {
                        product.Price = newPrice;
                        break;
                    }
                }

                SaveProductsToJson(products);
            }
        }
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            if (adminMode)
            {
                adminMode = false;
                MessageBox.Show("Admin modu kapalı.");
                UpdateButtonColors();
            }
            else
            {
                using (var form = new LoginForm())
                {
                    if (form.ShowDialog() == DialogResult.OK && form.IsAuthenticated)
                    {
                        adminMode = true;
                        MessageBox.Show("Admin modu aktif.");
                        UpdateButtonColors();
                    }
                }
            }
        }
        private void UpdateButtonColors()
        {

            // Admin modu butonunun rengini güncelle
            buttonAdmin.BackColor = adminMode ? Color.Green : System.Drawing.Color.Transparent;
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int type { get; set; }
            public decimal Price2 { get; set; }
        }
        private void buttonManageEmployees_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeForm(employees))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees(); // Çalışan listesini güncelle
                }
            }
        }
        private void menuscreenopen_Click(object sender, EventArgs e)
        {
            // Formun adı "MenuNewScreen" olarak varsayılmıştır
            string formName = "MenuNewScreen";

            // Formun açık olup olmadığını kontrol et
            bool isFormOpen = Application.OpenForms.Cast<Form>().Any(f => f.Name == formName);

            if (isFormOpen)
            {
                // Form açıksa butonun çalışmasını engelle
                MessageBox.Show("MenuNewScreen formu zaten açık.");
            }
            else
            {
                Form1_Load(sender, e);
                /* // Form açık değilse formu aç
                 MenuNewScreen menuNewScreen = new MenuNewScreen();
                 menuNewScreen.Show();

                 // Ürünleri yükle ve MenuNewScreen formuna aktar
                 List<Product> products = LoadProducts();
                 menuNewScreen.LoadProducts(products);
                 SharedData.TotalPrice = 0;*/

            }
        }
        private void guncelleButton_Click(object sender, EventArgs e)
        {
            guncellemeModu = !guncellemeModu; // Güncelleme modunu tersine çevir (Aç/Kapat)

            foreach (var tb in stokTextBoxlari)
            {
                tb.ReadOnly = !guncellemeModu; // ReadOnly durumunu güncelle
            }

            if (!guncellemeModu) // Eğer güncelleme modu kapatılıyorsa (Kaydetme zamanı)
            {
                ExcelKaydet(); // Excel'e kaydet
                MessageBox.Show("Stok verileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
