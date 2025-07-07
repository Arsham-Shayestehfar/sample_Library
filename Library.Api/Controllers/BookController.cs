using Domain.Entities;
using Library.Application.Dtos;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/v{version:apiVersion}/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _book;
        public BookController(IBookService book)
        {
            _book = book;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var model =await _book.GetAllAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id )
        {
            var model =await _book.GetByIdAsync(id);
            if (model == null) 
                return NotFound();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _book.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id},created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] BookDto dto, int id)
        {
            if (id != dto.Id)
                return BadRequest(ModelState);

                
                var updated = await _book.UpdateAsync(dto);
            if(!updated)
               return BadRequest(ModelState);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            var deleted = await _book.DeleteAsync(id);
            if (!deleted)
                return BadRequest(ModelState);
            return NoContent();
        }
    }
}
