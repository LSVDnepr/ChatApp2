using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public class AuthPresenter : IAuthPresenter
    {
        public event Action<string, string> OnLogInAttempt;
        public event Action<string, string, string> OnSignUpAttempt;


        public AuthPresenter(IAuthView view, IAuthRouter router)
        {

        }

        public AuthPresenter(IAuthView view, IAuthRouter router, LocalesSupported locale)
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


        public void SignUpFail(SignUpFailType failReason)
        {
            throw new NotImplementedException();
        }


        public void SignUpSuccess(string sessionID, string clientId)
        {
            throw new NotImplementedException();
        }

    }
}
