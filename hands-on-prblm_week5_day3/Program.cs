using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };
        }
    }

    internal class Program
    {
        static void Main()
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // 1. FMCG Products
            Console.WriteLine("\nFMCG Products:");
            var fmcg = products.Where(x => x.ProCategory == "FMCG");
            foreach (var item in fmcg)
                Console.WriteLine(item.ProName);

            // 2. Grain Products
            Console.WriteLine("\nGrain Products:");
            var grain = products.Where(x => x.ProCategory == "Grain");
            foreach (var item in grain)
                Console.WriteLine(item.ProName);

            // 3. Sort by Product Code
            Console.WriteLine("\nSorted by Product Code:");
            var sortCode = products.OrderBy(x => x.ProCode);
            foreach (var item in sortCode)
                Console.WriteLine(item.ProCode + " - " + item.ProName);

            // 4. Sort by Category
            Console.WriteLine("\nSorted by Category:");
            var sortCategory = products.OrderBy(x => x.ProCategory);
            foreach (var item in sortCategory)
                Console.WriteLine(item.ProCategory + " - " + item.ProName);

            // 5. Sort by MRP Asc
            Console.WriteLine("\nSorted by MRP (Ascending):");
            var sortMrpAsc = products.OrderBy(x => x.ProMrp);
            foreach (var item in sortMrpAsc)
                Console.WriteLine(item.ProName + " - " + item.ProMrp);

            // 6. Sort by MRP Desc
            Console.WriteLine("\nSorted by MRP (Descending):");
            var sortMrpDesc = products.OrderByDescending(x => x.ProMrp);
            foreach (var item in sortMrpDesc)
                Console.WriteLine(item.ProName + " - " + item.ProMrp);

            // 7. Group by Category
            Console.WriteLine("\nGroup by Category:");
            var groupCategory = products.GroupBy(x => x.ProCategory);
            foreach (var group in groupCategory)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine("  " + item.ProName);
            }

            // 8. Group by MRP
            Console.WriteLine("\nGroup by MRP:");
            var groupMrp = products.GroupBy(x => x.ProMrp);
            foreach (var group in groupMrp)
            {
                Console.WriteLine("MRP: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine("  " + item.ProName);
            }

            // 9. Highest price FMCG
            Console.WriteLine("\nHighest Price FMCG:");
            var maxFmcg = products
                .Where(x => x.ProCategory == "FMCG")
                .OrderByDescending(x => x.ProMrp)
                .FirstOrDefault();

            if (maxFmcg != null)
                Console.WriteLine(maxFmcg.ProName + " - " + maxFmcg.ProMrp);

            // 10. Total count
            Console.WriteLine("\nTotal Products: " + products.Count());

            // 11. FMCG count
            Console.WriteLine("Total FMCG Products: " +
                products.Count(x => x.ProCategory == "FMCG"));

            // 12. Max price
            Console.WriteLine("\nMax Price: " +
                products.Max(x => x.ProMrp));

            // 13. Min price
            Console.WriteLine("Min Price: " +
                products.Min(x => x.ProMrp));

            // 14. All below 30
            Console.WriteLine("\nAll products below 30: " +
                products.All(x => x.ProMrp < 30));

            // 15. Any below 30
            Console.WriteLine("Any product below 30: " +
                products.Any(x => x.ProMrp < 30));

            Console.ReadLine();
        }
    }
}
