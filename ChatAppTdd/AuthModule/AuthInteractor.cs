using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.Repository;
using ChatAppTdd.Utils;
using ChatAppTdd.Locale;

namespace ChatAppTdd.AuthModule
{
    public class AuthInteractor : IAuthInteractor
    {

        private IUserDataService _service;
        private IAuthPresenter _presenter;
        private IValidationWorker _validator = new ValidationWorker();
        
        public AuthInteractor(IUserDataService service, IAuthPresenter presenter)
        {
            _service = service ?? throw new ArgumentNullException("Provided service is null!");

            _presenter = presenter ?? throw new ArgumentNullException("Provided presenter is null!");
            _presenter.OnLogInAttempt += Authorization;
            _presenter.OnSignUpAttempt += Registration;
        }



        public void Authorization(string login, string password)
        {
            if (login == null)
            {
                throw new ArgumentNullException("Provided login is null! Recheck!");
            }

            if (!_validator.ValidateLogin(login))
            {
                _presenter.LoginFail(LoginFailType.LoginWrongFormat);
                return;
            }

            if (password == null)
            {
                throw new ArgumentNullException("Provided password is null! Recheck!");
            }

            if (!_validator.ValidatePassword(password))
            {
                _presenter.LoginFail(LoginFailType.PasswordWrongFormat);
                return;
            }

            string sid=_service.AuthorizeUser(login,password, out LoginFailType error);
            if (error!=LoginFailType.None)
            {
                _presenter.LoginFail(error);
                return;
            }

            string uid=_service.GetUserIdBySessionId(sid);

            if (uid==null)
            {
                _presenter.LoginFail(LoginFailType.Error);
                return;
            }
            _presenter.LoginSuccess(sid, uid);
        }


        public void Registration()
        {
            //probably later some registation permission logic will be required
            _presenter.SignUpAllowed();
        }
    }
}
