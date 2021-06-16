using AutomationClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPageStats
    {
        public ElementInterface TabBasicContainer = new ElementInterface("div[class='tabs-panel active'][id^='tab-basic-']", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer = new ElementInterface("div:nth-child(2)>div:nth-child(1)", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer_BaseStatHP = new ElementInterface("table.vitals-table tbody>tr:nth-child(1) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer_BaseStatAttack = new ElementInterface("table.vitals-table tbody>tr:nth-child(2) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer_BaseStatDefense = new ElementInterface("table.vitals-table tbody>tr:nth-child(3) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer_BaseStatSpAttack = new ElementInterface("table.vitals-table tbody>tr:nth-child(4) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer_BaseStatSpDefense = new ElementInterface("table.vitals-table tbody>tr:nth-child(5) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementInterface TabBasicContainer_StatsContainer_BaseStatSpeed = new ElementInterface("table.vitals-table tbody>tr:nth-child(6) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public WebPageInterface _webPage;

        public PokemonDetailPageStats(WebPageInterface webPage)
        {
                _webPage = webPage;
        }

        public ElementInterface FindHPBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatHP = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatHP);
            return TabBasicContainer_StatsContainer_BaseStatHP;
        }

        public ElementInterface FindAttackBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatAttack = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatAttack);
            return TabBasicContainer_StatsContainer_BaseStatAttack;
        }

        public ElementInterface FindDefenseBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatDefense = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatDefense);
            return TabBasicContainer_StatsContainer_BaseStatDefense;
        }

        public ElementInterface FindSpAttackBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpAttack = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatSpAttack);
            return TabBasicContainer_StatsContainer_BaseStatSpAttack;
        }

        public ElementInterface FindSpDefenseBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpDefense = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatSpDefense);
            return TabBasicContainer_StatsContainer_BaseStatSpDefense;
        }

        public ElementInterface FindSpeedBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpeed = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatSpeed);
            return TabBasicContainer_StatsContainer_BaseStatSpeed;
        }



    }
}
