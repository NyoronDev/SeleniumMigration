using Autofac;
using CepsaMigration.Backend.Factory;
using CepsaMigration.Core.InjectionContainer;
using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Data.Entities;
using System;
using System.Collections.Generic;

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

            var factory = appContainer.SimpleContainer.Resolve<IFactory>();

            var loginPage = appContainer.SimpleContainer.Resolve<ILoginPage>();
            var adminMainPage = appContainer.SimpleContainer.Resolve<IAdminMainPage>();
            var postCodesPage = appContainer.SimpleContainer.Resolve<ISearchWorkCodePage>();
            var addStudyProgramPage = appContainer.SimpleContainer.Resolve<IAddStudyProgramPage>();

            IList<WorkCodeEntity> workCodeList;
            using (var dataService = factory.GetWorkCodeDataService())
            {
                workCodeList = dataService.ObtainWorkCodeList();
            }

            // Login page.
            loginPage.GoToLoginPage();
            loginPage.LoginUser("dtmadmin", "abrete01");

            var isFirstTimeUser = true;
            foreach (var workCode in workCodeList)
            {
                try
                {
                    Console.WriteLine($"Try to migrate WorkCode {workCode.WorkCodeId}");

                    // AdminMain page.
                    adminMainPage.ClickUsers(isFirstTimeUser);
                    adminMainPage.ClickPostCodes();

                    // PostCodes page.
                    postCodesPage.SearchPostCode(workCode.WorkCodeId);

                    // Study Program page.
                    adminMainPage.ClickStudyPrograms();

                    var isFirstTime = true;
                    foreach (var studyProgram in workCode.StudyPrograms)
                    {
                        // Add study program.
                        Console.WriteLine($"Try to add the study program {studyProgram}");

                        addStudyProgramPage.AddStudyProgramId(studyProgram, isFirstTime);
                        isFirstTime = false;

                        Console.WriteLine($"Study program {studyProgram} added correctly.");
                    }

                    Console.WriteLine($"WorkCode {workCode.WorkCodeId} added correctly.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error with WorkCode {workCode.WorkCodeId}");
                    Console.WriteLine($"With exception {ex.Message}");
                }

                isFirstTimeUser = false;
            }

            Console.ReadKey();
        }
    }
}
