using GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokeballs
{
    public class Pokeball : IPokeBall, IItem
    {
        public readonly string type = "Pokeball";

        public int CatchPokemonRate(IPokemon pokemon)
        {
            int baseRate = pokemon.GetCaptureRate();
            return baseRate * 1;
        }
    }
}
