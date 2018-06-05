using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.Repository;

namespace ChatAppTdd.AuthModule
{
    public class AuthInteractor : IAuthInteractor
    {

        public AuthInteractor(IUserDataService service, IAuthPresenter presenter)
        {

        }

        public void OnLogin(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void OnSignUp(string login, string password, string title)
        {
            throw new NotImplementedException();
        }
    }
}
