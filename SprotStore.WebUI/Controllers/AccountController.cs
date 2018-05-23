using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using Infrastructure.Abstract;
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.LoginViewModel loginViewModel, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if (authProvider.Authenticate(loginViewModel.UserName, loginViewModel.UserPassword))
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                else
                    ModelState.AddModelError("","Некорректный пароль или имя пользователя");
            }

            return View();
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}