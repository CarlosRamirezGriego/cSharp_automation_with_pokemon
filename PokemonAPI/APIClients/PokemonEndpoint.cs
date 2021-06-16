using APIClients;
using RestSharp;

namespace PokemonAPI
{
    public class PokemonEndpoint
    {
        public string URL;

        public PokemonEndpoint(string APIURL)
        {
            URL = APIURL;
        }

        public IRestResponse RetrievePokemonInformation(string pokemonName)
        {
            string URI = "api/v2/pokemon/"+ pokemonName.ToLower();
            APIEncapsulator _api = new APIEncapsulator(URL, URI, "get");
            _api.AddHeaderToRequest("Accept", "application/json, text/plain, */*");
            IRestResponse ResponseObject = _api.ExecuteAPICall();
            return ResponseObject;
        }

        public IRestResponse RetrievePokemonInformation(int pokemonNumber)
        {
            string URI = "api/v2/pokemon/" + pokemonNumber.ToString();
            APIEncapsulator _api = new APIEncapsulator(URL, URI, "get");
            _api.AddHeaderToRequest("Accept", "application/json, text/plain, */*");
            IRestResponse ResponseObject = _api.ExecuteAPICall();
            return ResponseObject;
        }

    }
}
