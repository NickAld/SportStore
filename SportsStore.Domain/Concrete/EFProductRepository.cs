using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : Abstract.IProductsRepository, IDisposable
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        //public IList<Product> ProductsList => context.Products.ToList();
        public IList<Product> ProductsList
        {
            get
            {
                var result = context.Products.ToList();
                return result;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
