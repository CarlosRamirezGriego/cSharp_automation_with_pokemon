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
        public ElementAbstract InfoLink = new ElementAbstract("a[href='#dex-basics']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract BaseStatsLink = new ElementAbstract("a[href='#dex-stats']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract EvolutionChartLink = new ElementAbstract("a[href='#dex-evolution']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract PokedexEntriesLink = new ElementAbstract("a[href='#dex-flavor']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract MovesLearnedLink = new ElementAbstract("a[href='#dex-moves']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract SpritesLink = new ElementAbstract("a[href='#dex-sprites']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract LocationsLink = new ElementAbstract("a[href='#dex-locations']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract LanguageLink = new ElementAbstract("a[href='#dex-lang']", AutomationOptions.SearchMethod.CSS);
        public WebPageAbtract _webPage;

        public PokemonDetailPageNavigationBar(WebPageAbtract webPage)
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
