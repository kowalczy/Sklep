using Microsoft.AspNetCore.Mvc;
using Sklep.Core.Domain;
using Sklep.Infrastructure.Commands;
using Sklep.Infrastructure.Services;
using System.Threading.Tasks;

namespace Sklep.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // user
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _userService.BrowseAll();
            return Json(z);
        }

        //localhost/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var z = await _userService.Get(id);
            return Json(z);
        }

        //user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUser user)
        {
            User u = new User()
            {
                Name = user.Name,
                Surname = user.Surname
            };
            await _userService.Add(u);
            return Json(u);
        }

        //user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser([FromBody] UpdateUser user, int id)
        {
            User u = new User()
            {
                Name = user.Name,
                Surname = user.Surname
            };
            await _userService.Update(u, id);
            return Json(u);
        }

        //user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.Del(id);
            return Json(id);
        }
    }
}
