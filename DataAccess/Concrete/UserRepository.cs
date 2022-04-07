using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User User)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Users.Add(User);
                DbContext.SaveChanges();
                return User;
            }
        }

        public void DeleteUser(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                var deletedUser = GetUserById(id);
                DbContext.Users.Remove(deletedUser);
                DbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Users.Find(id);
            }
        }

        public User UpdateUser(User User)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Users.Update(User);
                return User;
            }
        }
        public User GetUserByEmail(string eposta)
        {
            using (var DbContext = new DataDbContext())
            {
                if(DbContext.Users.Any(x=>x.Eposta == eposta) == true)
                {
                    return DbContext.Users.FirstOrDefault(x => x.Eposta == eposta);
                }
                else
                {
                    return null;
                }
            }
        }
        public bool UserAny(string eposta)
        {
            using (var DbContext = new DataDbContext())
            {
                if (DbContext.Users.Any(x => x.Eposta == eposta) == true)
                    return true;
                else
                    return false;
            }
        }

    }
}
