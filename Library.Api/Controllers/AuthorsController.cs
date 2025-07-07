using Library.Application.Dtos;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/v{version:apiVersion}/Author")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _author;
        public AuthorsController(IAuthorService author)
        {
            _author = author;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _author.GetAllAsync();
            return Ok(authors);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _author.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created =await _author.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id},created);
            
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AuthorDto dto , int id )
        {
            if (id != dto.Id)
                return BadRequest("ID doesnt match");
            var update = await _author.UpdateAsync(dto);
            if(!update)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
           var delete= await _author.DeleteAsync(id);
            if(!delete)
                return NotFound();
            return NoContent();
        }
    }
}
