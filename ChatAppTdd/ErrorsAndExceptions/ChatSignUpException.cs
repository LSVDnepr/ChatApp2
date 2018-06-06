using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public class ChatSignUpException : Exception
    {
        private SignUpFailType _signUpFailType;


        public ChatSignUpException(SignUpFailType signUpFailType)
        {
            this._signUpFailType = signUpFailType;
        }

        public SignUpFailType SignUpFailType { get => _signUpFailType; }
    }
}
