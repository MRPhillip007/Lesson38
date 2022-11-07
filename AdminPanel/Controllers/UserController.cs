using AdminPanel.BLL.Services.UserService;
using AdminPanel.Entities;
using AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> GetUsers() => _userService.GetUsers();

        [HttpGet]
        [Route("{id}")]
        public User GetUserById(int id) => _userService.GetUserById(id);

        [HttpPost]
        public void SaveUser([FromBody] UserEntity userEntity) => _userService.SaveUser(userEntity);

        [HttpPut]
        public void UpdateUser([FromBody] UserEntity userEntity) => _userService.UpdateUser(userEntity);

        [HttpDelete("{id}")]
        public void DeleteUser(int id) => _userService.DeleteUser(id);
    }
}
