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

        public User GetUserById(int id)
        {
            return _user.GetUserById(id);
        }

        public void InserirUser(User user)
        {
            _user.InsertUser(user);
        }

        public void Delete(int id)
        {
            _user.Delete(id);
        }

        public void Update(User user)
        {
            _user.Update(user);
        }
    }
}
