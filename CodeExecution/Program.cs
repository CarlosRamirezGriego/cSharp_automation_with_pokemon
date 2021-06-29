
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

            wpi.SearchForTheseSelectorsData(SearchBar);
            wpi.EnterTextInThisElement(SearchBar, "ThisIsWhatiWant");
            wpi.PressEnterInThisElement(SearchBar);
            Thread.Sleep(1000);
            wpi.CloseBrowser();


        }
    }
}

