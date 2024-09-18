using Project3_EntityFrameworkStatisticsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Project3_EntityFrameworkStatisticsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbStatisticEntities db = new DbStatisticEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Toplam kategori sayısı
            int categoryCount = db.Categories.Count();
            lblCategoryCount.Text = categoryCount.ToString();

            //Toplam ürün sayısı
            int productCount = db.Products.Count();
            lblProductCount.Text = productCount.ToString();

            //Toplam müşteri sayısı
            int customerCount = db.Customers.Count();
            lblCustomerCount.Text = customerCount.ToString();

            //Toplam sipariş sayısı
            int orderCount = db.Orders.Count();
            lblOrderCount.Text = orderCount.ToString();

            //Toplam stok sayısı
            var totalProductStockCount = db.Products.Sum(x=>x.Stock);
            lblProductTotalStock.Text = totalProductStockCount.ToString();

            //Ortalama ürün fiyatı
            var averageProductPrice = db.Products.Average(x=>x.Price);
            lblProductAveragePrice.Text = averageProductPrice.ToString() + "TL";

            //Toplam meyve stoğu
            var totalFruitStock = db.Products.Where(x => x.CategoryId == 1).Sum(y=>y.Stock);
            lblFruitCount.Text = totalFruitStock.ToString();

            //Bilgisayar isimli ürünün toplam işlem hacmi
            var totalPriceByComputerStock = db.Products.Where(x => x.Name == "Bilgisayar").Select(y=>y.Stock).FirstOrDefault();
            var totalPriceByComputerGetUnitStock = db.Products.Where(x => x.Name == "Bilgisayar").Select(y => y.Price).FirstOrDefault();
            var totalPrice = totalPriceByComputerGetUnitStock * totalPriceByComputerStock;
            lblTotalPriceByComputer.Text = totalPrice.ToString() + "TL";

            //Stok sayısı 100'den az olan ürün sayısı
            var productCountByStockCounterSmallerThan100 = db.Products.Where(x => x.Stock < 100).Count();
            lblProductStockSmallerThan100.Text = productCountByStockCounterSmallerThan100.ToString();

            // Kategorisi Kişisel Bakım ve durumu aktif olan ürün stok toplamı
            int id = db.Categories.Where(z => z.Name == "Kişisel Bakım").Select(y => y.Id).FirstOrDefault();
            var value = db.Products.Where(x => x.CategoryId == id && x.Status == true).Sum(y => y.Stock);
            lblProductCountByCategoryKisiselBakimAndStatusTrue.Text = value.ToString();

            //Türkiye'den verilen siparişler
            var customerIds = db.Customers.Where(x => x.Country == "Türkiye").Select(y => y.Id).ToList();
            var ordersFromTürkiye = db.Orders.Count(z => customerIds.Contains(z.CustomerId.Value));
            lblOrderCountFromTurkiye.Text = ordersFromTürkiye.ToString();

            //Kategorisi Meyve olan ürünlerin toplam satış fiyatı
            var orderTotalPriceByCategoryIsMeyve = db.Database.SqlQuery<decimal>("SELECT SUM(o.TotalPrice) as TotalPrice From Orders O JOIN Products p ON o.ProductId = p.Id JOIN Categories c ON c.Id = p.CategoryId WHERE c.Name = 'Meyve'").FirstOrDefault();
            lblTotalPriceByCategoryIsMeyve.Text = orderTotalPriceByCategoryIsMeyve.ToString() + "TL";


            //Kategorisi Meyve olan ürünlerin toplam satış fiyatı - EF
            var orderTotalPriceByCategoryIsMeyveByEF = (from o in db.Orders
                                                        join p in db.Products on o.ProductId equals p.Id
                                                        join c in db.Categories on p.CategoryId equals c.Id
                                                        where c.Name == "Meyve"
                                                        select o.TotalPrice).Sum();
            lblTotalPriceByCategoryIsMeyveByEF.Text = orderTotalPriceByCategoryIsMeyveByEF.ToString() + "TL";

            //Son eklenen ürünün adı
            var lastProductName = db.Products.OrderByDescending(x => x.Id).Select(y => y.Name).FirstOrDefault();
            lblLastProductName.Text = lastProductName.ToString();

            //Son eklenen ürün kategori adı
            var lastProductCategoryId = db.Products.OrderByDescending(x => x.Id).Select(y => y.CategoryId).FirstOrDefault();
            var lastProductCategoryName = db.Categories.Where(x => x.Id == lastProductCategoryId).Select(y=>y.Name).FirstOrDefault();
            lblLastProductCategoryName.Text = lastProductCategoryName.ToString();

            //Aktif ürün sayısı
            var activeProductCount = db.Products.Where(x => x.Status == true).Count();
            lblActiveProductCount.Text = activeProductCount.ToString();

            //Pasif ürün sayısı
            var passiveProductCount = db.Products.Where(x => x.Status == false).Count();
            lblPassiveProductCount.Text = passiveProductCount.ToString();

            //Toplam kola stok satışlarından kazanılan para
            var colaStock = db.Products.Where(x => x.Name == "Kola").Select(y => y.Stock).FirstOrDefault();
            var colaPrice = db.Products.Where(x => x.Name == "Kola").Select(y => y.Price).FirstOrDefault();
            var totalColaStockPrice = colaPrice * colaStock;
            lblTotalPriceWithStockByCola.Text = totalColaStockPrice.ToString();

            // Sisteme son sipariş veren müşteri adı
            var lastCustomerId = db.Orders.OrderByDescending(x => x.Id).Select(y => y.CustomerId).FirstOrDefault();
            var lastCustomerName = db.Customers.Where(x => x.Id == lastCustomerId).Select(y => y.Name).FirstOrDefault();
            lblLastCustomerName.Text = lastCustomerName.ToString();

            // Toplam ülke sayısı
            var countryCount = db.Customers.Select(x => x.Country).Distinct().Count();
            lblTotalCountryCount.Text = countryCount.ToString();
        }

    }
}
