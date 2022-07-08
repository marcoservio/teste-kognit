using Kognit.Models;
using Kognit.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kognit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet("getUser")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userRepository.GetUsers;
        }

        [HttpPost("createUser")]
        public void Create([FromBody] User user)
        {
            _userRepository.InserirUser(user);
        }
    }
}
