using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        readonly IService<GenreDTO> genreService;

        public GenresController(IService<GenreDTO> service)
        {
            genreService = service;
        }

        // GET: api/genres
        [HttpGet]
        public ActionResult<IEnumerable<GenreDTO>> GetAll()
        {
            var genres = genreService.GetAll();
            return Ok(genres);
        }

        // GET api/genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            var genre = await genreService.GetByIdAsync(id);
            return Ok(genre);
        }

        // POST api/genres
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> Add([FromBody] GenreDTO model)
        {
            try
            {
                await genreService.AddAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/genres/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GenreDTO>> Update(GenreDTO model)
        {
            try
            {
                await genreService.UpdateAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/genres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoDTO>> Delete(int id)
        {
            await genreService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
