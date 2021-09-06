using AutomationClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects
{
    public class NationalPokedexPage
    {

        public ElementAbstract Generation1Link = new ElementAbstract("a[href='#gen-1']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation2Link = new ElementAbstract("a[href='#gen-2']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation3Link = new ElementAbstract("a[href='#gen-3']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation4Link = new ElementAbstract("a[href='#gen-4']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation5Link = new ElementAbstract("a[href='#gen-5']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation6Link = new ElementAbstract("a[href='#gen-6']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation7Link = new ElementAbstract("a[href='#gen-7']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract Generation8Link = new ElementAbstract("a[href='#gen-8']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract PokemonTile = new ElementAbstract("a.ent-name", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract SpecificPokemonTile = new ElementAbstract();
        public WebPageAbstract _webPage;

        public NationalPokedexPage(WebPageAbstract webPage)
        {
            _webPage = webPage;
        }


        public void ClickGeneration1Link()
        {
            Generation1Link = _webPage.SearchForTheseSelectorsData(Generation1Link);
            _webPage.ClickThisElement(Generation1Link);
        }

        public void ClickGeneration2Link()
        {
            Generation2Link = _webPage.SearchForTheseSelectorsData(Generation2Link);
            _webPage.ClickThisElement(Generation2Link);
        }

        public void ClickGeneration3Link()
        {
            Generation3Link = _webPage.SearchForTheseSelectorsData(Generation3Link);
            _webPage.ClickThisElement(Generation3Link);
        }

        public void ClickGeneration4Link()
        {
            Generation4Link = _webPage.SearchForTheseSelectorsData(Generation4Link);
            _webPage.ClickThisElement(Generation4Link);
        }

        public void ClickGeneration5Link()
        {
            Generation5Link = _webPage.SearchForTheseSelectorsData(Generation5Link);
            _webPage.ClickThisElement(Generation5Link);
        }

        public void ClickGeneration6Link()
        {
            Generation6Link = _webPage.SearchForTheseSelectorsData(Generation6Link);
            _webPage.ClickThisElement(Generation6Link);
        }

        public void ClickGeneration7Link()
        {
            Generation7Link = _webPage.SearchForTheseSelectorsData(Generation7Link);
            _webPage.ClickThisElement(Generation7Link);
        }
        public void ClickGeneration8Link()
        {
            Generation8Link = _webPage.SearchForTheseSelectorsData(Generation8Link);
            _webPage.ClickThisElement(Generation8Link);
        }


        public ElementAbstract MoveIntoViewToPokemonNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new ElementAbstract("a.ent-name[href='" + link + "']", AutomationOptions.SearchMethod.CSS);
            _webPage.MoveIntoViewToThisElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }


        public ElementAbstract ClickPokemonTileNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new ElementAbstract("a.ent-name[href='" + link + "']", AutomationOptions.SearchMethod.CSS);
            _webPage.ClickThisElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

        public ElementAbstract WaitForPokemonTileToBePresent(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new ElementAbstract("a.ent-name[href='" + link + "']", AutomationOptions.SearchMethod.CSS);
            _webPage.SearchForTheseSelectorsData(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

    }
}
