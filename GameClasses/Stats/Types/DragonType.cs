using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class DragonType : IPokemonType
    {
        private string typeName = "Dragon";
        private int typeSlot = 0;

        public DragonType()
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
            List<string> types = new List<string> { "Dragon" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Steel" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> { "Fairy" };
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Electric", "Fire", "Grass", "Water" };
            return types;
        }


        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Dragon", "Fairy", "Ice" };
            return types;
        }

        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}