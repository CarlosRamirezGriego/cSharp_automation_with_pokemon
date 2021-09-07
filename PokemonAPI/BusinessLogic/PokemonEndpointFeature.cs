using AutomationClasses;
using GameInterfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public string APIURL { get; private set; } = EnvironmentData.pokemonAPIURL;

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
            JObject statsData = JObject.Parse(response.Content);
            JArray statsArray = statsData.GetValue("stats").Value<JArray>();
            JObject baseStatData = JObject.Parse((string)statsArray[0]);
            int stat = baseStatData.GetValue("base_stat").Value<int>();
            return stat;
        }


        public int GetAttackFromData(IRestResponse response)
        {
            JObject statsData = JObject.Parse(response.Content);
            JArray statsArray = statsData.GetValue("stats").Value<JArray>();
            JObject baseStatData = JObject.Parse((string)statsArray[1]);
            int stat = baseStatData.GetValue("base_stat").Value<int>();
            return stat;
        }

        public int GetDefenseFromData(IRestResponse response)
        {
            JObject statsData = JObject.Parse(response.Content);
            JArray statsArray = statsData.GetValue("stats").Value<JArray>();
            JObject baseStatData = JObject.Parse((string)statsArray[2]);
            int stat = baseStatData.GetValue("base_stat").Value<int>();
            return stat;
        }

        public int GetSpecialAttackFromData(IRestResponse response)
        {
            JObject statsData = JObject.Parse(response.Content);
            JArray statsArray = statsData.GetValue("stats").Value<JArray>();
            JObject baseStatData = JObject.Parse((string)statsArray[3]);
            int stat = baseStatData.GetValue("base_stat").Value<int>();
            return stat;
        }

        public int GetSpecialDefenseFromData(IRestResponse response)
        {
            JObject statsData = JObject.Parse(response.Content);
            JArray statsArray = statsData.GetValue("stats").Value<JArray>();
            JObject baseStatData = JObject.Parse((string)statsArray[4]);
            int stat = baseStatData.GetValue("base_stat").Value<int>();
            return stat;
        }

        public int GetSpeedFromData(IRestResponse response)
        {
            JObject statsData = JObject.Parse(response.Content);
            JArray statsArray = statsData.GetValue("stats").Value<JArray>();
            JObject baseStatData = JObject.Parse((string)statsArray[5]);
            int stat = baseStatData.GetValue("base_stat").Value<int>();
            return stat;
        }

        public bool ThisPokemonHasMultipleTypes(IRestResponse response)
        {
            bool hasTwo = false;
            JObject data = JObject.Parse(response.Content);
            JArray types = data.GetValue("types").Value<JArray>();
            int count = types.Count;
            if (count == 2)
            {
                hasTwo = true;
            }
            return hasTwo;
        }

        public List<IPokemonType> GetAllPokemonTypeData(IRestResponse response)
        {
            List<IPokemonType> listTypes = new List<IPokemonType>();
            JObject data = JObject.Parse(response.Content);
            JArray typesArray = data.GetValue("types").Value<JArray>();
            JObject firstType = JObject.Parse((string)typesArray[0]);
            JObject typeData = firstType.GetValue("type").Value<JObject>();
            string type1Name = typeData.GetValue("name").Value<string>();
            IPokemonType type1 = PokemonTypeManagement.RetrieveType(type1Name);
            listTypes.Add(type1);
            bool hasTwoTypes = ThisPokemonHasMultipleTypes(response);
            if (hasTwoTypes)
            {
                JObject secondType = JObject.Parse((string)typesArray[1]);
                JObject typeData2 = secondType.GetValue("type").Value<JObject>();
                string type2Name = typeData2.GetValue("name").Value<string>();
                IPokemonType type2 = PokemonTypeManagement.RetrieveType(type2Name);
                listTypes.Add(type2);
            }
            return listTypes;
        }

    }
}
