using Microsoft.AspNetCore.Mvc;
using Escola.Repositories;
using Escola.Models;
using Escola.DTOs;

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
            List<Result> resultados = await _studentRepository.GetAllStudents();
            List<StudentModel> students = new List<StudentModel>();
            foreach (Result result in resultados)
            {  
                if (result.Success)
                {
                    students.Add(result.Student);
                }
                else
                {
                    return Problem(result.Error);
                }
            }
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(string id="")
        {
            int validId;
            validId = int.Parse(id);
            if (validId <= 0)
            {
                return BadRequest("O ID é inválido");
            }
            Result result = await _studentRepository.GetStudent(validId);
            if (result.Success)
            {
                return Ok(result.Student);
            }
            return NotFound(result.Error);
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> CreatStudent([FromBody] StudentModel studentModel)
        {
            Result result = await _studentRepository.CreatStudent(studentModel);
            if (result.Success) 
            { 
                return Ok(result.Student);
            }
            return BadRequest(result.Error);
        }

        [HttpPatch]
        public async Task<ActionResult<StudentModel>> UpdateStudent([FromBody] StudentDTO studentDTO, string id = "")
        {
            int validId;
            validId = int.Parse(id);
            if (validId <= 0)
            {
                return BadRequest("O ID é inválido");
            }
            Result result = await _studentRepository.UpdateStudent(studentDTO, validId);
            if (result.Success)
            {
                return Ok(result.Student);
            }
            return BadRequest(result.Error);
        }

        [HttpDelete]
        public async Task<ActionResult<StudentModel>> DeleteStudent(string id = "")
        {
            int validId;
            validId = int.Parse(id);
            if (validId <= 0)
            {
                return BadRequest("O ID é inválido");
            }
            Result result = await _studentRepository.DeleteStudent(validId);
            if (result.Success)
            {
                return Ok(result.Student);
            }
            return NotFound(result.Error);
        }

        [HttpGet("Filter")]
        public async Task<ActionResult<List<StudentModel>>> GetStudentFilter(string? classe, float gpa, int age)
        {
            List<Result> resultados = await _studentRepository.GetStudentFilter(gpa, age, classe);
            List<StudentModel> students = new List<StudentModel>();
            foreach (Result result in resultados)
            {
                if (result.Success)
                {
                    students.Add(result.Student);
                }
                else
                {
                    return BadRequest(result.Error);
                }
            }
            return Ok(students);
        }
    }
}
