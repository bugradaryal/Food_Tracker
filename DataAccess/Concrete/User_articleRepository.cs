using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class User_articleRepository : IUser_articleRepository
    {
        public User_article CreateUser_article(User_article User_article)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.User_articles.Add(User_article);
                DbContext.SaveChanges();
                return User_article;
            }
        }

        public void DeleteUser_article(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                var deletedUser_article = GetUser_articleById(id);
                DbContext.User_articles.Remove(deletedUser_article);
                DbContext.SaveChanges();
            }
        }

        public List<User_article> GetAllUser_articles()
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.User_articles.ToList();
            }
        }

        public User_article GetUser_articleById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.User_articles.Find(id);
            }
        }

        public User_article UpdateUser_article(User_article User_article)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.User_articles.Update(User_article);
                return User_article;
            }
        }
    }
}
