using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SportsStore.WebUI.Controllers
{
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Models;
    public class ProductController : Controller
    {
        IProductsRepository productsRepository;
        public int pageSize = 2;
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public ViewResult List(string category,int page=1)
        {
            //return View(productsRepository.ProductsList);
            //return View(productsRepository.Products
            //    .OrderBy(x => x.ProductID)
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize));

            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = productsRepository.Products
                    .Where(x => category == null || x.Category.ToUpper().Equals(category.ToUpper()))
                    .OrderBy(x => x.ProductID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                pagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category==null? productsRepository.Products.Count()
                                                :productsRepository.Products.Where(x=>x.Category==category).Count()
                },
                CurrentCategory = category
                
            };

            
            return View(model);

        }

        public FileContentResult GetImage(int productId)
        {
            var product = productsRepository.Products.FirstOrDefault(x => x.ProductID == productId);
            if (product != null)
                return File(product.ImageData, product.ImageMimeType);
            else
                return null;
        }
    }
}