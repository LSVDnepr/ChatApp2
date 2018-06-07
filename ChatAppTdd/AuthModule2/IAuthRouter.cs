using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule2
{
    public interface IAuthRouter
    {
        void MoveToChat(string sessionId, string userId);
        void MoveToRegistration();
    }
}
