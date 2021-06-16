using AutomationClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects
{
    public class NationalPokedexPage
    {

        public ElementInterface Generation1Link = new ElementInterface("a[href='#gen-1']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation2Link = new ElementInterface("a[href='#gen-2']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation3Link = new ElementInterface("a[href='#gen-3']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation4Link = new ElementInterface("a[href='#gen-4']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation5Link = new ElementInterface("a[href='#gen-5']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation6Link = new ElementInterface("a[href='#gen-6']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation7Link = new ElementInterface("a[href='#gen-7']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface Generation8Link = new ElementInterface("a[href='#gen-8']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface PokemonTile = new ElementInterface("a.ent-name", AutomationOptions.SearchMethod.CSS);
        public ElementInterface SpecificPokemonTile = new ElementInterface();
        public WebPageInterface _webPage;

        public NationalPokedexPage(WebPageInterface webPage)
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


        public ElementInterface MoveIntoViewToPokemonNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new ElementInterface("a.ent-name[href='" + link + "']", AutomationOptions.SearchMethod.CSS);
            _webPage.MoveIntoViewToThisElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }


        public ElementInterface ClickPokemonTileNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new ElementInterface("a.ent-name[href='" + link + "']", AutomationOptions.SearchMethod.CSS);
            _webPage.ClickThisElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

        public ElementInterface WaitForPokemonTileToBePresent(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new ElementInterface("a.ent-name[href='" + link + "']", AutomationOptions.SearchMethod.CSS);
            _webPage.SearchForTheseSelectorsData(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

    }
}
