using Autofac;
using CepsaMigration.Core.Selenium;
using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;

namespace CepsaMigration.Core.InjectionContainer
{
    /// <summary>
    /// The App Container class.
    /// </summary>
    public class AppContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppContainer"/> class.
        /// </summary>
        public AppContainer()
        {
            SetUpContainer();
        }

        /// <summary>
        /// Gets the simple container.
        /// </summary>
        /// <value>
        /// The simple container.
        /// </value>
        public IContainer SimpleContainer { get; private set; }

        private void SetUpContainer()
        {
            var buildContainer = new ContainerBuilder();
            buildContainer.RegisterType<SetUpSeleniumWebDriver>().As<ISetUpSeleniumWebDriver>();
            buildContainer.RegisterType<LoginPage>().As<ILoginPage>();

            SimpleContainer = buildContainer.Build();
        }
    }
}
