using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Entities
{
    public class UserData : IUserData
    {
        public UserData(string userID, string sessionID, string title)
        {
            UserID = userID;
            SessionID = sessionID;
            Title = title;
        }

        public string UserID { get; set; }
        public string SessionID { get; set; }
        public string Title { get; set; }


            }
}
