using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArch.MVC.Pages.Course
{
    public class IndexModel : PageModel
    {
        private static ICourseService _courseService;

        [BindProperty(SupportsGet = true)]
        public CourseVidewModel CourseViewModel { get; set; }

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void OnGet()
        {
            this.CourseViewModel = _courseService.GetCourses();
        }
    }
}
