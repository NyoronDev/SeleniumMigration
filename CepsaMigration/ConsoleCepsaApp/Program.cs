using Autofac;
using CepsaMigration.Backend.Factory;
using CepsaMigration.Core.InjectionContainer;
using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Data.Entities;
using CepsaMigration.Data.TypeSafeEnum;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleCepsaApp
{
    /// <summary>
    /// The program main.
    /// </summary>
    public class Program
    {
        private static ILoginPage loginPage;
        private static IAdminMainPage adminMainPage;
        private static ISearchWorkCodePage workCodesPage;
        private static IAddStudyProgramPage addStudyProgramPage;

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var appContainer = new AppContainer();

            var factory = appContainer.SimpleContainer.Resolve<IFactory>();

            loginPage = appContainer.SimpleContainer.Resolve<ILoginPage>();
            adminMainPage = appContainer.SimpleContainer.Resolve<IAdminMainPage>();
            workCodesPage = appContainer.SimpleContainer.Resolve<ISearchWorkCodePage>();
            addStudyProgramPage = appContainer.SimpleContainer.Resolve<IAddStudyProgramPage>();

            Console.WriteLine("Migrating from excel...");

            IList<WorkCodeEntity> workCodeList;
            using (var dataService = factory.GetWorkCodeDataService())
            {
                workCodeList = dataService.ObtainWorkCodeList();
            }

            Console.WriteLine("Excel migrated");

            // Login page.
            loginPage.GoToLoginPage();
            loginPage.LoginUser("dtmadmin", "abrete01");

            var isFirstTimeUser = true;
            foreach (var workCode in workCodeList)
            {
                AddWorkCode(true, isFirstTimeUser, workCode);
                isFirstTimeUser = false;
            }

            stopWatch.Stop();
            Console.WriteLine($"Program finished with {stopWatch.Elapsed.Seconds} seconds");
            Console.ReadKey();
        }

        /// <summary>
        /// Adds the work code.
        /// </summary>
        /// <param name="isFirstAttempt">if set to <c>true</c> [is first attempt].</param>
        /// <param name="isFirstTimeUser">if set to <c>true</c> [is first time user].</param>
        /// <param name="workCode">The work code.</param>
        private static void AddWorkCode(bool isFirstAttempt, bool isFirstTimeUser, WorkCodeEntity workCode)
        {
            try
            {
                Console.WriteLine($"---------------------------------------------");
                Console.WriteLine($"Try to migrate WorkCode {workCode.WorkCodeId}");

                // AdminMain page.
                adminMainPage.ClickUsers(isFirstTimeUser);
                adminMainPage.ClickPostCodes();

                // PostCodes page.
                workCodesPage.SearchWorkCode(workCode.WorkCodeId);

                if (workCode.DataType == DataType.StudyPrograms)
                {
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
                    Console.WriteLine($"---------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with WorkCode {workCode.WorkCodeId}");
                Console.WriteLine($"With exception {ex.Message}");
                Console.WriteLine($"---------------------------------------------");

                if (isFirstAttempt)
                {
                    AddWorkCode(false, false, workCode);
                }
            }
        }
    }
}
