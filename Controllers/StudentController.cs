using Microsoft.AspNetCore.Mvc;
using Escola.Repositories;
using Escola.Models;

namespace Escola.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<StudentModel>>> GetAllStudents()
        {
            List<StudentModel> users = await _studentRepository.GetAllStudents();
            return Ok(users);
        }
    }
}
