using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address {  get; set; }
        public int Grade {  get; set; }
        public List<crsResult>? CrsResults { get; set; }
        [ForeignKey(nameof(Department))]
        public int dept_id {  get; set; }
        public Department? Department { get; set; }
    }
}
