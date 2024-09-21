using System.ComponentModel.DataAnnotations.Schema; 
namespace WebApplication1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string Address {  get; set; }
        [ForeignKey(nameof(Department))]
        public int dept_id { get; set; }
        public Department? Department { get; set; }  
        [ForeignKey(nameof(Course))]
        public int course_id { get; set; }
        public Course? Course { get; set; }
    }
}
