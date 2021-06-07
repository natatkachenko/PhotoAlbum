using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WEB.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
                if (ModelState.IsValid)
                {
                    await photoService.AddAsync(model);
                    return Ok(model);
                }
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/photos
        [HttpPut]
        public async Task<ActionResult<PhotoDTO>> Update(PhotoDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await photoService.UpdateAsync(model);
                    return Ok(model);
                }
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/photos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoDTO>> Delete(int id)
        {
            await photoService.DeleteByIdAsync(id);
            var photoDTO = photoService.GetByIdAsync(id).Result;
            
            return RedirectToAction("Delete", "Upload", new { filePath = photoDTO.ImagePath });
        }
    }
}
