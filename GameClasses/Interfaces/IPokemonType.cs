using StatsManagement;
using System.Collections.Generic;

namespace GameInterfaces
{
    public interface IPokemonType
    {
        public string GetTypeName();
        public int GetTypeSlot();
        public void SetTypeSlot(int num);
        public List<string> OffensiveWeakTo();
        public List<string> OffensiveStrongAgainst();
        public List<string> OffensiveNoDamageTo();

        public List<string> DefenseWeakTo();
        public List<string> DefenseStrongAgainst();
        public List<string> DefenseImmuneTo();

    }
}
