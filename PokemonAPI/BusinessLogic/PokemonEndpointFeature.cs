using GameInterfaces;
using Newtonsoft.Json;
using PokemonAPI;
using RestSharp;
using StatsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPIFeature
{
    public class PokemonEndpointFeature
    {

        public string APIURL { get; private set; } = "https://pokeapi.co/";

        public IRestResponse GetDataFromPokemonNumber(int pokemonNumber)
        {
            PokemonEndpoint PokEndObj = new PokemonEndpoint(this.APIURL);
            IRestResponse response = PokEndObj.RetrievePokemonInformation(pokemonNumber);
            return response;
        }

        public IRestResponse GetDataFromPokemonNamed(string pokemonName)
        {
            PokemonEndpoint PokEndObj = new PokemonEndpoint(this.APIURL);
            IRestResponse response = PokEndObj.RetrievePokemonInformation(pokemonName);
            return response;
        }

        public int GetHPFromData(IRestResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int hp = data["stats"][0]["base_stat"];
            return hp;
        }


        public int GetAttackFromData(IRestResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int att = data["stats"][1]["base_stat"];
            return att;
        }

        public int GetDefenseFromData(IRestResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int def = data["stats"][2]["base_stat"];
            return def;
        }

        public int GetSpecialAttackFromData(IRestResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int spAtt = data["stats"][3]["base_stat"];
            return spAtt;
        }

        public int GetSpecialDefenseFromData(IRestResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int spDef = data["stats"][4]["base_stat"];
            return spDef;
        }

        public int GetSpeedFromData(IRestResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int speed = data["stats"][5]["base_stat"];
            return speed;
        }

        public bool ThisPokemonHasMultipleTypes(IRestResponse response)
        {
            bool hasTwo = false;
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            int count = data["types"].Count;
            if (count == 2)
            {
                hasTwo = true;
            }
            return hasTwo;
        }

        public List<IPokemonType> GetAllPokemonTypeData(IRestResponse response)
        {
            List<IPokemonType> listTypes = new List<IPokemonType>();
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            string type1Name = data["types"][0]["type"]["name"];
            IPokemonType type1 = PokemonTypeManagement.RetrieveType(type1Name);
            listTypes.Add(type1);
            bool hasTwoTypes = ThisPokemonHasMultipleTypes(response);
            if (hasTwoTypes)
            {
                string type2Name = data["types"][1]["type"]["name"];
                IPokemonType type2 = PokemonTypeManagement.RetrieveType(type2Name);
                listTypes.Add(type2);
            }
            return listTypes;
        }

    }
}
