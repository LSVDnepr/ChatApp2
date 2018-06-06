using System;
using NUnit.Framework;
using Moq;
using ChatAppTdd.AuthModule;

namespace ChatAppTddTest
{
    [TestFixture]
    public class AuthPresenterTests
    {

        private int onLoginCalled = 0;
        private int onSingUpCalled = 0;
        /*


3.IAuthPresenter
!!! get LocaleField with reflect

3.1. Constructor test  public AuthPresenter(IAuthView view, IAuthRouter router)
3.1.3.creates object successfully, calls view. void SetLocalizedData(ILocalizedViewData localeData); (from default if null)
3.1.3. creates object successfully (Assert.Pass) if bothh args are ok




3.2. public event Action<string, string> OnLogInAttempt;
3.2.1. is assigned on viewEvent OnLoginBtnPressed with some method. 
In method, assigned to action:
3.2.1. throws argument null if login is null 
3.2.2. throws argument null if password is null     
3.2.3. calls view.ShowErrorMessage(string message) if login is empty
3.2.4. calls view.ShowErrorMessage(string message) if password is empty //если делать alarm window, то как настроить 
//отрисовку невалидного поля в соотв палитре?
3.2.5. invokes OnLogInAttempt;(на этот экшн подписан интерактор - OnLogin() method)

//пока закомментить?? и сделать , чтобы просто отрабатывал переход на registerActivity???
3.3.  public event Action<string, string, string> OnSignUpAttempt;
3.3.1. is assigned on viewEvent OnSignUpBtnPressed; with some method. 
In method, assigned to action:
3.3.1. throws argument null if login is null 
3.3.2. throws argument null if password is null    
3.3.3. throws argument null if title is null  
3.3.4. calls view.ShowErrorMessage(string message) if login is empty
3.3.5. calls view.ShowErrorMessage(string message) if password is empty //если делать alarm window, то как настроить 
//отрисовку невалидного поля в соотв палитре?
3.3.5. invokes OnSignUpAttempt;(на этот экшн подписан интерактор - OnSignUp() method)

<<<<<<<        !!!!          >>>>>>>>>
3.3.  public event Action<string, string, string> OnSignUpAttempt;
3.3.1. is assigned on viewEvent OnSignUpBtnPressed; with some method. 
In method, assigned to action: presenter calls router.MoveToRegistration();

3.4. event Action OnLocaleChanged;
is assigned on viewEvent OnLocaleChanged();
3.4.1. calls view(GetCurrentLocale)
3.4.2. if locale value is null or unknown throws Exception???
3.4.2. if parsed locale successfully, calls view.SetLocalizedData(ILocalizedViewData localeData);
//как правильно вытащить локаль из вью??





 3.5. void LoginSuccess(string sessionID, string clientId);

 3.6. void LoginFail(LoginFailType failReason);

 3.7. void SignUpSuccess(string sessionID, string clientId);

 3.8. void SignUpFail(SignUpFailType failReason);         */
        //presenter contructor view arg is null
        [Test]
        public void AuthPresenterConstructorViewNullArgsTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            Assert.Throws<ArgumentNullException>(() => new AuthPresenter(mockView.Object, null));

        }


        //presenter contructor router arg is null
        [Test]
        public void AuthPresenterConstructorRouterNullArgsTest()
        {
            var mockRouter = new Mock<IAuthRouter>(MockBehavior.Strict);
            Assert.Throws<ArgumentNullException>(() => new AuthPresenter(null, mockRouter.Object));
        }

        [Test]//!!
        public void AuthPresenterConstructorPositiveTest()
        {
            var mockRouter = new Mock<IAuthRouter>(MockBehavior.Strict);
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t=>t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            IAuthPresenter prsenter =new AuthPresenter(mockView.Object, mockRouter.Object);
            mockView.Verify(t=>t.SetLocalizedData(It.IsAny<ILocalizedViewData>()),Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnLoginLoginNullTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLoginBtnPressed += null, null, "Password");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }
        [Test]//!!
        public void AuthPresenterOnLoginLoginEmptyTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLoginBtnPressed += null, "", "Password");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnLoginPasswordNullTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLoginBtnPressed += null, "Login", null);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnLoginPasswordEmptyTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLoginBtnPressed += null, "Login", "");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        //on view event on login btn pressed invokes OnLoginAttempt
        [Test]//!!
        public void AuthPresenterOnLoginEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            presenter.OnLogInAttempt += (l, p) => onLoginCalled++; 
            mockView.Raise(t => t.OnLoginBtnPressed += null, "Login", "Password");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            Assert.That(onLoginCalled,Is.EqualTo(1));
        }


        [Test]//!!
        public void AuthPresenterOnSignUpLoginNullTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, null, "Password","Title");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()),Times.Once);
        }
        [Test]//!!
        public void AuthPresenterOnSignUpLoginEmptyTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "", "Password","Title");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnSignUpPasswordNullTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "Login", null,"Title");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnSignUpPasswordEmptyTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "Login", "", "Title");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnSignUpTitleNullTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "Login", "Password",null);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]//!!
        public void AuthPresenterOnSignUpTitleEmptyTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "Login", "Password", "");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        //on view event on login btn pressed invokes OnLoginAttempt
        [Test]//!!
        public void AuthPresenterOnSignUpEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            presenter.OnSignUpAttempt += (l, p, t) => onSingUpCalled++;
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "Login", "Password");
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            Assert.That(onSingUpCalled,Is.EqualTo(1));
        }

        [Test]//!!
        public void AuthPresenterOnLocaleChangedEnEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(new EnLocalizedViewData()));
            mockView.Setup(t => t.GetCurrentLocale()).Returns("EN");
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLocaleChanged += null);
            mockView.Verify(t => t.SetLocalizedData(new EnLocalizedViewData()), Times.Exactly(2));
            mockView.Verify(t => t.GetCurrentLocale(),Times.Once);
        }


        //on view event localechanged calls set Localized Data with russian localized data
        [Test]//!!
        public void AuthPresenterOnLocaleChangedRusEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(new EnLocalizedViewData()));
            mockView.Setup(t => t.SetLocalizedData(new RuLocalizedViewData()));
            mockView.Setup(t => t.GetCurrentLocale()).Returns("RU");
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLocaleChanged += null);
            mockView.Verify(t => t.SetLocalizedData(new EnLocalizedViewData()), Times.Once);
            mockView.Verify(t => t.SetLocalizedData(new RuLocalizedViewData()), Times.Once);
            mockView.Verify(t => t.GetCurrentLocale(), Times.Once);
        }

        [TestCase(null)]//!!
        [TestCase("")]//!!
        [TestCase("__")]//!!
        public void AuthPresenterOnBadCurrentLocaleTest(string locale)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup(t => t.GetCurrentLocale()).Returns(locale);
            mockView.Setup(t => t.ShowErrorMessage(It.IsAny<string>()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLocaleChanged += null);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockView.Verify(t => t.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }


        //testing whether on login failed ShowErrorMessage(string message) is called with proper args
        [TestCase(LocalesSupported.En, LoginFailType.Error, "Error. Try again later")]
        [TestCase(LocalesSupported.Ru, LoginFailType.Error, "Ошибка. Повторите позже")]
        [TestCase(LocalesSupported.En, LoginFailType.WrongLogin, "Login does not exist")]
        [TestCase(LocalesSupported.Ru, LoginFailType.WrongLogin, "Указанный логин не существует")]
        public void AuthPresenterOnLOginFailShowErrorTest(LocalesSupported locale, LoginFailType failType, string message)
        {

            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup((m => m.ShowErrorMessage(message)));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object, locale);
            presenter.LoginFail(failType);
            mockView.Verify(m => m.ShowErrorMessage(message), Times.Once);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
        }


        //testing whether on sign up failed ShowErrorMessage(string message) is called with proper args
        [TestCase(LocalesSupported.En, SignUpFailType.LoginExists, "Login already exists")]
        [TestCase(LocalesSupported.Ru, SignUpFailType.LoginExists, "Указанный логин уже существует")]
        [TestCase(LocalesSupported.En, SignUpFailType.Error, "Error. Try again later")]
        [TestCase(LocalesSupported.Ru, SignUpFailType.Error, "Ошибка. Повторите позже")]
        public void AuthPresenterOnSignUpFailShowErrorTest(LocalesSupported locale, SignUpFailType failType, string message)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            mockView.Setup((m => m.ShowErrorMessage(message)));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object, locale);
            presenter.SignUpFail(failType);
            mockView.Verify(m => m.ShowErrorMessage(message), Times.Once);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
        }

        //testing null args validation in LoginSuccess(string sessionID, string clientId) method
        [TestCase(null,"1")]
        [TestCase("10293847561213", null)]
        public void AuthPresenterLoginSuccessNullArgsValidationTest(string sessionID, string clientId)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            Assert.Throws<ArgumentNullException>(() => presenter.LoginSuccess(sessionID, clientId));
        }


        //testing args validation in LoginSuccess(string sessionID, string clientId) method
        //session id must contain 14 chars, onlt numerals allowed
        //client id must contain nums only
        [TestCase("22541", "1")]
        [TestCase("", "")]
        [TestCase("", "12")]
        [TestCase("", "12")]
        [TestCase("qwerty12345678", "12")]
        [TestCase("01234678974753", "a")]
        public void AuthPresenterLoginSuccessArgsValidationTest(string sessionID, string clientId)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.LoginSuccess(sessionID, clientId));
        }


        //testing whether LoginSuccess(string sessionID, string clientId) method calls router method
        [Test]
        public void AuthPresenterLoginSuccessRouterCallTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            var mockRouter = new Mock<IAuthRouter>(MockBehavior.Strict);
            string testSessionId = "01234678974753";
            string testClientId="15";
            mockRouter.Setup(m => m.MoveToChat(testSessionId, testClientId));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, mockRouter.Object);
            presenter.LoginSuccess(testSessionId, testClientId);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockRouter.Verify(m => m.MoveToChat(testSessionId, testClientId), Times.Once);
        }

        //testing null args validation in SignUp Success(string sessionID, string clientId) method
        [TestCase(null, "1")]
        [TestCase("10293847561213", null)]
        public void AuthPresenterSignUpSuccessNullArgsValidationTest(string sessionID, string clientId)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            Assert.Throws<ArgumentNullException>(() => presenter.SignUpSuccess(sessionID, clientId));
        }


        //testing args validation in SignUpSuccess(string sessionID, string clientId) method
        //session id must contain 14 chars, onlt numerals allowed
        //client id must contain nums only
        [TestCase("22541", "1")]
        [TestCase("", "")]
        [TestCase("", "12")]
        [TestCase("", "12")]
        [TestCase("qwerty12345678", "12")]
        [TestCase("01234678974753", "a")]
        public void AuthPresenterSignUpSuccessArgsValidationTest(string sessionID, string clientId)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.SignUpSuccess(sessionID, clientId));
        }


        //testing whether LoginSuccess(string sessionID, string clientId) method calls router method
        [Test]
        public void AuthPresenterSignUpSuccessRouterCallTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()));
            var mockRouter = new Mock<IAuthRouter>(MockBehavior.Strict);
            string testSessionId = "01234678974753";
            string testClientId = "15";
            mockRouter.Setup(m => m.MoveToChat(testSessionId, testClientId));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, mockRouter.Object);
            presenter.SignUpSuccess(testSessionId, testClientId);
            mockView.Verify(t => t.SetLocalizedData(It.IsAny<ILocalizedViewData>()), Times.Once);
            mockRouter.Verify(m => m.MoveToChat(testSessionId, testClientId), Times.Once);
        }
    }
}
