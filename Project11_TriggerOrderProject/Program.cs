using Project11_TriggerOrderProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project11_TriggerOrderProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DbOrderEntities context = new DbOrderEntities();
            
            string number;

            Console.WriteLine("### Sipariş Stok Sistemi ###");
            Console.WriteLine();
            Console.WriteLine("1-Ürün Listesi");
            Console.WriteLine("2-Sipariş Listesi");
            Console.WriteLine("3-Kasa Durumu");
            Console.WriteLine("4-Yeni Ürün Satışı");
            Console.WriteLine("5-İşlem Sayacı");
            Console.WriteLine("6-Ürün Stok Güncelleme");
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            Console.Write("Lütfen yapmak istediğiniz işlemi seçin: ");
            number = Console.ReadLine();
            Console.WriteLine();
            if (number == "1")
            {
                Console.WriteLine("------ Ürün Listesi ------");
                var values = context.Products.ToList();
                foreach(var item in values)
                {
                    Console.WriteLine(item.Id + "-" + item.Name + " Stok Sayısı: " + item.Stock + " Fiyatı: " + item.Price + "₺");
                }
            }
            if (number == "2")
            {
                Console.WriteLine("------ Sipariş Listesi ------");
                var values = context.Orders.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine(item.Id + "-" + item.Products.Name + " Birim Fiyatı: " + item.UnitPrice + "₺" + " Adet Sayısı: " + item.Quantity + "Toplam Fiyat: " + item.TotalPrice + "₺");
                }
            }
            if (number == "3")
            {
                Console.WriteLine("------ Kasa Durumu ------");
                var values = context.CashRegisters.Select(x => x.Balance).FirstOrDefault();
                Console.WriteLine("Kasadaki Toplam Tutar: " + values + "₺");
                
            }
            if (number == "4")
            {
                Console.WriteLine("------ Yeni Sipariş Girişi ------");

                Console.Write("Müşteri Adı: ");
                string customer = Console.ReadLine();

                Console.Write("Ürün Id: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Ürün Adedi: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("------ Ürün Bilgileri ------");
                Console.WriteLine();

                var productName = context.Products.Where(x => x.Id == productId).Select(y => y.Name).FirstOrDefault();
                Console.WriteLine("Ürün Adı: " + productName);

                var productUnitPrice = context.Products.Where(x=>x.Id == productId).Select(y=>y.Price).FirstOrDefault();
                Console.WriteLine("Birim Fiyat: " + productUnitPrice + "₺");

                decimal totalPrice = quantity * decimal.Parse(productUnitPrice.ToString());
                Console.WriteLine("Toplam Fiyat: " + totalPrice + "₺");

                Console.WriteLine();
                Console.WriteLine("------ Ürün Bilgileri ------");

                Orders order = new Orders();
                order.UnitPrice = productUnitPrice;
                order.Quantity = quantity;
                order.Customer = customer;
                order.ProductId = productId;
                order.TotalPrice = totalPrice;
                context.Orders.Add(order);
                context.SaveChanges();

            }
            if(number == "5")
            {
                var value = context.Processes.Select(x => x.Process).FirstOrDefault();
                Console.WriteLine("Toplam İşlem Sayısı: " + value);
            }

            Console.ReadLine();

        }
    }
}
