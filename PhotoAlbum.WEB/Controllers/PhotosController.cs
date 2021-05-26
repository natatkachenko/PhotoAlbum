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
    public class PhotosController : ControllerBase
    {
        readonly IService<PhotoDTO> photoService;

        public PhotosController(IService<PhotoDTO> service)
        {
            photoService = service;
        }

        // GET: api/photos
        [HttpGet]
        public ActionResult<IEnumerable<PhotoDTO>> GetAll ()
        {
            var photos = photoService.GetAll();
            return Ok(photos);
        }

        // GET api/photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDTO>> GetById(int id)
        {
            var photo = await photoService.GetByIdAsync(id);
            return Ok(photo);
        }

        // POST api/photos
        [HttpPost]
        public async Task<ActionResult<PhotoDTO>> Add([FromBody] PhotoDTO model)
        {
            try
            {
                await photoService.AddAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<PhotoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
