using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class FairyType : IPokemonType
    {
        private string typeName = "Fairy";
        private int typeSlot = 0;

        public FairyType()
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
            List<string> types = new List<string> { "Dark", "Dragon", "Fight" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Fire", "Poison", "Steel" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Bug", "Dark", "Fight" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Poison", "Steel"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Dragon" };
            return types;
        }

    }
}