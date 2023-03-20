using Business.Abstract;
using Entities.Dtos.Lesson;
using Entities.Dtos.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            
            var result = await _lessonService.GetAll();
            if (result.Success)
            {
                
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _lessonService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddLessonDto addLessonDto)
        {
            var result = await _lessonService.Add(addLessonDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _lessonService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] LessonDto updateLessonDto)
        {
            var result = await _lessonService.Update(updateLessonDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
