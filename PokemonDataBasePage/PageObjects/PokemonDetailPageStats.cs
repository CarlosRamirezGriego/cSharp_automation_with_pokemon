using AutomationClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPageStats
    {
        public ElementAbstract TabBasicContainer = new ElementAbstract("div[class='tabs-panel active'][id^='tab-basic-']", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer = new ElementAbstract("div:nth-child(2)>div:nth-child(1)", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer_BaseStatHP = new ElementAbstract("table.vitals-table tbody>tr:nth-child(1) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer_BaseStatAttack = new ElementAbstract("table.vitals-table tbody>tr:nth-child(2) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer_BaseStatDefense = new ElementAbstract("table.vitals-table tbody>tr:nth-child(3) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer_BaseStatSpAttack = new ElementAbstract("table.vitals-table tbody>tr:nth-child(4) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer_BaseStatSpDefense = new ElementAbstract("table.vitals-table tbody>tr:nth-child(5) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public ElementAbstract TabBasicContainer_StatsContainer_BaseStatSpeed = new ElementAbstract("table.vitals-table tbody>tr:nth-child(6) td:nth-of-type(1)", AutomationOptions.SearchMethod.CSS);
        public WebPageAbtract _webPage;

        public PokemonDetailPageStats(WebPageAbtract webPage)
        {
                _webPage = webPage;
        }

        public ElementAbstract FindHPBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatHP = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatHP);
            return TabBasicContainer_StatsContainer_BaseStatHP;
        }

        public ElementAbstract FindAttackBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatAttack = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatAttack);
            return TabBasicContainer_StatsContainer_BaseStatAttack;
        }

        public ElementAbstract FindDefenseBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatDefense = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatDefense);
            return TabBasicContainer_StatsContainer_BaseStatDefense;
        }

        public ElementAbstract FindSpAttackBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpAttack = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatSpAttack);
            return TabBasicContainer_StatsContainer_BaseStatSpAttack;
        }

        public ElementAbstract FindSpDefenseBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpDefense = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatSpDefense);
            return TabBasicContainer_StatsContainer_BaseStatSpDefense;
        }

        public ElementAbstract FindSpeedBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer);
            TabBasicContainer_StatsContainer = _webPage.SearchForTheseSelectorsData(TabBasicContainer, TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpeed = _webPage.SearchForTheseSelectorsData(TabBasicContainer_StatsContainer, TabBasicContainer_StatsContainer_BaseStatSpeed);
            return TabBasicContainer_StatsContainer_BaseStatSpeed;
        }



    }
}
