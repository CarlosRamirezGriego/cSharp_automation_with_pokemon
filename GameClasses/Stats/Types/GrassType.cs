using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class GrassType : IPokemonType
    {
        private string typeName = "Grass";
        private int typeSlot = 0;

        public GrassType()
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
            List<string> types = new List<string> { "Water", "Ground", "Rock" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Dragon", "Bug", "Fire", "Flying", "Grass", "Poison", "Steel" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Electric", "Grass", "Ground", "Water" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Bug", "Fire", "Flying", "Ice", "Poison"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}