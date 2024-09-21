using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.ViewModels
{
    public class CoursewithDeptListViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Name should have more than 3 letters")]
        public string Name { get; set; }
        [Required]
        [Range(50,100)]
        public decimal Degree { get; set; }
        [Required]
        [Remote(action:"CompareDegree" , controller:"Course" , AdditionalFields ="Degree" , ErrorMessage ="MinDegree should be less than Degree")]
        public decimal MinDegree { get; set; }
        public int Hours { get; set; }
        [Required]
        public int dept_id { get; set; }
        public IEnumerable<Department>? Departments { get; set; }
    }
}
