using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public interface IAuthPresenter
    {
        event Action<string,string> OnLogInAttempt;
        event Action<string, string,string>  OnSignUpAttempt;

        void LoginSuccess(string sessionID, string clientId);
        void LoginFail(LoginFailType failReason);
        void SignUpSuccess(string sessionID, string clientId);
        void SignUpFail(SignUpFailType failReason);

    }
}
