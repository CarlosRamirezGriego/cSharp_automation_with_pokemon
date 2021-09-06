using AutomationClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDBHome
    {
        public ElementAbstract NationalDexQuickLink = new ElementAbstract("main[id='main'] a[href='/pokedex/national']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract ModalOkButton = new ElementAbstract("button[class='btn btn-primary gdpr-accept']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract PrivacyModal = new ElementAbstract("gdpr-confirm", AutomationOptions.SearchMethod.ID);
        public WebPageAbtract _webPage;

        public PokemonDBHome(WebPageAbtract webPage)
        {
                _webPage = webPage;
        }


        public void ThePrivacyModalIsPresent()
        {
            WebPageAbtract wp = new WebPageAbtract(_webPage.testDriver);
            wp.SearchForTheseSelectorsData(PrivacyModal);
        }

        public void WaitForTheModalToNotBeDisplayedAnymore()
        {
            WebPageAbtract wp = new WebPageAbtract(_webPage.testDriver);
            wp.ThisElementShouldNotBeVisible(PrivacyModal);
        }


        public void ClickOKModalButton()
        {
            WebPageAbtract wp = new WebPageAbtract(_webPage.testDriver);
            wp.ClickThisElement(ModalOkButton);
        }


        public void ClickNationalDexLink()
        {
            WebPageAbtract wp = new WebPageAbtract(_webPage.testDriver);
            wp.ClickThisElement(NationalDexQuickLink);
        }



    }
}
