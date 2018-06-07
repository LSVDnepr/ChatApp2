using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Entities;
using ChatAppTdd.Locale;

namespace ChatAppTdd.Repository
{
    public class UserDataService : IUserDataService
    {
        public UserDataService()
        {

        }

        public string AuthorizeUser(string login, string password, out LoginFailType failType)
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

        public string RegisterUser(string login, string password, string title, out SignUpFailType failType)
        {
            throw new NotImplementedException();
        }
    }
}
