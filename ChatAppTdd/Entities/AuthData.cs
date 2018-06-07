using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Entities
{
    public class AuthData : IAuthData
    {
        public AuthData(string login, string password, string userId)
        {
            Login = login;
            Password = password;
            UserId = userId;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
