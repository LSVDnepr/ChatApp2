using System;
using ChatAppTdd.Locale;

namespace ChatAppTdd.AuthModule
{
    public class AuthPresenter : IAuthPresenter
    {

        private IAuthView _view;
        private IAuthRouter _router;
        private ILocaleStore _localeWorker = LocaleStoreHolder.localize;

        public event Action<string, string> OnLogInAttempt;
        public event Action OnSignUpAttempt;


        public AuthPresenter(IAuthView view, IAuthRouter router)
        {
            _view = view ?? throw new ArgumentNullException("Provided view is null!");
            _view.OnLocaleChanged += LocaleChanged;
            _view.OnLoginBtnPressed += LoginAttempt;
            _view.OnSignUpBtnPressed += SignUpAllowed;

            _router = router ?? throw new ArgumentNullException("Provided router is null!");

            LocaleChanged("EN");

        }

        private void LocaleChanged(string localeCode)
        {
            if (localeCode == null)
            {
                throw new ArgumentNullException("Provided locale code is null! Recheck!");
            }

            _localeWorker.SetLocale(localeCode);
            _view.LoginLabelTxt = _localeWorker.LoginText;
            _view.LoginButtonTxt = _localeWorker.LogInBtnText;
            _view.PasswordLabelTxt = _localeWorker.PasswordText;
            _view.SignUpBtnTxt = _localeWorker.SignUpBtnText;

        }

        public void LoginAttempt(string login, string password)
        {
            if (login == null)
            {
                throw new ArgumentNullException("Provided login is null! Recheck!");
            }

            if (login.Length == 0)
            {
                string loginErrorMessage = _localeWorker.GetErrorText(LoginFailType.LoginWrongFormat);
                _view.ShowErrorMessage(loginErrorMessage);
                //добавить стилизацию вью
                return;
            }


            if (password == null)
            {
                throw new ArgumentNullException("Provided password is null! Recheck!");
            }

            if (password.Length == 0)
            {
                string passwordErrorMessage = _localeWorker.GetErrorText(LoginFailType.PasswordWrongFormat);
                _view.ShowErrorMessage(passwordErrorMessage);
                //добавить стилизацию вью
                return;
            }

            OnLogInAttempt?.Invoke(login,password);


        }

        public void SignUpAttempt()
        {
            OnSignUpAttempt?.Invoke();
        }


        public void LoginSuccess(string sessionID, string userId)
        {
            if (sessionID==null)
            {
                throw new ArgumentNullException("Passed sessionId is null! Recheck!");
            }
            if (userId == null)
            {
                throw new ArgumentNullException("Passed userId is null! Recheck!");
            }

            _router.MoveToChat(sessionID, userId);
        }





        public void LoginFail(LoginFailType failReason)
        {
            _view.ShowErrorMessage(_localeWorker.GetErrorText(failReason));
            //добавить стилизацию вью
        }

       


        public void SignUpAllowed()
        {
            _router.MoveToRegistration();
        }



        public void SignUpForbidden(SignUpFailType failReason)
        {
            _view.ShowErrorMessage(_localeWorker.GetErrorText(failReason));
        }



        
    }
}
