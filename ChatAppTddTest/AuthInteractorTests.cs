using System;
using NUnit.Framework;
using ChatAppTdd.Repository;
using Moq;
using ChatAppTdd.AuthModule;


namespace ChatAppTddTest
{
    [TestFixture]
    public class AuthInteractorTests
    {
        [Test]
        public void AuthInteractorConstructorPresenterNullArgsTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            Assert.Throws<ArgumentNullException>(() => new AuthInteractor(service.Object, null));
        }


        [Test]
        public void AuthInteractorConstructorServiceNullArgsTest()
        {
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            Assert.Throws<ArgumentNullException>(() => new AuthInteractor(null,presenter.Object));
        }


        //on login add args validation: not null, 
        
        //add custom validation for login
        //add custom validation for password
        //add custom validation for title

            //sessionId is 14 nums length


        //not empty - replace to presenter

        [Test]
        public void AuthInteractorOnLoginEventHandlingTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser("Login", "Password")).Returns("10293847561213");
            service.Setup(t => t.GetUserIdBySessionId("10293847561213")).Returns("1");
            presenter.Setup(t => t.LoginSuccess("10293847561213", "1"));
            presenter.Raise(t => t.OnLogInAttempt += null, "Login", "Password");
            service.Verify(t => t.AuthorizeUser("Login", "Password"), Times.Once);
            service.Verify(t => t.GetUserIdBySessionId("10293847561213"), Times.Once);
            presenter.Verify(t => t.LoginSuccess("10293847561213", "1"), Times.Once);
        }

        [Test]
        public void AuthInteractorOnLoginEventHandlingUnknownErrorTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser("Login", "Password")).Throws<Exception>();
            presenter.Setup(t => t.LoginFail(LoginFailType.Error));
            presenter.Raise(t => t.OnLogInAttempt += null, "Login", "Password");
            service.Verify(t => t.AuthorizeUser("Login", "Password"), Times.Once);
            presenter.Verify(t => t.LoginFail(LoginFailType.Error), Times.Once);
        }

        [Test]
        public void AuthInteractorOnLoginEventHandlingWrongLoginTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser("Login", "Password")).Throws(new ChatAuthException(LoginFailType.WrongLogin));
            presenter.Setup(t => t.LoginFail(LoginFailType.WrongLogin));
            presenter.Raise(t => t.OnLogInAttempt += null, "Login", "Password");
            service.Verify(t => t.AuthorizeUser("Login", "Password"), Times.Once);
            presenter.Verify(t => t.LoginFail(LoginFailType.Error), Times.Once);
        }

        //

        [Test]
        public void AuthInteractorOnSingUpEventHandlingTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.RegisterUser("Login", "Password","Title")).Returns("10293847561213");
            service.Setup(t => t.CheckLoginExists("Login")).Returns(false);
            service.Setup(t => t.GetUserIdBySessionId("10293847561213")).Returns("1");
            presenter.Setup(t => t.SignUpSuccess("10293847561213", "1"));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "Password","Title");
            service.Verify(t => t.RegisterUser("Login", "Password", "Title"), Times.Once);
            service.Verify(t => t.CheckLoginExists("Login"), Times.Once);
            service.Verify(t => t.GetUserIdBySessionId("10293847561213"), Times.Once);
            presenter.Verify(t => t.LoginSuccess("10293847561213", "1"), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpLoginExistsTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.CheckLoginExists("Login")).Returns(true);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.LoginExists));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "Password", "Title");
            service.Verify(t => t.CheckLoginExists("Login"), Times.Once);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.LoginExists), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpLoginFormatTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.LoginWrongFormat));
            presenter.Raise(t => t.OnSignUpAttempt += null, "1", "Password", "Title");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.LoginWrongFormat), Times.Once);
        }
        [Test]
        public void AuthInteractorOnSingUpLoginPasswordFormatTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.PasswordWrongFormat));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "123", "Title");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.PasswordWrongFormat), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpLoginTitleFormatTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.TitleWrongFormat));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "Password", "1");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.TitleWrongFormat), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpErrorTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.CheckLoginExists("Login")).Throws(new Exception("Unknown Error"));
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "Password", "Title");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpError2Test()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser("Login", "Password")).Throws(new Exception("BadError"));
            service.Setup(t => t.CheckLoginExists("Login")).Returns(false);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "Password", "Title");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
            service.Verify(t => t.CheckLoginExists("Login"), Times.Once);
        }


        [Test]
        public void AuthInteractorOnSingUpLoginNullTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, null, "Password", "Title");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }


        [Test]
        public void AuthInteractorOnSingUpPasswordNullTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", null, "Title");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }


        [Test]
        public void AuthInteractorOnSingUpTitleNullTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));//может, прокинуть Argument null exception
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login", "Password", null);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }
      
    }
}
