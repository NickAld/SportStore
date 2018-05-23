using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportsStore.Domain.Abstract
{
    using SportsStore.Domain.Entities;
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }

        bool SaveProduct(Product product);

        Product DeleteProduce(int productId);
    }
}
