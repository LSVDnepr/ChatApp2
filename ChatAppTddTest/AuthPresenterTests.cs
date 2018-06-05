using System;
using NUnit.Framework;
using Moq;
using ChatAppTdd.AuthModule;

namespace ChatAppTddTest
{
    [TestFixture]
    public class AuthPresenterTests
    {      

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


        //on view event on login btn pressed invokes OnLoginAttempt
        [Test]
        public void AuthPresenterOnLoginEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            var mockInteractor = new Mock<IAuthInteractor>(MockBehavior.Strict);
            mockInteractor.Setup(t => t.OnLogin("Login", "Password"));
            AuthPresenter presenter = new AuthPresenter(mockView.Object,new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLoginBtnPressed += null, "Login", "Password");
            mockInteractor.Verify(t => t.OnLogin("Login", "Password"), Times.Once);

        }

        //testing null args validation in LoginSuccess(string sessionID, string clientId) method
        [TestCase(null,"1")]
        [TestCase("10293847561213", null)]
        public void AuthPresenterLoginSuccessNullArgsValidationTest(string sessionID, string clientId)
        {
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);

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
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.LoginSuccess(sessionID, clientId));

        }


        //testing whether LoginSuccess(string sessionID, string clientId) method calls router method
        [Test]
        public void AuthPresenterLoginSuccessRouterCallTest()
        {
            var mockRouter = new Mock<IAuthRouter>(MockBehavior.Strict);
            string testSessionId = "01234678974753";
            string testClientId="15";
            mockRouter.Setup(m => m.MoveToChat(testSessionId, testClientId));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, mockRouter.Object);
            presenter.LoginSuccess(testSessionId, testClientId);
            mockRouter.Verify(m => m.MoveToChat(testSessionId, testClientId), Times.Once);
        }



        //on view event on signup btn pressed invokes OnSignUpAttempt
        [Test]
        public void AuthPresenterOnSignUpEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            var mockInteractor = new Mock<IAuthInteractor>(MockBehavior.Strict);
            mockInteractor.Setup(t => t.OnSignUp("Login", "Password", "Title"));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnSignUpBtnPressed += null, "Login", "Password","Title");
            mockInteractor.Verify(t => t.OnSignUp("Login", "Password","Title"), Times.Once);

        }

        //testing null args validation in SignUp Success(string sessionID, string clientId) method
        [TestCase(null, "1")]
        [TestCase("10293847561213", null)]
        public void AuthPresenterSignUpSuccessNullArgsValidationTest(string sessionID, string clientId)
        {
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
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
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, new Mock<IAuthRouter>().Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.SignUpSuccess(sessionID, clientId));

        }


        //testing whether LoginSuccess(string sessionID, string clientId) method calls router method
        [Test]
        public void AuthPresenterSignUpSuccessRouterCallTest()
        {
            var mockRouter = new Mock<IAuthRouter>(MockBehavior.Strict);
            string testSessionId = "01234678974753";
            string testClientId = "15";
            mockRouter.Setup(m => m.MoveToChat(testSessionId, testClientId));
            IAuthPresenter presenter = new AuthPresenter(new Mock<IAuthView>().Object, mockRouter.Object);
            presenter.SignUpSuccess(testSessionId, testClientId);
            mockRouter.Verify(m => m.MoveToChat(testSessionId, testClientId), Times.Once);

        }


        //on view event localechanged calls set Localized Data with english localized data

        [Test]
        public void AuthPresenterOnLocaleChangedEnEventHandlingTest()
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(new EnLocalizedViewData()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLocaleChanged += null, LocalesSupported.En);
            mockView.Verify(t => t.SetLocalizedData(new EnLocalizedViewData()), Times.Once);
      
        }


        //on view event localechanged calls set Localized Data with russian localized data
        [Test]
        public void AuthPresenterOnLocaleChangedRusEventHandlingTest()
        {

            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup(t => t.SetLocalizedData(new RuLocalizedViewData()));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object);
            mockView.Raise(t => t.OnLocaleChanged += null, LocalesSupported.Ru);
            mockView.Verify(t => t.SetLocalizedData(new RuLocalizedViewData()), Times.Once);

        }



        //testing whether on login failed ShowErrorMessage(string message) is called with proper args
        [TestCase(LocalesSupported.En, LoginFailType.Error, "Error. Try again later")]
        [TestCase(LocalesSupported.Ru, LoginFailType.Error, "Ошибка. Повторите позже")]
        [TestCase(LocalesSupported.En, LoginFailType.WrongLogin, "Login does not exist")]
        [TestCase(LocalesSupported.Ru, LoginFailType.WrongLogin, "Указанный логин не существует")]
        public void AuthPresenterOnLOginFailShowErrorTest(LocalesSupported locale, LoginFailType failType, string message)
        {

            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup((m => m.ShowErrorMessage(message)));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object, locale);
            presenter.LoginFail(failType);
            mockView.Verify(m => m.ShowErrorMessage(message), Times.Once);
        }


        //testing whether on sign up failed ShowErrorMessage(string message) is called with proper args
        [TestCase(LocalesSupported.En, SignUpFailType.LoginExists, "Login already exists")]
        [TestCase(LocalesSupported.Ru, SignUpFailType.LoginExists, "Указанный логин уже существует")]
        [TestCase(LocalesSupported.En, SignUpFailType.Error, "Error. Try again later")]
        [TestCase(LocalesSupported.Ru, SignUpFailType.Error, "Ошибка. Повторите позже")]
        public void AuthPresenterOnSignUpFailShowErrorTest(LocalesSupported locale, SignUpFailType failType, string message)
        {
            var mockView = new Mock<IAuthView>(MockBehavior.Strict);
            mockView.Setup((m => m.ShowErrorMessage(message)));
            AuthPresenter presenter = new AuthPresenter(mockView.Object, new Mock<IAuthRouter>().Object, locale);
            presenter.SignUpFail(failType);
            mockView.Verify(m => m.ShowErrorMessage(message), Times.Once);
        }

       




    }
}
