using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using SportsStore.Domain.Entities;
    using SportsStore.Domain.Abstract;

    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin

        IProductsRepository productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ViewResult Index()
        {
            return View(productsRepository.Products);
        }

        
        public ViewResult Edit(int? productId)
        {
            if (productId == null)
                productId = productsRepository.Products.FirstOrDefault().ProductID;
            var product = productsRepository.Products.First(x => x.ProductID == productId);
            if (product == null)
                ModelState.AddModelError("", "Товар не найден");

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image!=null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                if (productsRepository.SaveProduct(product))
                {
                    TempData["message"] = string.Format("{0} has been saved", product.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = string.Format("{0} Изменения не сохранены", product.Name);
                    ModelState.AddModelError("", "Изменения не сохранены");
                    return View(product);
                }
            }
            else
                return View(product);
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var result = productsRepository.DeleteProduce(productId);
            if (result!=null)
                TempData["message"] = string.Format("{0} was deleted", result.Name);
            return RedirectToAction("Index");
        }
    }

    
}