using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class WaterType : IPokemonType
    {
        private string typeName = "Water";
        private int typeSlot = 0;

        public WaterType()
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
            List<string> types = new List<string> { "Fire", "Ground", "Rock" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Dragon", "Grass", "Water" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Fire", "Water", "Ice", "Steel" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Electric", "Grass"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}