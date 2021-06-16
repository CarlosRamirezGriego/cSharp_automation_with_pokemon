using NUnit.Framework;
using StatsManagement;
using System.Collections.Generic;

namespace AutomationATDD
{
    public class PokemonIVManagement
    {
        [Test]
        public void GenerateRandomIVValues_HP()
        {
            IVManagement ivObject = new IVManagement();
            int hp = ivObject.hp;
            Assert.That(hp, Is.GreaterThanOrEqualTo(0));
            Assert.That(hp, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.hpRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_Attack()
        {
            IVManagement ivObject = new IVManagement();
            int attack = ivObject.attack;
            Assert.That(attack, Is.GreaterThanOrEqualTo(0));
            Assert.That(attack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.attackRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_Defense()
        {
            IVManagement ivObject = new IVManagement();
            int defense = ivObject.defense;
            Assert.That(defense, Is.GreaterThanOrEqualTo(0));
            Assert.That(defense, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.defenseRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_SpecialAttack()
        {
            IVManagement ivObject = new IVManagement();
            int specialAttack = ivObject.specialAttack;
            Assert.That(specialAttack, Is.GreaterThanOrEqualTo(0));
            Assert.That(specialAttack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.specialAttackRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_SpecialDefense()
        {
            IVManagement ivObject = new IVManagement();
            int specialDefense = ivObject.specialDefense;
            Assert.That(specialDefense, Is.GreaterThanOrEqualTo(0));
            Assert.That(specialDefense, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.specialDefenseRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_Speed()
        {
            IVManagement ivObject = new IVManagement();
            int speed = ivObject.speed;
            Assert.That(speed, Is.GreaterThanOrEqualTo(0));
            Assert.That(speed, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.speedRandom, true);
        }

        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_HP_Randomnization(int par, bool isRandom)
        {
            List<int> listIVs = new List<int> { par, 1, 1, 1, 1, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int hp = ivObject.hp;
            Assert.That(hp, Is.GreaterThanOrEqualTo(0));
            Assert.That(hp, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.speedRandom, isRandom);
        }

        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_Attack_Randomnization(int par, bool isRandom)
        {
            List<int> listIVs = new List<int> { 1, par, 1, 1, 1, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int attack = ivObject.attack;
            Assert.That(attack, Is.GreaterThanOrEqualTo(0));
            Assert.That(attack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.attackRandom, isRandom);
        }

        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_Defense_Randomnization(int par, bool isRandom)
        {
            List<int> listIVs = new List<int> { 1, 1, par, 1, 1, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int defense = ivObject.defense;
            Assert.That(defense, Is.GreaterThanOrEqualTo(0));
            Assert.That(defense, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.defenseRandom, isRandom);
        }


        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_SpecialAttack_Randomnization(int par, bool isRandom)
        {
            List<int> listIVs = new List<int> { 1, 1, 1, par, 1, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int specialAttack = ivObject.specialAttack;
            Assert.That(specialAttack, Is.GreaterThanOrEqualTo(0));
            Assert.That(specialAttack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.specialAttackRandom, isRandom);
        }


        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_SpecialDefense_Randomnization(int par, bool isRandom)
        {
            List<int> listIVs = new List<int> { 1, 1, 1, 1, par, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int specialDefense = ivObject.specialDefense;
            Assert.That(specialDefense, Is.GreaterThanOrEqualTo(0));
            Assert.That(specialDefense, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.specialDefenseRandom, isRandom);
        }



        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_Speed_Randomnization(int par, bool isRandom)
        {
            List<int> listIVs = new List<int> { 1, 1, 1, 1, 1, par };
            IVManagement ivObject = new IVManagement(listIVs);
            int speed = ivObject.speed;
            Assert.That(speed, Is.GreaterThanOrEqualTo(0));
            Assert.That(speed, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.speedRandom, isRandom);
        }

        [Test]
        [TestCase(7, true)]
        [TestCase(6, false)]
        [TestCase(5, true)]
        public void ValidateThatConstructorWithArrayAcceptsTheValidAmnountOfValues(int par, bool isRandom)
        {
            int cont = 1;
            List<int> listIVs = new List<int>();
            while (cont <= par)
            {
                listIVs.Add(31);
                cont = cont + 1;
            }
            IVManagement ivObject = new IVManagement(listIVs);
            Assert.AreEqual(ivObject.hpRandom, isRandom);
            Assert.AreEqual(ivObject.attackRandom, isRandom);
            Assert.AreEqual(ivObject.defenseRandom, isRandom);
            Assert.AreEqual(ivObject.specialAttackRandom, isRandom);
            Assert.AreEqual(ivObject.specialDefenseRandom, isRandom);
            Assert.AreEqual(ivObject.speedRandom, isRandom);
        }

    }
}
