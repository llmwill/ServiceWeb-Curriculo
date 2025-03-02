using Curriculos.DTOs;
using Curriculos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curriculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculosController : ControllerBase
    {
        private readonly ICurriculumService _service;
        public CurriculosController(ICurriculumService service) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();

            return response is null ? BadRequest() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> Post(CurriculumDTO curriculum)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await _service.PostAsync(curriculum);

            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(CurriculumDTO curriculum, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _service.UpdateAsync(curriculum, id);

            return response is not null ? Ok(response) : BadRequest();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);

            return response ? Ok() : BadRequest();
        }
    }
}
