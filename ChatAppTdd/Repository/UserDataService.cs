﻿using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.Entities;

using ChatAppTdd.Repository;

namespace ChatAppTdd.Repository
{
    public class UserDataService : IUserDataService
    {

        public UserDataService()
        {

        }

        public string AuthorizeUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckLoginExists(string login)
        {
            throw new NotImplementedException();
        }

        public IUserData GetUserData(string sessionId)
        {
            throw new NotImplementedException();
        }

        public string GetUserIdBySessionId(string sessionId)
        {
            throw new NotImplementedException();
        }

        public string RegisterUser(string login, string password, string title)
        {
            throw new NotImplementedException();
        }
    }
}
