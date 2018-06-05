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







    }
}
