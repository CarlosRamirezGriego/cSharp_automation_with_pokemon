using OpenQA.Selenium;
using PageObjects;

namespace UIModules
{
    public class PokemonDBHomeModule
    {

        public WebPageInterface _wp;


        public PokemonDBHomeModule(WebPageInterface wp)
        {
            _wp = wp;
        }


        public void GoToThisPage()
        {
            _wp.LoadWebPage("https://pokemondb.net/");
        }


        public void UserClicksNationalPokedexQuickLink()
        {
            PokemonDBHome homePageObject = new PokemonDBHome(_wp);
            homePageObject.ClickNationalDexLink();
        }

        public void CloseModalIfPresent()
        {
            PokemonDBHome homePageObject = new PokemonDBHome(_wp);
            try
            {
                homePageObject.ClickOKModalButton();
                homePageObject.WaitForTheModalToNotBeDisplayedAnymore();
            }
            catch { 

            }
        }
    }
}
