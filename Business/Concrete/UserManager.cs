using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public User CreateUser(User User)
        {
            return _userRepository.CreateUser(User);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(User User)
        {
            return _userRepository.UpdateUser(User);
        }
        public User GetUserByEmail(string eposta)
        {
            return _userRepository.GetUserByEmail(eposta);
        }
        public bool UserAny(string eposta)
        {
            return _userRepository.UserAny(eposta);
        }
    }
}
