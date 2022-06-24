using Desks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desks.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public DBContext _context;
        public ILogger _logger;
        public HomeControllerTest(DBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [TestMethod]
        public void TestView()
        {
            var controller = new HomeController(_context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            result = controller.Admin() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
