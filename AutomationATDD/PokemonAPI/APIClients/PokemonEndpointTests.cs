using AutomationClasses;
using NUnit.Framework;
using PokemonAPI;
using PokemonAPIFeature;
using RestSharp;

namespace AutomationATDD
{
    public class PokemonEndpointTests
    {
        [Test]
        [TestCase("Pikachu", 200)]
        [TestCase("PIKACHU", 200)]
        [TestCase("DoesntExist", 404)]
        public void GetPokemonDataByName(string name, int expectedCode)
        {
            PokemonEndpoint pe = new PokemonEndpoint(EnvironmentData.pokemonAPIURL);
            IRestResponse response = pe.RetrievePokemonInformation(name);
            int code = (int)response.StatusCode;
            Assert.AreEqual(expectedCode, code);
        }

        [Test]
        [TestCase(-1, 404)]
        [TestCase(0, 404)]
        [TestCase(25, 200)]
        [TestCase(1400, 404)]
        public void GetPokemonDataByNumber(int number, int expectedCode)
        {
            PokemonEndpoint pe = new PokemonEndpoint(EnvironmentData.pokemonAPIURL);
            IRestResponse response = pe.RetrievePokemonInformation(number);
            int code = (int)response.StatusCode;
            Assert.AreEqual(expectedCode, code);
        }
    }
}
