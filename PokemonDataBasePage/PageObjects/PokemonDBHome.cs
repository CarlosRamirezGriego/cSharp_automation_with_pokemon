using AutomationClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDBHome
    {
        public ElementInterface NationalDexQuickLink = new ElementInterface("main[id='main'] a[href='/pokedex/national']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface ModalOkButton = new ElementInterface("button[class='btn btn-primary gdpr-accept']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface PrivacyModal = new ElementInterface("gdpr-confirm", AutomationOptions.SearchMethod.ID);
        public WebPageInterface _webPage;

        public PokemonDBHome(WebPageInterface webPage)
        {
                _webPage = webPage;
        }


        public void ThePrivacyModalIsPresent()
        {
            WebPageInterface wp = new WebPageInterface(_webPage.testDriver);
            wp.SearchForTheseSelectorsData(PrivacyModal);
        }

        public void WaitForTheModalToNotBeDisplayedAnymore()
        {
            WebPageInterface wp = new WebPageInterface(_webPage.testDriver);
            wp.ThisElementShouldNotBeVisible(PrivacyModal);
        }


        public void ClickOKModalButton()
        {
            WebPageInterface wp = new WebPageInterface(_webPage.testDriver);
            wp.ClickThisElement(ModalOkButton);
        }


        public void ClickNationalDexLink()
        {
            WebPageInterface wp = new WebPageInterface(_webPage.testDriver);
            wp.ClickThisElement(NationalDexQuickLink);
        }



    }
}
