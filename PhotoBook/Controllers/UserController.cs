using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoBook.Data;
using PhotoBook.Models;

namespace PhotoBook.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<User> GetAllUsers() => _unitOfWork.Users.GetAll();

        [HttpGet]
        [Route("{id:int}")]
        public User GetById(int id)
        {
            User user = _unitOfWork.Users.GetByID(id);
            return user;
        }

        [HttpPost]
        [Route("add")]
        public int Add(IFormCollection data)
        {
            User user = new User();
            user.FirstName = data["FirstName"];
            user.LastName = data["LastName"];
            user.Email = data["Email"];
            user.Password = data["Password"];

            return _unitOfWork.Users.Insert(user);
        }

        [HttpPut]
        [Route("edit/{id:int}")]
        public ActionResult Edit(IFormCollection data)
        {
            User user = new User();
            user.Id = int.Parse(data["Id"]);
            user.FirstName = data["FirstName"];
            user.LastName = data["LastName"];
            user.Email = data["Email"];
            user.Password = data["Password"];

            _unitOfWork.Users.Update(user);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.Users.Delete(id);

            return Ok();
        }
    }
}
