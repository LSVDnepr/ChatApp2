using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Entities;
using ChatAppTdd.Locale;

namespace ChatAppTdd.Repository
{
    public interface IUserDataService
    {
        bool CheckLoginExists(string login);
        string AuthorizeUser(string login, string password, out LoginFailType failType);
        string RegisterUser(string login, string password, string title, out SignUpFailType failType);
        string GetUserIdBySessionId(string sessionId);
        IUserData GetUserData(string sessionId);


    }
}
