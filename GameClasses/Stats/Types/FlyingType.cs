using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class FlyingType : IPokemonType
    {
        private string typeName = "Flying";
        private int typeSlot = 0;

        public FlyingType()
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
            List<string> types = new List<string> { "Bug", "Fighting", "Grass" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Electric", "Rock", "Steel" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string>();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Bug", "Grass", "Fighting" };
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Electric", "Rock", "Ice"};
            return types;
        }


        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Ground" };
            return types;
        }

    }
}