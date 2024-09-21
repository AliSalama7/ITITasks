using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;
namespace WebApplication1.Controllers
{
    public class TraineeController : Controller
    {
        private readonly IGenericRepository<Course> courseRepository;
        private readonly IGenericRepository<crsResult> crsResultRepository;
        private readonly IGenericRepository<Trainee> traineeRepository;

        public TraineeController(IGenericRepository<Course> courseRepository, IGenericRepository<crsResult> crsResultRepository ,
            IGenericRepository<Trainee> traineeRepository)
        {
            this.courseRepository = courseRepository;
            this.crsResultRepository = crsResultRepository;
            this.traineeRepository = traineeRepository;
        }
        public IActionResult ShowResult(int Id , int crsId)
        {
            var courseDetails = (from crs in courseRepository.GetAll()
                                 join crsRes in crsResultRepository.GetAll() on crs.Id equals crsRes.crs_id
                                 join t in traineeRepository.GetAll() on crsRes.trainee_id equals t.Id
                                 where (t.Id == Id && crs.Id == crsId)
                                 select new
                                 {
                                     Degree = crsRes.TraineeDegree,
                                     CrsName = crs.Name,
                                     TraineeName = t.Name,
                                     CrsMinDegree = crs.MinDegree
                                 }).FirstOrDefault();
            TraineeCrsResultViewModel model = new TraineeCrsResultViewModel();
            if (courseDetails != null)
            {
                model.Degree = courseDetails.Degree;
                model.TraineeName = courseDetails.TraineeName;
                model.CourseName = courseDetails.CrsName;
                model.Color = courseDetails.Degree > courseDetails.CrsMinDegree ? "green" : "red";
            }     
                return View("Index",model);
        }
        public IActionResult ShowTraineeResult(int id)
        {
            var TraineeResults = (from crs in courseRepository.GetAll()
                                 join crsRes in crsResultRepository.GetAll() on crs.Id equals crsRes.crs_id
                                 join t in traineeRepository.GetAll() on crsRes.trainee_id equals t.Id
                                 where (t.Id == id)
                                 select new
                                 {
                                     Degree = crsRes.TraineeDegree,
                                     TraineeName = t.Name,
                                     crsMinDegree = crs.MinDegree,
                                     CourseName = crs.Name
                                 }).ToList();
            TraineeResultViewModel model = new TraineeResultViewModel();
            foreach(var trainee in TraineeResults)
            {
                model.Degrees.Add(trainee.Degree);
                model.CoursesNames.Add(trainee.CourseName);
                model.TraineeName = trainee.TraineeName;
                model.Colors.Add(trainee.Degree > trainee.crsMinDegree ? "green" : "red");
            }
            return View("TraineeResults",model);
        }
    }
}
