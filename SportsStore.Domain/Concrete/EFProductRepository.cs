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

        public Product DeleteProduce(int productId)
        {
            try
            {
                var product = context.Products.FirstOrDefault(x => x.ProductID == productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    return product;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                if (product.ProductID <= 0)
                    context.Products.Add(product);
                else
                {
                    var forRefresh = context.Products.Find(product.ProductID);
                    if (forRefresh != null)
                        context.Entry(forRefresh).CurrentValues.SetValues(product);
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
