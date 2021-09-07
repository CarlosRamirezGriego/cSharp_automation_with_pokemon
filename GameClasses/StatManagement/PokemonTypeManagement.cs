using GameInterfaces;

namespace StatsManagement
{
    public static class PokemonTypeManagement
    {
        public static IPokemonType RetrieveType(string type)
        {
            IPokemonType typeVar = new NormalType();
            switch (type.ToLower())
            {
                case "bug":
                    typeVar = new BugType();
                    break;
                case "dark":
                    typeVar = new DarkType();
                    break;
                case "dragon":
                    typeVar = new DragonType();
                    break;
                case "fighting":
                    typeVar = new FightingType();
                    break;
                case "electric":
                    typeVar = new ElectricType();
                    break;
                case "fairy":
                    typeVar = new FairyType();
                    break;
                case "fire":
                    typeVar = new FireType();
                    break;
                case "flying":
                    typeVar = new FlyingType();
                    break;
                case "grass":
                    typeVar = new GrassType();
                    break;
                case "ghost":
                    typeVar = new GhostType();
                    break;
                case "ground":
                    typeVar = new GroundType();
                    break;
                case "ice":
                    typeVar = new IceType();
                    break;
                case "normal":
                    typeVar = new NormalType();
                    break;
                case "psychic":
                    typeVar = new PsychicType();
                    break;
                case "poison":
                    typeVar = new PoisonType();
                    break;
                case "rock":
                    typeVar = new RockType();
                    break;
                case "steel":
                    typeVar = new SteelType();
                    break;
                case "water":
                    typeVar = new WaterType();
                    break;
            }
            IPokemonType typeObj = typeVar;
            return typeObj;
        }

        public static bool IsThisAValidType(string type)
        {
            if (type.ToLower() == "fighting" || type.ToLower() == "electric" || type.ToLower() == "fire" || type.ToLower() == "flying" || type.ToLower() == "grass" || 
                type.ToLower() == "ground" || type.ToLower() == "normal" || type.ToLower() == "rock" || type.ToLower() == "steel" || type.ToLower() == "water" || type.ToLower() == "ghost" ||
                type.ToLower() == "dark" || type.ToLower() == "psychic" || type.ToLower() == "ice" || type.ToLower() == "bug" || type.ToLower() == "dragon" || type.ToLower() == "fairy" || 
                type.ToLower() == "poison")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
