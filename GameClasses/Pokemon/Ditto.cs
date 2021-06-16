using GameInterfaces;
using StatsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Ditto : IPokemon
    {
        public string nickname;
        public IVManagement IVs { get; private set; }
        public string species
        {
            get { return "Ditto"; }
        }
        public int level = 1;
        public bool hatched = false;
        public bool captured = true;
        public IPokeBall pokeball
        {
            get; private set;
        }
        public bool isEgg
        {
            get; private set;
        }
        public IItem heldItem;

        public Ditto()
        {
        }

        public int StepsToHatch()
        {
            return 0;
        }


        public Ditto(int lvl, IPokeBall catchingWith)
        {
            hatched = false;
            captured = true;
            level = lvl;
            pokeball = catchingWith;
            IVManagement ivs = new IVManagement();
            IVs = ivs;
        }
        public IVManagement GetThisPokemonIVs()
        {
            return IVs;
        }
        public string GetSpecies()
        {
            return species;
        }


        public IPokemon SpeciesItBreeds()
        {
            return null;
        }

        public int GetCaptureRate()
        {
            return 15;
        }


        public IPokeBall FindPokeball()
        {
            return this.pokeball;
        }


        public bool IsEvolveCriteriaMet()
        {
            return false;
        }

        public void GiveRareCandy()
        {
            level = level + 1;
        }

        public IPokemon Evolve()
        {
            return null;
        }


        public IItem RemoveItem()
        {
            if (heldItem == null)
            {
                return null;
            }
            else
            {
                return heldItem;
            }
        }

        public bool SetItem(IItem holdThis)
        {
            if (heldItem != null)
            {
                heldItem = holdThis;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
