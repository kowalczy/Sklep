using Microsoft.AspNetCore.Mvc;
using Sklep.Core.Domain;
using Sklep.Infrastructure.Commands;
using Sklep.Infrastructure.Services;
using System.Threading.Tasks;

namespace Sklep.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _userDetailsService;
        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }

        // userDetails
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _userDetailsService.BrowseAll();
            return Json(z);
        }

        //localhost/userDetails/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var z = await _userDetailsService.Get(id);
            return Json(z);
        }

        //userDetails
        [HttpPost]
        public async Task<IActionResult> AddUserDetails([FromBody] CreateUserDetails userDetails)
        {
            UserDetails u = new UserDetails()
            {
                Country = userDetails.Country,
                City = userDetails.City,
                Adress = userDetails.Adress,
                UserId = userDetails.UserId
            };
            await _userDetailsService.Add(u);
            return Json(u);
        }

        //userDetails/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserDetails([FromBody] UpdateUserDetails userDetails, int id)
        {
            UserDetails u = new UserDetails()
            {
                Country = userDetails.Country,
                City = userDetails.City,
                Adress = userDetails.Adress
            };
            await _userDetailsService.Update(u, id);
            return Json(u);
        }

        //userDetails/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            await _userDetailsService.Del(id);
            return Json(id);
        }
    }
}
