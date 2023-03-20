using Business.Abstract;
using Entities.Dtos.Parent;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        IParentService _parentService;

        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            
            var result = await _parentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _parentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ParentAddDto parentAddDto)
        {
            var result = await _parentService.Add(parentAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateParentDto updateParentDto)
        {
            var result = await _parentService.Update(updateParentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _parentService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
