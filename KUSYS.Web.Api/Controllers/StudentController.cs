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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.All)]
        public ServiceResponse<List<StudentDTO>> Get()
        {
            return _studentService.GetAllAsync().Result;
        }

        // GET: Student/5
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.All)]
        public ServiceResponse<StudentDTO> Details(int id)
        {
            return _studentService.GetByIdAsync(id).Result;
        }

        // POST: Student/Create
        [HttpPost("Create")]
        [Authorize(Roles = Roles.Admin)]
        public ServiceResponse<bool> Create(StudentDTO student)
        {
            return _studentService.CreateAsync(student).Result;
        }

        // POST: Student/Edit/5
        [HttpPost("Edit")]
        [Authorize(Roles = Roles.Admin)]
        public ServiceResponse<bool> Edit(int id, StudentDTO student)
        {
            return _studentService.UpdateAsync(student).Result;
        }

        // POST: Student/Delete/5
        [HttpPost("Delete")]
        [Authorize(Roles = Roles.Admin)]
        public ServiceResponse<bool> Delete(int id)
        {
            return _studentService.DeleteAsync(id).Result;
        }
    }
}