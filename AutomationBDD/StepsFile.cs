using NUnit.Framework;
using StatsManagement;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AutomationBDD
{
    [Binding]
    public sealed class StepsFile
    {

        public Dictionary<string, EVManagement> evObjects = new Dictionary<string, EVManagement>();

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

    }
}
