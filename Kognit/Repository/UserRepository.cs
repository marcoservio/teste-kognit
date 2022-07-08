using Kognit.Models;
using Kognit.Services;

namespace Kognit.Repository
{
    public class UserRepository
    {
        private readonly UserService _user;

        public UserRepository()
        {
            _user = new UserService();
        }

        public List<User> GetUsers
        {
            get
            {
                return _user.GetUsers();
            }
        }

        public void InserirUser(User user)
        {
            _user.InsertUser(user);
        }
    }
}
