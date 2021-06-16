using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class SteelType : IPokemonType
    {
        private string typeName = "Steel";
        private int typeSlot = 0;

        public SteelType()
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
            List<string> types = new List<string> { "Fairy", "Ice", "Rock" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Electric", "Fire", "Steel", "Water" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Bug", "Dragon", "Fairy", "Flying", "Grass", "Ice", "Normal", "Psychic", "Rock", "Steel" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Fighting", "Fire", "Ground"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Poison" };
            return types;
        }

    }
}