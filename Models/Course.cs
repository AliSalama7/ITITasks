using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree {  get; set; }
        public int Hours {  get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<crsResult>? CrsResults { get; set; }
        [ForeignKey(nameof(Department))]
        public int dept_id { get; set; }
        public Department? Department { get; set; }
    }
}
