namespace WebApplication1.ViewModels
{
    public class TraineeResultViewModel
    {
        public string TraineeName { get; set; }
        public List<string> CoursesNames {  get; set; }= new List<string>();
        public List<decimal> Degrees { get; set; } = new List<decimal>();
        public List<string> Colors { get; set; } = new List<string>();
    }
}
