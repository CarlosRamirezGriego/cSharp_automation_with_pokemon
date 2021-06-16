using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class GroundType : IPokemonType
    {
        private string typeName = "Ground";
        private int typeSlot = 0;

        public GroundType()
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
            List<string> types = new List<string> { "Electric", "Fire", "Poison", "Rock", "Steel" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Bug", "Grass" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> { "Flying" };
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Poison", "Rock"};
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Grass", "Ice", "Water"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Electric" };
            return types;
        }

    }
}