using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public interface IAuthRouter
    {
        void MoveToChat(string sessionId, string userId);
        void MoveToRegistration();
    }
}
