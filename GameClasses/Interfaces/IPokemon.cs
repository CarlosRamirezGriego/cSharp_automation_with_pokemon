using StatsManagement;

namespace GameInterfaces
{
    public interface IPokemon
    {
        void GiveRareCandy();
        bool IsEvolveCriteriaMet();
        string GetSpecies();
        IPokemon Evolve();
        IPokemon SpeciesItBreeds();
        int GetCaptureRate();
        IPokeBall FindPokeball();
        IItem RemoveItem();
        bool SetItem(IItem holdThis);
        int StepsToHatch();
        IVManagement GetThisPokemonIVs();
    }
}
