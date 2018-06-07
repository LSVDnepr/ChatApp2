using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;

namespace ChatAppTdd.AuthModule2
{
    public class AuthPresenter : IAuthPresenter
    {
        public event Action<string, string> OnLogInAttempt;
        public event Action OnSignUpAttempt;

        public AuthPresenter(IAuthView view, IAuthRouter router)
        {

        }


        public void LoginFail(LoginFailType failReason)
        {
            throw new NotImplementedException();
        }

        public void LoginSuccess(string sessionID, string clientId)
        {
            throw new NotImplementedException();
        }

        public void SignUpAllowed()
        {
            throw new NotImplementedException();
        }

        public void SignUpForbidden(SignUpFailType failReason)
        {
            throw new NotImplementedException();
        }
    }
}
