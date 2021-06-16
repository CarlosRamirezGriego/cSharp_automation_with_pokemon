using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class FightingType : IPokemonType
    {
        private string typeName = "Fighting";
        private int typeSlot = 0;

        public FightingType()
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
            List<string> types = new List<string> { "Normal", "Rock", "Steel", "Ice", "Dark" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Poison", "Flying", "Bug", "Psychic", "Fairy" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> { "Ghost" };
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Bug", "Dark", "Rock" };
            return types;
        }


        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Psychic", "Flying", "Fairy" };
            return types;
        }

        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}