using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.Entities;


namespace ChatAppTdd.Repository
{
    public interface IUserDataService
    {
        bool CheckLoginExists(string login);  
        string AuthorizeUser(string login, string password); 
        string RegisterUser(string login, string password, string title); 
        string GetUserIdBySessionId(string sessionId);
        IUserData GetUserData(string sessionId);



    }
}
