
using APIClients;
using AutomationClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PageObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using static AutomationClasses.AutomationOptions;

namespace CodeExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            WebPageInterface wpi = new WebPageInterface(TestBrowser.CHROME);
            wpi.LoadWebPage("https://www.google.com");
            wpi.MaximizeWindow();

            ElementInterface SearchBar = new ElementInterface("q", SearchMethod.NAME);
            SearchBar.ExpectNoMatches();

            wpi.SearchForTheseSelectorsData(SearchBar);
            wpi.EnterTextInThisElement(SearchBar, "ThisIsWhatiWant");
            wpi.ThisElementShouldNotBeVisible(SearchBar);
            wpi.ClickThisElement(SearchBar);

            Thread.Sleep(5000);
            wpi.CloseBrowser();


        }
    }
}

