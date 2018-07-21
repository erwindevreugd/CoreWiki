using CoreWiki.Core.Notifications;
using CoreWiki.Notifications;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CoreWiki.Test.Notifications
{
    public class StartupExtensionsTests
    {
        [Fact]
        public void Test1()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            serviceCollection.AddSingleton<ITempDataProvider>(new MockTempDataProvider());
            serviceCollection.AddSingleton<IRazorViewEngine>(new MockRazorViewEngine());

            serviceCollection.AddEmailNotifications();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Assert.NotNull(serviceProvider.GetService<IEmailMessageFormatter>());
            Assert.NotNull(serviceProvider.GetService<IEmailNotifier>());
            Assert.NotNull(serviceProvider.GetService<INotificationService>());
            Assert.NotNull(serviceProvider.GetService<ITemplateParser>());
            Assert.NotNull(serviceProvider.GetService<ITemplateProvider>());
        }
    }
}
