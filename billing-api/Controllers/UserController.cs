using Bussiness.Services;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        { this.userService = _userService; }

        [HttpGet("")]
        public IEnumerable<tUser> GetAllUsers() => userService.GetAll();

        [HttpGet("{id}")]
        public tUser GetUser(int id) => userService.GetById(id);

        [HttpPost("")]
        [AllowAnonymous]
        public bool AddUser(tUser user)
        {
            return userService.Insert(user);
        }
    }
}
