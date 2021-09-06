﻿using OpenQA.Selenium;
using PageObjects;

namespace UIModules
{
    public class PokemonDBHomeModule
    {

        public WebPageAbstract _wp;


        public PokemonDBHomeModule(WebPageAbstract wp)
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
            if (_wp.IsThisElementPresent(homePageObject.ModalOkButton))
            {
                homePageObject.ClickOKModalButton();
                homePageObject.WaitForTheModalToNotBeDisplayedAnymore();
            }
        }
    }
}
