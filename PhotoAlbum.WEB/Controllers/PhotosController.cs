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
    [ApiController]
    public class PhotosController : ControllerBase
    {
        readonly IPhotoService photoService;
        readonly IUserService userService;

        public PhotosController(IPhotoService service, IUserService _userService)
        {
            photoService = service;
            userService = _userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<PhotoDTO>> GetAll ()
        {
            var photos = photoService.GetAll();
            return Ok(photos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDTO>> GetById(int id)
        {
            try
            {
                var photo = await photoService.GetByIdAsync(id);
                return Ok(photo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoDTO>> Delete(int id)
        {
            try
            {
                await photoService.DeleteByIdAsync(id);
                var photoDTO = photoService.GetByIdAsync(id).Result;

                return RedirectToAction("Delete", "Upload", new { filePath = photoDTO.ImagePath });
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Sends photos of the current user.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("MyPhotos")]
        public ActionResult<IEnumerable<PhotoDTO>> GetUserPhotos()
        {
            var photos = photoService.GetPhotosByUserName(User.Identity.Name);

            if (photos is null)
                return NoContent();

            return Ok(photos);
        }
    }
}
