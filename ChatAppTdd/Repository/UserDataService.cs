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
        private Dictionary<string, IAuthData> _userCredentials = new Dictionary<string, IAuthData>();
        private Dictionary<string, IAuthData> _userSessions = new Dictionary<string, IAuthData>();

        public UserDataService()
        {
            _userCredentials.Add("login123", new AuthData("login123","password123","2"));// "password");
            _userCredentials.Add("login", new AuthData("login", "password", "1"));// "password");
        }

        public string AuthorizeUser(string login, string password, out LoginFailType failType)
        {
            if (login == null || password == null)
            {
                throw new ArgumentNullException("Login and Password cant be null! Recheck!!!");
            }
                if (login==""||password=="")
            {
                failType = LoginFailType.Error;
                return null;
            }

            _userCredentials.TryGetValue(login, out IAuthData data);
            if (data==null)
            {
                failType = LoginFailType.WrongLogin;
                return null;
            }

            if (!data.Password.Equals(password))
            {
                failType = LoginFailType.WrongPassword;
                return null;
            }
            failType = LoginFailType.None;
            string sid = GenerateSession(DateTime.Now.Ticks);
            _userSessions.Add(sid,data);
            return sid;
        }

        public bool CheckLoginExists(string login)
        {
            if (login == null )
            {
                throw new ArgumentNullException("Login and Password cant be null! Recheck!!!");
            }
            if (login == "")
            {
                throw new ArgumentException();
            }
            _userCredentials.TryGetValue(login, out IAuthData data);
            return data != null;
        }

        public IUserData GetUserData(string sessionId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException("Login and Password cant be null! Recheck!!!");
            }
            if (sessionId == "")
            {
                throw new ArgumentException();
            }
            _userSessions.TryGetValue(sessionId, out IAuthData data);
            if (data == null) return null;

            return new UserData(data.UserId,sessionId,"Title");
        }

        public string GetUserIdBySessionId(string sessionId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException("Login and Password cant be null! Recheck!!!");
            }
            if (sessionId == "")
            {
                throw new ArgumentException();
            }
            _userSessions.TryGetValue(sessionId, out IAuthData data);
            if (data == null) return null;
            return data.UserId;
        }

        public string RegisterUser(string login, string password, string title, out SignUpFailType failType)
        {
            throw new NotImplementedException();
        }

        private string GenerateSession(long num)
        {
            String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int r;
            String newNumber = "";

            // in r we have the offset of the char that was converted to the new base
            while (num >= 32)
            {
                r = (int)(num % 32);
                newNumber = chars[r] + newNumber;
                num = num / 32;
            }
            newNumber = chars[(int)num] + newNumber;
            return newNumber;
        }
    }
}
