using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User CreateUser(User User);
        User UpdateUser(User User);
        void DeleteUser(int id);
        User GetUserByEmail(string eposta);
    }
}
