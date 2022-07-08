using Kognit.Models;
using Kognit.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kognit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly WalletRepository _walletRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
            _walletRepository = new WalletRepository();
        }

        [HttpGet("getUsers")]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _userRepository.GetUsers;

            if (users == null)
                return NotFound();

            return users;
        }

        [HttpGet("getUserById")]
        public ActionResult<User> GetById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost("createUser")]
        public ActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            _userRepository.InserirUser(user);

            return NoContent();
        }

        [HttpDelete("deleteUser")]
        public ActionResult<User> Delete(int id)
        {
            var userToDelete = _userRepository.GetUserById(id);
            var wallets = _walletRepository.GetWalletsByUser(id);

            if (userToDelete == null)
                return NotFound();

            if(wallets != null)
            {
                foreach(var wallet in wallets)
                {
                    _walletRepository.Delete(wallet.Id);
                }
            }

            _userRepository.Delete(userToDelete.Id);

            return NoContent();
        }

        [HttpPut("updateUser")]
        public ActionResult Update(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest();

            _userRepository.Update(user);

            return NoContent();
        }
    }
}
