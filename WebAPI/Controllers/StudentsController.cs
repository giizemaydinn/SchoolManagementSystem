using Business.Abstract;
using Entities.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddStudentDto studentAddDto)
        {
            var result = await _studentService.Add(studentAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentDto updateStudentDto)
        {
            var result = await _studentService.Update(updateStudentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addlessontostudent")]
        public async Task<IActionResult> AddLessonToStudent([FromBody] AddLessonToStudentDto addLessonToStudentDto)
        {
            var result = await _studentService.AddLessonToStudent(addLessonToStudentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addteachertostudent")]
        public async Task<IActionResult> AddTeacherToStudent([FromBody] AddTeacherToStudentDto addTeacherToStudentDto)
        {
            var result = await _studentService.AddTeacherToStudent(addTeacherToStudentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
