using AutomationClasses;
using NUnit.Framework;
using PageObjects;
using UIModules;

namespace AutomationATDD
{
    public class PokemonDetailPageModuleTests
    {
        public WebPageAbstract _wp;
        public bool isWebTest = false;

        [TearDown]
        public void BaseTearDown()
        {
            if (isWebTest)
            {
                _wp.CloseBrowser();
            }
        }

        [Test]
        [TestCase("Pikachu")]
        [TestCase("Mewtwo")]
        public void MakeSurePokemonDetailPageHeaderDisplaysTheRightData(string name)
        {
            isWebTest = true;
            _wp = new WebPageAbstract (AutomationOptions.TestBrowser.CHROME);
            PokemonDBHomeModule dbHome = new PokemonDBHomeModule(_wp);
            dbHome.GoToThisPage();
            dbHome.CloseModalIfPresent();
            dbHome.UserClicksNationalPokedexQuickLink();
            NationalPokedexPageModule dexPageModule = new NationalPokedexPageModule(_wp);
            dexPageModule.UserClicksPokemonFromTheList(name);
            PokemonDetailPageModule detailPage = new PokemonDetailPageModule(_wp);
            string nameInPage = detailPage.FindPokemonNameInPage();
            Assert.AreEqual(name, nameInPage);
        }
    }
}
