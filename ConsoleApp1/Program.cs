using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Concrete;
    using SportsStore.Domain.Entities;
    class Program
    {
        static List<int> ports = new List<int>() { 25, 465, 587 };
        static void Main(string[] args)
        {
            var cart = new Cart();
            cart.AddItem(new Product()
            {
                ProductID = 1,
                Name = "TEST1",
                Price = 10
            }, 2);

            var persons = new ShippingDetails()
            {
                Name = "asdad",
                Address = "asdas",
                City = "asdas",
                GiftWrap = true
            };


            foreach (var port in ports)
            {
                var mail = new EmailOrderProcessor(new EmailSettings(port));
                try
                {
                    Console.WriteLine("Запуск для порта " + port);
                    mail.ProcessOrder(cart, persons);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Отправлено");

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                Console.ResetColor();

                Console.WriteLine("Завершено");
            }
            Console.ReadLine();
        }
    }
}
