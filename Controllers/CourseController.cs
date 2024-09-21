using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;
namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        private readonly IGenericRepository<Course> courseRepository;
        private readonly IGenericRepository<Department> departmentRepository;
        private readonly IGenericRepository<crsResult> crsResultRepository;
        private readonly IGenericRepository<Trainee> traineeRepository;

        public CourseController(IGenericRepository<Course> courseRepository , IGenericRepository<Department> departmentRepository, 
            IGenericRepository<crsResult> crsResultRepository, IGenericRepository<Trainee> traineeRepository)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository  = departmentRepository;
            this.crsResultRepository = crsResultRepository;
            this.traineeRepository = traineeRepository;
        }
        public IActionResult Add()
        {
            CoursewithDeptListViewModel viewModel = new CoursewithDeptListViewModel();
            viewModel.Departments = departmentRepository.GetAll();
            return View("CourseForm",viewModel);
        }
        public JsonResult CompareDegree(decimal minDegree, decimal Degree) 
        {
            if (Degree < minDegree) 
                return Json(false);
            return Json(true);
        }
        public IActionResult SaveAdd(CoursewithDeptListViewModel viewModel) 
        {
            if(!ModelState.IsValid)
            {
                viewModel.Departments = departmentRepository.GetAll();
                return View("CourseForm", viewModel);
            }
            var course = new Course()
            {
                Name = viewModel.Name,
                Hours = viewModel.Hours,
                dept_id = viewModel.dept_id,
                MinDegree = viewModel.MinDegree,
                Degree = viewModel.Degree
            };
            courseRepository.Add(course);
            courseRepository.Save();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Edit(int id)
        {
            var course = courseRepository.GetById(id);
            var depts = departmentRepository.GetAll();
            CoursewithDeptListViewModel viewModel = new CoursewithDeptListViewModel
            {
                Id = id,
                Departments = depts,
                dept_id = course.dept_id,
                Name = course.Name,
                Hours = course.Hours,
                MinDegree = course.MinDegree,
                Degree = course.Degree
            };
            return View("CourseForm", viewModel);
        }
        public IActionResult SaveEdit(int id,CoursewithDeptListViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                viewModel.Departments = departmentRepository.GetAll();
                return View("CourseForm", viewModel);
            }
            var coursefromDb = courseRepository.GetById(id);
            if (coursefromDb != null) 
            {
                coursefromDb.Hours = viewModel.Hours;
                coursefromDb.MinDegree = viewModel.MinDegree;
                coursefromDb.Degree = viewModel.Degree;
                coursefromDb.Name = viewModel.Name;
                coursefromDb.dept_id = viewModel.dept_id;
                courseRepository.Save();
            }
            return RedirectToAction("Index","Home");   
        }
        public IActionResult ShowCourseResults(int id)
        {
            var crsResults = (from crs in courseRepository.GetAll()
                              join crsRes in crsResultRepository.GetAll() on crs.Id equals crsRes.crs_id
                              join t in traineeRepository.GetAll() on crsRes.trainee_id equals t.Id
                              where (crs.Id == id)
                              select new
                              {
                                  CourseName = crs.Name,
                                  TraineeName = t.Name,
                                  CourseMinDegree = crs.MinDegree,
                                  Degree = crsRes.TraineeDegree
                              }).ToList();
            CrsResultViewModel model = new CrsResultViewModel();
            foreach (var crs in crsResults)
            {
                model.Degrees.Add(crs.Degree);
                model.TraineesNames.Add(crs.TraineeName);
                model.CourseName = crs.CourseName;
                model.Colors.Add(crs.Degree > crs.CourseMinDegree ? "green" : "red");
            }
            return View("CourseResult", model);
        }
    }
}
