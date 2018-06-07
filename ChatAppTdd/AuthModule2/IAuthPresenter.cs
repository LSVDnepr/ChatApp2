using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd;

namespace ChatAppTdd.AuthModule2
{
    public interface IAuthPresenter
    {
        event Action<string, string> OnLogInAttempt;
        event Action OnSignUpAttempt;

        void LoginSuccess(string sessionID, string clientId);
        void LoginFail(AuthModule.LoginFailType failReason);
        void SignUpAllowed();
        void SignUpForbidden(AuthModule.SignUpFailType failReason);    

    }
}
