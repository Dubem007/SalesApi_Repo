using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Seeder
    {
        public static void Seed(this SalesContext salesContext)
        {
            if (!salesContext.Products.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<Product>(product => product.Without(p => p.ProductId));
                //--- The next two lines add 100 rows to your database
                List<Product> products = fixture.CreateMany<Product>(100).ToList();
                salesContext.AddRange(products);
                salesContext.SaveChanges();
            }
        }
    }
}
