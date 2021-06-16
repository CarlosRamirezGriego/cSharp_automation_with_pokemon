using AutomationClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPagePokedex
    {
        public ElementInterface PokemonNameHeader = new ElementInterface("main[id='main']>h1", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer = new ElementInterface("div[class='tabs-panel active'][id^='tab-basic-']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_DataContainer = new ElementInterface("div:nth-child(1)>div[class$='text-center']+div:nth-child(2)>h2+table.vitals-table", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_DataContainer_NationalDexNumber = new ElementInterface("tbody>tr:nth-child(1) >td", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_DataContainer_PokemonTypes = new ElementInterface("tbody>tr:nth-child(2)>td>a", AutomationOptions.SearchMethod.CSS);
        public WebPageInterface _webPage;

        public PokemonDetailPagePokedex(WebPageInterface webPage)
        {
                _webPage = webPage;
        }

        public void FindNationalDexNumberLabel()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_DataContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_DataContainer);
            TabBasicContainer_DataContainer_NationalDexNumber = _webPage.SearchForTheseSelectorsData(TabBasicContainer_DataContainer, TabBasicContainer_DataContainer_NationalDexNumber);
        }

        public void FindPokemonNameHeaderLabel()
        {
            PokemonNameHeader = _webPage.SearchForTheseSelectorsData(PokemonNameHeader);
        }

        public void FindPokemonTypesLabels()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_DataContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_DataContainer);
            TabBasicContainer_DataContainer_PokemonTypes = _webPage.SearchForTheseSelectorsData(TabBasicContainer_DataContainer, TabBasicContainer_DataContainer_PokemonTypes);
        }

    }
}
