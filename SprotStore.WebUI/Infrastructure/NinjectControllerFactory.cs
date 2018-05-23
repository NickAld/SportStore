using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using System.Configuration;
using SportsStore.Domain.Concrete;

using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;


namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory, IDisposable
    {
        private IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        private void AddBindingsMock()
        {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product{Name="Football", Price=25},
            //    new Product { Name = "Surf board", Price = 179 },
            //    new Product { Name = "Running shoes", Price = 95 }
            //}.AsQueryable());

            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
        }
        private void AddBindings()
        {
            kernel.Bind<IProductsRepository>().To<SportsStore.Domain.Concrete.EFProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)kernel.Get(controllerType);
        }

        public void Dispose()
        {
            if (kernel!=null)
                kernel.Dispose();
        }
    }
}