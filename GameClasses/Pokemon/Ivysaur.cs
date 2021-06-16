using GameInterfaces;
using StatsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Ivysaur : IPokemon
    {
        public string nickname;
        public IVManagement IVs { get; private set; }
        public string species
        {
            get { return "Ivysaur"; }
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


        public Ivysaur(Bulbasaur bulb)
        {
            hatched = bulb.hatched;
            captured = bulb.captured;
            level = bulb.level;
            pokeball = bulb.pokeball;
        }


        public Ivysaur(int lvl, IPokeBall catchingWith)
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
        public int GetCaptureRate()
        {
            return 45;
        }

        public IPokeBall FindPokeball()
        {
            return this.pokeball;
        }

        public string GetSpecies()
        {
            return species;
        }

        public int StepsToHatch()
        {
            return 1500;
        }

        public IPokemon SpeciesItBreeds()
        {
            Bulbasaur bulbasaur = new Bulbasaur();
            return bulbasaur;
        }

        public bool IsEvolveCriteriaMet()
        {
            if (level >= 36)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void GiveRareCandy()
        {
            if (level < 100)
            {
                level = level + 1;
            }
            
        }


        public IPokemon Evolve()
        {
            bool evolve = IsEvolveCriteriaMet();
            if (evolve)
            {
                IPokemon venusaur = (IPokemon)new Venusaur(this);
                return venusaur;
            }
            else {
                return null;
            }
        }


        public IItem RemoveItem()
        {
            if (heldItem == null)
            {
                return null;
            }
            else
            {
                IItem takenItem = heldItem;
                heldItem = null;
                return takenItem;
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
