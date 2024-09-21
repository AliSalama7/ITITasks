namespace WebApplication1.ViewModels
{
    public class CrsResultViewModel
    {
        public string CourseName {  get; set; }
        public List<string> TraineesNames {  get; set; } = new List<string>();
        public List<decimal> Degrees { get; set; } = new List<decimal>();
        public List<string> Colors { get; set; } = new List<string>();
    }
}
