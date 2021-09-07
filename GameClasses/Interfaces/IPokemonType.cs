using StatsManagement;
using System.Collections.Generic;

namespace GameInterfaces
{
    public interface IPokemonType
    {
        string GetTypeName();
        int GetTypeSlot();
        void SetTypeSlot(int num);
        List<string> OffensiveWeakTo();
        List<string> OffensiveStrongAgainst();
        List<string> OffensiveNoDamageTo();
        List<string> DefenseWeakTo();
        List<string> DefenseStrongAgainst();
        List<string> DefenseImmuneTo();

    }
}
