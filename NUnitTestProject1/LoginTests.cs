using NUnit.Framework;
using TwitterCloneAPI;
using TwitterCloneAPI.DataSource;
using TwitterCloneAPI.Misc;
using TwitterCloneAPI.Models;

namespace NUnitTestProject1
{
    public class LoginTests
    {
        [SetUp]
        public void Setup()
        {
            Startup.thesource = new FixedSource();
        }

        [Test]
        public void LoginSuccess()
        {
            clientLoginModel LoginModel = new clientLoginModel();
            LoginModel.Username = "Admin";
            LoginModel.Password = "admin";

            LoginCheck checkLogin = new LoginCheck();
            clientUser clientUserModel = checkLogin.Check(LoginModel);

            Assert.That(clientUserModel.Username == LoginModel.Username);
        }

        [Test]
        public void LoginFailure()
        {
            clientLoginModel LoginModel = new clientLoginModel();
            LoginModel.Username = "Admin";
            LoginModel.Password = "Invalid";

            LoginCheck checkLogin = new LoginCheck();
            clientUser clientUserModel = checkLogin.Check(LoginModel);

            Assert.That(clientUserModel == null);
        }
    }
}