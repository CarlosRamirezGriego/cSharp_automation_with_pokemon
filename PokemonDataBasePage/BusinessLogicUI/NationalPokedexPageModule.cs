using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIModules
{
    public class NationalPokedexPageModule
    {
        public WebPageAbstract _wp;


        public NationalPokedexPageModule(WebPageAbstract wp)
        {
            _wp = wp;
        }

        public void GoToThisPage()
        {
            _wp.LoadWebPage("https://pokemondb.net/pokedex/national");
        }


        public void UserClicksPokemonFromTheList(string name)
        {
            NationalPokedexPage dexPage = new NationalPokedexPage(_wp);
            dexPage.WaitForPokemonTileToBePresent(name);
            dexPage.MoveIntoViewToPokemonNamed(name);
            dexPage.ClickPokemonTileNamed(name);
        }



    }
}
