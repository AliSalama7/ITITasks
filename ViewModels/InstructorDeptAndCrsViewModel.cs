using WebApplication1.Models;
namespace WebApplication1.ViewModels
{
    public class InstructorDeptAndCrsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public int dept_id {  get; set; }
        public List<Department>? Departments { get; set; }
        public int course_id {  get; set; }
        public List<Course>? Courses { get; set; }
    }
}
