using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler mediatorHandler)
        {
            _courseRepository = courseRepository;
            _mediatorHandler = mediatorHandler;
        }

        public void Create(CourseVidewModel courseVidewModel)
        {
            var createCourseCommand = new CreateCourseCommand(courseVidewModel.Name, courseVidewModel.Description, courseVidewModel.ImageUrl);
            _mediatorHandler.SendCommand(createCourseCommand);
        }

        public CourseVidewModel GetCourses()
        {
            return new CourseVidewModel()
            {
                Courses = _courseRepository.GetCourses()
            };
        }
    }
}
