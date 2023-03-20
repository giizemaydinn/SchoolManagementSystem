using Business.Abstract;
using Entities.Dtos.ExamGrade;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamGradesController : ControllerBase
    {
        IExamGradeService _examGradeService;

        public ExamGradesController(IExamGradeService ExamGradeService)
        {
            _examGradeService = ExamGradeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            
            var result = await _examGradeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _examGradeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddExamGradeDto addExamGradeDto)
        {
            var result = await _examGradeService.Add(addExamGradeDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _examGradeService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
