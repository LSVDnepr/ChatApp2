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
        //Testing Constructor
        //testing if constructor throws Argument null exception if service is null
        [Test]
        public void AuthInteractorConstructorServiceNullArgsTest()
        {
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            Assert.Throws<ArgumentNullException>(() => new AuthInteractor(null, presenter.Object));
        }


        //testing if constructor throws Argument null exception if presenter is null
        [Test]
        public void AuthInteractorConstructorPresenterNullArgsTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            Assert.Throws<ArgumentNullException>(() => new AuthInteractor(service.Object, null));
        }




        //Testing void OnLogin(string login, string password) method
        //testing if returns LoginFailType.Error if login argument is null 
        //testing if returns LoginFailType.Error if password argument is null 
        [TestCase(null, "42a")]
        [TestCase("login25",null)]
        public void AuthInteractorOnLoginNullLoginTest(string login, string password)
        {
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.LoginFail(LoginFailType.Error));
            IAuthInteractor interactor = new AuthInteractor(new Mock<IUserDataService>().Object, presenter.Object);
            interactor.OnLogin(login, password);
            presenter.Verify(t => t.LoginFail(LoginFailType.Error));

        }



        // testing that if service.AuthorizeUser is Ok , interactor calls presenter.loginSuccess() once
        [Test]
        public void AuthInteractorOnLoginEventHandlingTest()
        {
            string testSessionId = "10293847561213";
            string testLogin = "login_42";
            string testPassword = "pass42";
            string testUserId = "4825557";
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser(testLogin, testPassword)).Returns(testSessionId);
            service.Setup(t => t.GetUserIdBySessionId(testSessionId)).Returns(testUserId);
            presenter.Setup(t => t.LoginSuccess(testSessionId, testUserId));
            presenter.Raise(t => t.OnLogInAttempt += null, testLogin, testPassword);
            service.Verify(t => t.AuthorizeUser(testLogin, testPassword), Times.Once);
            service.Verify(t => t.GetUserIdBySessionId(testSessionId), Times.Once);
            presenter.Verify(t => t.LoginSuccess(testSessionId, testUserId), Times.Once);
        }




        [Test]
        public void AuthInteractorOnLoginEventHandlingUnknownErrorTest()
        {
            string testLogin = "login_42";
            string testPassword = "pass42";
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser(testLogin, testPassword)).Throws<Exception>();
            presenter.Setup(t => t.LoginFail(LoginFailType.Error));
            presenter.Raise(t => t.OnLogInAttempt += null, testLogin, testPassword);
            service.Verify(t => t.AuthorizeUser(testLogin, testPassword), Times.Once);
            presenter.Verify(t => t.LoginFail(LoginFailType.Error), Times.Once);
        }


       
        [Test]
        public void AuthInteractorOnLoginEventHandlingWrongLoginTest()
        {
            string testLogin = "login_42";
            string testPassword = "pass42";
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser(testLogin, testPassword)).Throws(new ChatAuthException(LoginFailType.WrongLogin));
            presenter.Setup(t => t.LoginFail(LoginFailType.WrongLogin));
            presenter.Raise(t => t.OnLogInAttempt += null, testLogin, testPassword);
            service.Verify(t => t.AuthorizeUser(testLogin, testPassword), Times.Once);
            presenter.Verify(t => t.LoginFail(LoginFailType.WrongLogin), Times.Once);
        }

        




        [Test]
        public void AuthInteractorOnSingUpEventHandlingTest()
        {
            string testSessionId = "10293847561213";
            string testLogin = "login_42";
            string testPassword = "pass42";
            string testTitle = "title2tst";
            string testUserId = "4825557";
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.RegisterUser(testLogin, testPassword,testTitle)).Returns(testSessionId);
            service.Setup(t => t.CheckLoginExists(testLogin)).Returns(false);
            service.Setup(t => t.GetUserIdBySessionId(testSessionId)).Returns(testUserId);
            presenter.Setup(t => t.SignUpSuccess(testSessionId, testUserId));
            presenter.Raise(t => t.OnSignUpAttempt += null, testLogin, testPassword,testTitle);
            service.Verify(t => t.RegisterUser(testLogin, testPassword, testTitle), Times.Once);
            service.Verify(t => t.CheckLoginExists(testLogin), Times.Once);
            service.Verify(t => t.GetUserIdBySessionId(testSessionId), Times.Once);
            presenter.Verify(t => t.SignUpSuccess(testSessionId, testUserId), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpLoginExistsTest()
        {

            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.CheckLoginExists("Login12")).Returns(true);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.LoginExists));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login12", "Password", "Title");
            service.Verify(t => t.CheckLoginExists("Login12"), Times.Once);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.LoginExists), Times.Once);
        }

      

        [Test]
        public void AuthInteractorOnSingUpErrorTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.CheckLoginExists("Login42")).Throws(new Exception("Unknown Error"));
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login42", "Pass42word", "Title42tst");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }

        [Test]
        public void AuthInteractorOnSingUpError2Test()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            service.Setup(t => t.AuthorizeUser("Login11", "Pass11word")).Throws(new Exception("Unknown Error"));
            service.Setup(t => t.CheckLoginExists("Login11")).Returns(false);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login11", "Pass11word", "Title11");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
            service.Verify(t => t.CheckLoginExists("Login11"), Times.Once);
        }

        //testing if throws argument null if login is null 
        [Test]
        public void AuthInteractorOnSingUpLoginNullTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, null, "Password12", "Title12");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }

        //testing if interactor validates login accordance to business requirements
        [TestCase("c")]//less than min length
        [TestCase("thisIsReallyLongLoginForTestingIfInteractorValidatesLoginMaximumLengthAccordingToProvidedBusinessRequirementsAndReturnsCorrectErrorInResponse")]//moreThanMaxLength
        [TestCase ("login 42")]//contains forbidden chars
        [TestCase("логин42")]//contains forbidden chars
        public void AuthInteractorOnSingUpLoginValidateTest(string login)
        {
            string testPass = "pass42tst";
            string testTitle = "title42tst";
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.LoginWrongFormat));
            presenter.Raise(t => t.OnSignUpAttempt += null, login, testPass, testTitle);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.LoginWrongFormat), Times.Once);
        }

        //testing if throws argument null if password is null 
        [Test]
        public void AuthInteractorOnSingUpPasswordNullTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login12", null, "Title12");
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }

        //testing if interactor validates password accordance to business requirements
        [TestCase("p")]//less than min length
        [TestCase("5")]//less than min length
        [TestCase("thisIsReallyLongPasswordForTestingIfInteractorValidatesPasswordMaximumLengthAccordingToProvidedBusinessRequirements")]//moreThanMaxLength
        [TestCase("пароль 42")]//contains forbidden chars
        [TestCase("password 42")]//contains forbidden chars
        [TestCase("password")]//contains letters only
        [TestCase("754654545")]//contains digits only     
        public void AuthInteractorOnSingUpPasswordValidateTest(string password)
        {
            string testLogin = "correctLogin";
            string testTitle = "title42tst";
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.PasswordWrongFormat));
            presenter.Raise(t => t.OnSignUpAttempt += null, testLogin, password, testTitle);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.PasswordWrongFormat), Times.Once);
        }

        



        //testing if throws argument null if title is null 
        [Test]
        public void AuthInteractorOnSingUpTitleNullTest()
        {
            var service = new Mock<IUserDataService>(MockBehavior.Strict);
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.Error));//может, прокинуть Argument null exception
            presenter.Raise(t => t.OnSignUpAttempt += null, "Login42", "Password42", null);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.Error), Times.Once);
        }

        //testing if interactor validates title accordance to business requirements
        [TestCase("t")]//less than min length
        [TestCase("thisIsReallyUserTitleForTestingIfInteractorValidatesUserTitleMaximumLengthAccordingToProvidedBusinessRequirementsAndReturnsCorrectErrorInResponse")]//moreThanMaxLength
        [TestCase("имя")]//containsForbiddenChars
        [TestCase("42Title")]//starts with digits;
        [TestCase("title#")]//containsForbiddenChars
        public void AuthInteractorOnSingUpTitleValidateTest(string title)
        {
            string testLogin = "correctLogin";
            string testPassword = "pass42tst";
            var presenter = new Mock<IAuthPresenter>(MockBehavior.Strict);
            presenter.Setup(t => t.SignUpFail(SignUpFailType.TitleWrongFormat));
            presenter.Raise(t => t.OnSignUpAttempt += null, testLogin, testPassword, title);
            presenter.Verify(t => t.SignUpFail(SignUpFailType.TitleWrongFormat), Times.Once);
        }





    }
}
