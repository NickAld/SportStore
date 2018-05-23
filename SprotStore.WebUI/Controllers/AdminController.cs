using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using SportsStore.Domain.Entities;
    using SportsStore.Domain.Abstract;

    public class AdminController : Controller
    {
        // GET: Admin

        IProductsRepository productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ActionResult Index()
        {
            return View(productsRepository.Products);
        }
    }
}