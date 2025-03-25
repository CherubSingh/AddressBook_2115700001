using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using AddressBook.HelperService;
using System.IO;
using System.Threading.Tasks;

namespace AddressBooktest.TestCases
{
    [TestFixture]
    public class EmailServiceTests
    {
        private EmailService _emailService;

        [SetUp]
        public void Setup()
        {
            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _emailService = new EmailService(config);
        }

        [Test]
        public async Task SendEmailAsync_ValidInput_SendsEmail()
        {
            // Arrange - Provide a real recipient email
            string toEmail = "somilgupta091@gmail.com";
            string subject = "Test Email from NUnit";
            string body = "This is a real email test using SMTP.";

            // Act & Assert - Ensure no exceptions occur during sending
            Assert.DoesNotThrowAsync(async () => await _emailService.SendEmailAsync(toEmail, subject, body));
        }
    }
}
