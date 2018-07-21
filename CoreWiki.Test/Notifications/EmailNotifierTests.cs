using CoreWiki.Core.Configuration;
using CoreWiki.Notifications;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CoreWiki.Test.Notifications
{
    public class EmailNotifierTests
    {
        private const string RecipientEmail = "recipient_email";
        private const string RecipientName = "recipient_name";
        private const string Subject = "subject";
        private const string Body = "body";

        [Fact]
        public async Task SendEmail_ShouldReturnFalse_WhenSendGridApiKeyConfigurationIsNotSet()
        {
            var options = new AppSettings()
            {
                EmailNotifications = new EmailNotifications
                {
                    FromEmailAddress = "test@corewiki.com",
                    FromName = "Test CoreWiki",
                    SendGridApiKey = ""
                }
            };

            GetEmailNotifier(options, out var mockLogger, out var emailNotifier);

            var result = await emailNotifier.SendEmailAsync(RecipientEmail, Subject, Body);

            Assert.False(result);
            Assert.Contains($"Missing SendGridApiKey setting in {nameof(EmailNotifications)}", mockLogger.LoggedMessages);
        }

        [Fact]
        public async Task SendEmail_ShouldReturnFalse_WhenFromEmailConfigurationIsNotSet()
        {
            var options = new AppSettings()
            {
                EmailNotifications = new EmailNotifications
                {
                    FromEmailAddress = "",
                    FromName = "Test CoreWiki",
                    SendGridApiKey = "xxxxx"
                }
            };

            GetEmailNotifier(options, out var mockLogger, out var emailNotifier);

            var result = await emailNotifier.SendEmailAsync(RecipientEmail, Subject, Body);

            Assert.False(result);
            Assert.Contains($"Missing FromEmailAddress setting in {nameof(EmailNotifications)}", mockLogger.LoggedMessages);
        }

        [Fact]
        public async Task SendEmail_ShouldReturnFalse_WhenFromNameConfigurationIsNotSet()
        {
            var options = new AppSettings()
            {
                EmailNotifications = new EmailNotifications
                {
                    FromEmailAddress = "test@corewiki.com",
                    FromName = "",
                    SendGridApiKey = "xxxxx"
                }
            };

            GetEmailNotifier(options, out var mockLogger, out var emailNotifier);

            var result = await emailNotifier.SendEmailAsync(RecipientEmail, Subject, Body);

            Assert.False(result);
            Assert.Contains($"Missing FromName setting in {nameof(EmailNotifications)}", mockLogger.LoggedMessages);
        }

        [Fact]
        public async Task SendEmail_ShouldReturnFalse_WhenRecipientEmailIsEmptyString()
        {
            var options = new AppSettings()
            {
                EmailNotifications = new EmailNotifications
                {
                    FromEmailAddress = "test@corewiki.com",
                    FromName = "Test CoreWiki",
                    SendGridApiKey = "xxxxx"
                }
            };

            GetEmailNotifier(options, out var mockLogger, out var emailNotifier);

            var result = await emailNotifier.SendEmailAsync(string.Empty, Subject, Body);

            Assert.False(result);
            Assert.Contains("Missing recipient email, email message not sent", mockLogger.LoggedMessages);
        }

        private static void GetEmailNotifier(AppSettings options, out MockLogger<EmailNotifier> mockLogger, out EmailNotifier emailNotifier)
        {
            mockLogger = new MockLogger<EmailNotifier>();
            var optionsMock = new Mock<IOptionsSnapshot<AppSettings>>();
            optionsMock.Setup(x => x.Value).Returns(options);

            var loggerFactoryMock = new Mock<MockLoggerFactory>();
            loggerFactoryMock.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(mockLogger);
            loggerFactoryMock.Setup(x => x.CreateLogger<EmailNotifier>()).Returns(mockLogger);

            emailNotifier = new EmailNotifier(optionsMock.Object, loggerFactoryMock.Object);
        }
    }
}
