using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.WebUI.Controllers;
using ShoppingCart.Core.Contracts;
using ShoppingCart.Core.Models;
using System.Web.Mvc;
using ShoppingCart.Core.ViewModels;
using System.Linq;

namespace ShoppingCart.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCatgeoryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());

            HomeController controller = new HomeController(productContext, productCatgeoryContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());

        }
    }
}
