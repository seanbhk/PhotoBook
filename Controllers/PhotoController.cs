using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoBook.Data;
using PhotoBook.Models;
using System.IO;
using Microsoft.AspNetCore.Cors;

namespace PhotoBook.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhotoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Photo> GetAll() => _unitOfWork.Photos.GetAll();

        [HttpGet]
        [Route("{id:int}")]
        public Photo GetById(int id) => _unitOfWork.Photos.GetByID(id);

        [HttpPost]
        [Route("add")]
        public int Add(IFormCollection data)
        {
            Photo photo = new Photo();
            photo.Title = data["Title"];
            photo.Description = data["Description"];
            photo.UserId = int.Parse(data["UserId"]);
            var formImage = data.Files.GetFile("Image");
            MemoryStream ms = new MemoryStream();
            formImage.CopyTo(ms);
            photo.Image = ms.ToArray();

            return _unitOfWork.Photos.Insert(photo);
        }

        [HttpPut]
        [Route("edit/{id:int}")]
        public ActionResult Edit(IFormCollection data)
        {
            Photo photo = new Photo();
            photo.Id = int.Parse(data["Id"]);
            photo.Title = data["Title"];
            photo.Description = data["Description"];
            photo.UserId = int.Parse(data["UserId"]);
            var formImage = data.Files.GetFile("img");
            MemoryStream ms = new MemoryStream();
            formImage.CopyTo(ms);
            photo.Image = ms.ToArray();

            _unitOfWork.Photos.Update(photo);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.Photos.Delete(id);

            return Ok();
        }
    }
}
