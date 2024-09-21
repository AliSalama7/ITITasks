using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;
namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IGenericRepository<Instructor> instructorRepository;
        private readonly IGenericRepository<Department> deptRepository;
        private readonly IGenericRepository<Course> courseRepository;

        public InstructorController(IGenericRepository<Instructor> instructorRepository , IGenericRepository<Department> deptRepository
            , IGenericRepository<Course> courseRepository)
        {
            this.instructorRepository = instructorRepository;
            this.deptRepository = deptRepository;
            this.courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = instructorRepository.Join(new[] { "Department", "Course" });
            return View(instructors);
        }
        public IActionResult Add()
        {
            List<Department> Departments = deptRepository.GetAll();
            List<Course> courses = courseRepository.GetAll();
            DeptAndCourseListsViewModel viewModel = new DeptAndCourseListsViewModel();
            viewModel.Courses = courses;
            viewModel.Departments = Departments;
            return View("Add" , viewModel);
        }
        [HttpPost]
        public IActionResult SaveAdd(Instructor newInstructor)
        {
            if(newInstructor != null)
            {
                instructorRepository.Add(newInstructor);
                instructorRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Add");
        }
        public IActionResult Edit(int id) 
        {
            var EmpModel = instructorRepository.GetById(id);
            List<Department> Departments = deptRepository.GetAll();
            List<Course> courses = courseRepository.GetAll();
            InstructorDeptAndCrsViewModel viewModel = new InstructorDeptAndCrsViewModel();
            viewModel.Id = EmpModel.Id;
            viewModel.Name = EmpModel.Name;
            viewModel.ImageUrl = EmpModel.ImageUrl;
            viewModel.Address = EmpModel.Address;
            viewModel.course_id = EmpModel.course_id;
            viewModel.dept_id = EmpModel.dept_id;
            viewModel.Salary = EmpModel.Salary;
            viewModel.Courses = courses;
            viewModel.Departments = Departments;    
            return View("Edit" , viewModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id , InstructorDeptAndCrsViewModel viewModel)
        {
            if(viewModel != null)
            {
                var InstructorFromDb = instructorRepository.GetById(id);
                if (InstructorFromDb != null)
                {
                    InstructorFromDb.Name = viewModel.Name;
                    InstructorFromDb.Salary = viewModel.Salary;
                    InstructorFromDb.Address = viewModel.Address;
                    InstructorFromDb.course_id = viewModel.course_id;
                    InstructorFromDb.dept_id = viewModel.dept_id;
                    InstructorFromDb.ImageUrl = viewModel.ImageUrl;
                    instructorRepository.Save();
                }
                return RedirectToAction("Index");
            }
            return View("Edit", viewModel);
        }
    }
}
