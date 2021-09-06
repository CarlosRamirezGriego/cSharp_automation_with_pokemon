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
        public WebPageAbstract _webPage;

        public PokemonDBHome(WebPageAbstract webPage)
        {
                _webPage = webPage;
        }


        public void ThePrivacyModalIsPresent()
        {
            WebPageAbstract wp = new WebPageAbstract(_webPage.testDriver);
            wp.SearchForTheseSelectorsData(PrivacyModal);
        }

        public void WaitForTheModalToNotBeDisplayedAnymore()
        {
            WebPageAbstract wp = new WebPageAbstract(_webPage.testDriver);
            wp.ThisElementShouldNotBeVisible(PrivacyModal);
        }


        public void ClickOKModalButton()
        {
            WebPageAbstract wp = new WebPageAbstract(_webPage.testDriver);
            wp.ClickThisElement(ModalOkButton);
        }


        public void ClickNationalDexLink()
        {
            WebPageAbstract wp = new WebPageAbstract(_webPage.testDriver);
            wp.ClickThisElement(NationalDexQuickLink);
        }



    }
}
