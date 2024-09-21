using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public decimal TraineeDegree {  get; set; }
        [ForeignKey(nameof(Course))]
        public int crs_id {  get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(Trainee))]
        public int trainee_id {  get; set; }
        public Trainee Trainee { get; set; }
    }
}
