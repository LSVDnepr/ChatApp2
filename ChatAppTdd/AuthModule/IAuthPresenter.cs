using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.Locale;

namespace ChatAppTdd.AuthModule
{
    public interface IAuthPresenter
    {
        event Action<string, string> OnLogInAttempt;
        event Action OnSignUpAttempt;

        void LoginSuccess(string sessionID, string userId);
        void LoginFail(LoginFailType failReason);
        void SignUpAllowed();
        void SignUpForbidden(SignUpFailType failReason);    

    }
}
