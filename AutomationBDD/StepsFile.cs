using AutomationClasses;
using NUnit.Framework;
using PageObjects;
using PokemonAPI;
using PokemonAPIFeature;
using RestSharp;
using StatsManagement;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using UIModules;

namespace AutomationBDD
{
    [Binding]
    public sealed class StepsFile
    {

        public Dictionary<string, EVManagement> evObjects = new Dictionary<string, EVManagement>();
        public bool _isBrowserOpen = false;
        public bool _isWebTest = false;
        public WebPageInterface _wp;
        public PokemonEndpoint _pe;
        public string _targetPokemon;
        public Dictionary<string, IRestResponse> responses = new Dictionary<string, IRestResponse>();

        [AfterScenario]
        public void AfterScenario()
        {
            if (_isWebTest && _isBrowserOpen)
            {
                _wp.CloseBrowser();
            }
        }

        #region API Tests Steps

        #region Pokemon GET Endpoint
        [Given(@"that the test user selects the '(.*)' Pokemon to retrieve information")]
        public void TheTestUserSelectsThePokemonToRetrieveInformation(string p0)
        {
            _pe = new PokemonEndpoint(EnvironmentData.pokemonAPIURL);
            _targetPokemon = p0;
        }


        [When(@"the test user queries the API with the test Pokemon name")]
        public void TheTestUserQueriesTheAPIWithTheTestPokemonName()
        {
            IRestResponse response = _pe.RetrievePokemonInformation(_targetPokemon);
            responses.Add("PokemonEndpoint", response);
        }


        [Then(@"the user should '(.*)' receive information")]
        public void ThenTheUserShouldReceiveInformation(bool p0)
        {
            IRestResponse response = responses["PokemonEndpoint"];
            int code = (int)response.StatusCode;
            if (p0)
            {
                Assert.AreEqual(200, code);
            }
            else
            {
                Assert.AreEqual(404, code);
            }
        }



        #endregion
        #endregion

        #region UI Tests Steps

        #region Pokedex DB Home region
        [Given(@"that the test user has loaded the PokemonDB Page")]
        public void TheTestUserHasLoadedThePokemonDBPage()
        {
            if (!_isBrowserOpen)
            {
                _wp = new WebPageInterface(AutomationOptions.TestBrowser.CHROME);
                _wp.MaximizeWindow();
                _isBrowserOpen = true;
                _isWebTest = true;
            }
            PokemonDBHomeModule dbHome = new PokemonDBHomeModule(_wp);
            dbHome.GoToThisPage();
            dbHome.CloseModalIfPresent();
        }


        [Given(@"that the test user has navigated to the National Pokedex page using the Quicklink")]
        public void TheTestUserHasNavigatedToTheNationalPokedexPageUsingTheQuicklink()
        {
            PokemonDBHomeModule dbHome = new PokemonDBHomeModule(_wp);
            dbHome.UserClicksNationalPokedexQuickLink();
        }

        #endregion

        #region Pokedex List Page region

        [When(@"the test user clicks over the '(.*)' from the list")]
        public void WhenTheTestUserClicksOverTheFromTheList(string p0)
        {
            NationalPokedexPageModule dexPageModule = new NationalPokedexPageModule(_wp);
            dexPageModule.UserClicksPokemonFromTheList(p0);
        }
        #endregion


        #region Pokemon Detail Page region

        [Then(@"the test user should be redirected to the '(.*)' Pokemon detail page")]
        public void ThenTheTestUserShouldBeRedirectedToThePokemonDetailPage(string p0)
        {
            PokemonDetailPageModule detailPage = new PokemonDetailPageModule(_wp);
            string nameInPage = detailPage.FindPokemonNameInPage();
            Assert.AreEqual(p0, nameInPage);
        }
        #endregion

        #endregion

        #region Code Tests Steps

        [Given(@"that the user has generated an EV Management Object")]
        public void GivenThatTheUserHasGeneratedAnEVManagementObject()
        {
            EVManagement evObject = new EVManagement();
            evObjects.Add("evObject", evObject);
        }

        [Given(@"that the test user has allocated '(.*)' HP points already")]
        public void GivenThatTheTestUserHasAddedAllocatedHPPointsAlready(string p0)
        {
            int value = Int32.Parse(p0);
            evObjects["evObject"].AddEVPointsToHP(value);
        }

        [When(@"the test user adds '(.*)' more points to the HP")]
        public void WhenTheTestUserAddsMorePointsToTheHP(string p0)
        {
            int value = Int32.Parse(p0);
            evObjects["evObject"].AddEVPointsToHP(value);
        }

        [Then(@"the HP allocated points should be '(.*)'")]
        public void ThenTheHPAllocatedPointsShouldBe(string p0)
        {
            int actualEV = evObjects["evObject"].hp;
            int expectedEV = Int32.Parse(p0);
            Assert.AreEqual(expectedEV, actualEV);
        }

        #endregion
    }
}
