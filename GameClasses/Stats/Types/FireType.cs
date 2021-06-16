using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class FireType : IPokemonType
    {
        private string typeName = "Fire";
        private int typeSlot = 0;

        public FireType()
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
            List<string> types = new List<string> { "Bug", "Grass", "Ice", "Steel" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Dragon", "Fire", "Rock", "Water" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Bug", "Fairy", "Fire", "Grass", "Ice", "Steel" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Ground", "Rock", "Water"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}