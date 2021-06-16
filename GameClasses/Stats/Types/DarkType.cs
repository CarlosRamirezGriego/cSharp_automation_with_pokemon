using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class DarkType : IPokemonType
    {
        private string typeName = "Dark";
        private int typeSlot = 0;

        public DarkType()
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
            List<string> types = new List<string> { "Ghost", "Psychic" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Dark", "Fairy", "Fighting" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> ();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Dark", "Ghost" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Bug", "Fairy", "Fighting" };
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Psychic" };
            return types;
        }

    }
}