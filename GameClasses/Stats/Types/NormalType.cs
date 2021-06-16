﻿using GameInterfaces;
using System;
using System.Collections.Generic;

namespace StatsManagement
{
    public class NormalType : IPokemonType
    {
        private string typeName = "Normal";
        private int typeSlot = 0;

        public NormalType()
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
            List<string> types = new List<string>();
            return types;
        }

        public List<string> OffensiveWeakTo()
        {
            List<string> types = new List<string> { "Rock", "Steel"};
            return types;
        }

        public List<string> OffensiveNoDamageTo()
        {
            List<string> types = new List<string> { "Ghost" };
            return types;
        }


        public List<string> DefenseStrongAgainst()
        {
            List<string> types = new List<string> ();
            return types;
        }

        public List<string> DefenseWeakTo()
        {
            List<string> types = new List<string> { "Fighting" };
            return types;
        }

        public List<string> DefenseImmuneTo()
        {
            List<string> types = new List<string> { "Ghost" };
            return types;
        }
    }
}