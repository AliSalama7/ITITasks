using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Course> courseRepository;

        public HomeController(ILogger<HomeController> logger , IGenericRepository<Course> courseRepository)
        {
            _logger = logger;
            this.courseRepository = courseRepository;
        }

        public IActionResult Index(string searchString)
        {
            List<Course> courses = courseRepository.Join(new[] {"Instructors" , "Department"});
            ViewData["CurrentFilter"] = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(courses);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
