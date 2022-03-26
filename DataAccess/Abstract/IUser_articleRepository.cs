using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUser_articleRepository
    {
        List<User_article> GetAllUser_articles();
        User_article GetUser_articleById(int id);
        User_article CreateUser_article(User_article User_article);
        User_article UpdateUser_article(User_article User_article);
        void DeleteUser_article(int id);
    }
}
