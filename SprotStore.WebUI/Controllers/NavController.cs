using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using SportsStore.Domain.Abstract;
    public class NavController : Controller
    {
        IProductsRepository productsRepository;
        public NavController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = productsRepository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}