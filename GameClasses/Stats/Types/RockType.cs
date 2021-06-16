using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class RockType : IPokemonType
    {
        private string typeName = "Rock";
        private int typeSlot = 0;

        public RockType()
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
            List<string> types = new List<string> { "Bug", "Fire", "Flying", "Ice" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Fight", "Ground", "Steel" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Fire", "Flying", "Normal", "Poison" };
            return types;
        }


        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Fighting", "Grass", "Ground", "Steel", "Water" };
            return types;
        }

        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}