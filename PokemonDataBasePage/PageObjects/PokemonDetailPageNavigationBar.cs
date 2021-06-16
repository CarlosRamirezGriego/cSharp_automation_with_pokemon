using AutomationClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPageNavigationBar
    {
        public ElementInterface InfoLink = new ElementInterface("a[href='#dex-basics']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface BaseStatsLink = new ElementInterface("a[href='#dex-stats']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface EvolutionChartLink = new ElementInterface("a[href='#dex-evolution']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface PokedexEntriesLink = new ElementInterface("a[href='#dex-flavor']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface MovesLearnedLink = new ElementInterface("a[href='#dex-moves']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface SpritesLink = new ElementInterface("a[href='#dex-sprites']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface LocationsLink = new ElementInterface("a[href='#dex-locations']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface LanguageLink = new ElementInterface("a[href='#dex-lang']", AutomationOptions.SearchMethod.CSS);
        public WebPageInterface _webPage;

        public PokemonDetailPageNavigationBar(WebPageInterface webPage)
        {
                _webPage = webPage;
        }

        public void ClickInfoLink()
        {
            _webPage.ClickThisElement(InfoLink);
        }

        public void ClickBaseStatsLink()
        {
            _webPage.ClickThisElement(BaseStatsLink);
        }

    }
}
