using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class PoisonType : IPokemonType
    {
        private string typeName = "Poison";
        private int typeSlot = 0;

        public PoisonType()
        { }

        public string GetTypeName()
        {
            return typeName;
        }

        public int GetTypeSlot()
        {
            return typeSlot;
        }

        public void SetTypeSlot(int num)
        {
            typeSlot = num;
        }

        public List<string> OffensiveStrongAgainst()
        {
            List<string> types = new List<string> { "Fairy", "Grass" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Poison", "Ground", "Rock", "Ghost" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> { "Steel" };
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Fighting", "Poison", "Bug", "Grass", "Fairy" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Ground", "Psychic"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}