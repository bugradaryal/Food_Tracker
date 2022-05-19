using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class User_articleManager : IUser_articleService
    {
        private IUser_articleRepository _User_articleRepository;

        public User_articleManager()
        {
            _User_articleRepository = new User_articleRepository();
        }

        public User_article CreateUser_article(User_article User_article)
        {
            return _User_articleRepository.CreateUser_article(User_article);
        }

        public void DeleteUser_article(int id)
        {
            _User_articleRepository.DeleteUser_article(id);
        }

        public List<User_article> GetAllUser_articles()
        {
            return _User_articleRepository.GetAllUser_articles();
        }

        public User_article GetUser_articleById(int id)
        {
            return _User_articleRepository.GetUser_articleById(id);
        }

        public User_article UpdateUser_article(User_article User_article)
        {
            return _User_articleRepository.UpdateUser_article(User_article);
        }

        public List<User_article> SearchByTitle(string search)
        {
            return _User_articleRepository.SearchByTitle(search);
        }
        public List<User_article> GetUser_ArticleByUserId(int id)
        {
            return _User_articleRepository.GetUser_ArticleByUserId(id);
        }
        public List<User_article> SearchByTitleForMyText(int id, string search)
        {
            return _User_articleRepository.SearchByTitleForMyText(id, search);
        }
    }
}
