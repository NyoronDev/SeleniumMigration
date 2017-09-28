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

            loginPage.GoToLoginPage();
            loginPage.LoginUser("asdf", "fdsa");
        }
    }
}
