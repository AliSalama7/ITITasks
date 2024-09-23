using System.ComponentModel.DataAnnotations;
using WebApplication1.ViewModels;

namespace WebApplication1.Data
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value , ValidationContext context)
        {
            if(value == null) 
                return null;
            DemoContext _context = new DemoContext();
            string newName = (string)value;
            var course = (CoursewithDeptListViewModel)context.ObjectInstance;
            if (_context.Courses.FirstOrDefault(c => c.Name == newName) is null || course.Id > 0 )
            {
                return ValidationResult.Success;
            }
            else 
            {
                return new ValidationResult("Name should be Unique");
            }

        }
    }
}
