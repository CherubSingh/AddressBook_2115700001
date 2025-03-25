using NUnit.Framework;
using Moq;
using AddressBook.HelperService;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;

namespace AddressBooktest.TestCases
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private IAuthenticationService _authService;
        private Mock<IConfiguration> _mockConfig;

        [SetUp]
        public void Setup()
        {
            _mockConfig = new Mock<IConfiguration>();
            _mockConfig.Setup(c => c["Jwt:Key"]).Returns("TestSecretKeywfbwejfbwkejfbwkejfbwjeffwbkjefbewjfcbw");
            _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");

            _authService = new TokenService(_mockConfig.Object);
        }

        [Test]
        public void GenerateToken_ValidUser_ReturnsToken()
        {
            var user = new User { Id = 1, Username = "testuser", Role = "User" };
            var token = _authService.GenerateToken(user);
            Assert.That(token, Is.Not.Null);
            Assert.That(token.Length, Is.GreaterThan(10)); // Ensure token is generated
        }
    }
}
