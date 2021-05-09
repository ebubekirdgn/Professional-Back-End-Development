using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Nortwind.MvcWebUI.Models;
using System.Web.Mvc;

namespace DevFramework.Nortwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }


    }
}