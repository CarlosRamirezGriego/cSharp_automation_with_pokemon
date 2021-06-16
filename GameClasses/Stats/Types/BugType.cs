using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class BugType : IPokemonType
    {
        private string typeName = "Bug";
        private int typeSlot = 0;

        public BugType()
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
            List<string> types = new List<string> { "Dark", "Grass","Psychic" };
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Fighting","Fairy" ,"Fire","Flying","Ghost","Poison","Steel" };
            return types;
        }


        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> ();
            return types;
        }

        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> { "Fighting", "Grass", "Ground" };
            return types;
        }


        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Fighting", "Fire", "Rock" };
            return types;
        }

        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string>();
            return types;
        }

    }
}