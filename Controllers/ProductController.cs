using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductBL productBL = new ProductBL();
            List<Product> products = productBL.GetAll();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            ProductBL productBL = new ProductBL();
            Product product = productBL.GetById(id);
            return View(product);
        }
    }
}
