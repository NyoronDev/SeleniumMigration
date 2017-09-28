using Autofac;
using CepsaMigration.Core.InjectionContainer;
using CepsaMigration.Core.Selenium.Contracts;

namespace ConsoleCepsaApp
{
    /// <summary>
    /// The program main.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var appContainer = new AppContainer();

            var loginPage = appContainer.SimpleContainer.Resolve<ILoginPage>();
            var adminMainPage = appContainer.SimpleContainer.Resolve<IAdminMainPage>();
            var postCodesPage = appContainer.SimpleContainer.Resolve<IPostCodesPage>();

            // Login page
            loginPage.GoToLoginPage();
            loginPage.LoginUser("dtmadmin", "abrete01");

            // AdminMain page
            adminMainPage.ClickUsers();
            adminMainPage.ClickPostCodes();

            // PostCodes page
            postCodesPage.SearchPostCodes();
        }
    }
}
