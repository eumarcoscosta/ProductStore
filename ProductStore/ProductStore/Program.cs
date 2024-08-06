using System;
using System.Globalization;
using ProductStore.Entities;

namespace WhichProduct
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=1; i<=n; i++)
            {
                Console.WriteLine($"Product #{i} data");
                Console.Write("Common, used or imported (c/u/i)? ");
                char types = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (types == 'i' || types == 'I')
                {
                    Console.Write("Customs fee: ");
                    double fees = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    ImportedProduct importedProduct = new ImportedProduct(fees, name, price);
                    list.Add(importedProduct);

                } else if (types == 'c'|| types == 'C')
                {
                    Product product = new Product(name, price);
                    list.Add(product);

                } else if (types == 'u'|| types == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manuDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    UsedProduct usedProduct = new UsedProduct(manuDate, name, price);
                    list.Add(usedProduct);
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        } 
    }
}