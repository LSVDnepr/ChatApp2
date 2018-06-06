using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public class ChatAuthException : Exception
    {
        private LoginFailType _loginFailType;


        public ChatAuthException(LoginFailType loginFailType)
        {
            this._loginFailType = loginFailType;
        }

        public LoginFailType LoginFailType { get => _loginFailType;  }
    }
}
