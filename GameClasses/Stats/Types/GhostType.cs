using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class GhostType : IPokemonType
    {
        private string typeName = "Ghost";
        private int typeSlot = 0;

        public GhostType()
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
            List<string> types = new List<string> { "Dark" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> { "Normal" };
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Bug", "Poison" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Dark", "Ghost" };
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Normal", "Fighting" };
            return types;
        }

    }
}