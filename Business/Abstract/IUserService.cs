﻿using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetUserById(int id);
        User CreateUser(User User);
        User UpdateUser(User User);
        void DeleteUser(int id);
        User GetUserByEmail(string eposta);
        public bool UserAny(string eposta);
    }
}
