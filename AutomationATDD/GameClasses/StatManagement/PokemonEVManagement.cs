using NUnit.Framework;
using StatsManagement;

namespace AutomationATDD
{
    public class PokemonEVManagement
    {

        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(254, 0, 0)]
        [TestCase(254, 1, 1)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonHPStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToHP(initialEV);
            evObject.AddEVPointsToHP(addedEV);
            int actualEV = evObject.hp;
            Assert.AreEqual(expectedEV, actualEV);
        }

        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(254, 0, 0)]
        [TestCase(254, 1, 1)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonAttackStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToAttack(initialEV);
            evObject.AddEVPointsToAttack(addedEV);
            int actualEV = evObject.attack;
            Assert.AreEqual(expectedEV, actualEV);
        }


        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(254, 0, 0)]
        [TestCase(254, 1, 1)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonDefenseStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToDefense(initialEV);
            evObject.AddEVPointsToDefense(addedEV);
            int actualEV = evObject.defense;
            Assert.AreEqual(expectedEV, actualEV);
        }


        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(254, 0, 0)]
        [TestCase(254, 1, 1)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonSpecialAttackStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToSpecialAttack(initialEV);
            evObject.AddEVPointsToSpecialAttack(addedEV);
            int actualEV = evObject.specialAttack;
            Assert.AreEqual(expectedEV, actualEV);
        }

        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(254, 0, 0)]
        [TestCase(254, 1, 1)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonSpecialDefenseStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToSpecialDefense(initialEV);
            evObject.AddEVPointsToSpecialDefense(addedEV);
            int actualEV = evObject.specialDefense;
            Assert.AreEqual(expectedEV, actualEV);
        }


        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(254, 0, 0)]
        [TestCase(254, 1, 1)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonSpeedStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToSpeed(initialEV);
            evObject.AddEVPointsToSpeed(addedEV);
            int actualEV = evObject.speed;
            Assert.AreEqual(expectedEV, actualEV);
        }

        [Test]
        [TestCase(5, 509)]
        [TestCase(6, 510)]
        [TestCase(7, 504)]
        public void ValidationForTotalEVPointsAllowed(int amount, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToSpeed(252); //We allocate Maximum in Status 1
            evObject.AddEVPointsToDefense(252); //We allocate Maximum in Status 2
            evObject.AddEVPointsToAttack(amount); 
            int actualEV = evObject.GetTotalEVPoints();
            Assert.AreEqual(expectedEV, actualEV);
        }


        [Test]
        public void ValidateEVResetWorks()
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToSpeed(252); //We allocate Maximum in Status 1
            evObject.AddEVPointsToDefense(252); //We allocate Maximum in Status 2
            evObject.AddEVPointsToAttack(6); //We allocate Maximum in Status 3
            evObject.ResetEVPoints();
            int actualEV = evObject.GetTotalEVPoints();
            Assert.AreEqual(0, actualEV);
        }
    }
}