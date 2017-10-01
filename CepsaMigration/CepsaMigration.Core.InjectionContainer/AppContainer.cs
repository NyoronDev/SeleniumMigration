using Autofac;
using CepsaMigration.Backend.Factory;
using CepsaMigration.Core.Selenium;
using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using CepsaMigration.Data.DataService;
using CepsaMigration.Data.DataService.Contracts;

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
            buildContainer.RegisterType<WorkCodeDataService>().As<IWorkCodeDataService>();
            buildContainer.RegisterType<Factory>().As<IFactory>();
            buildContainer.RegisterType<SetUpSeleniumWebDriver>().As<ISetUpSeleniumWebDriver>();
            buildContainer.RegisterType<LoginPage>().As<ILoginPage>();
            buildContainer.RegisterType<AdminMainPage>().As<IAdminMainPage>();
            buildContainer.RegisterType<SearchWorkCodePage>().As<ISearchWorkCodePage>();
            buildContainer.RegisterType<AddProfilePage>().As<IAddProfilePage>();
            
            SimpleContainer = buildContainer.Build();
        }
    }
}
