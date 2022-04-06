using KUSYS.Core.Contracts;
using KUSYS.Core.Service;
using Microsoft.AspNetCore.Mvc;
using KUSYS.Core.Contracts.DTOs;
using KUSYS.Web.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace KUSYS.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.All)]
        public ServiceResponse<List<CourseDTO>> Get()
        {
            return _courseService.GetAllAsync().Result;
        }

        // GET: Course/5
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.All)]
        public ServiceResponse<CourseDTO> Details(string id)
        {
            return _courseService.GetByIdAsync(id).Result;
        }

        // POST: Course/Create
        [HttpPost("Create")]
        [Authorize(Roles = Roles.Admin)]
        public ServiceResponse<bool> Create(CourseDTO course)
        {
            return _courseService.CreateAsync(course).Result;
        }

        // POST: Course/Edit/5
        [HttpPost("Edit")]
        [Authorize(Roles = Roles.Admin)]
        public ServiceResponse<bool> Edit(string id, CourseDTO course)
        {
            return _courseService.UpdateAsync(course).Result;
        }

        // POST: Course/Delete/5
        [HttpPost("Delete")]
        [Authorize(Roles = Roles.Admin)]
        public ServiceResponse<bool> Delete(string id)
        {
            return _courseService.DeleteAsync(id).Result;
        }
    }
}