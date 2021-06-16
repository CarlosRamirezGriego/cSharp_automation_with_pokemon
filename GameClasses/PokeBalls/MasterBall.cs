using GameInterfaces;

namespace Pokeballs
{
    public class MasterBall : IPokeBall, IItem
    {
        public readonly string type = "MasterBall";

        public int CatchPokemonRate(IPokemon pokemon)
        {
            return 100;
        }
    }
}
