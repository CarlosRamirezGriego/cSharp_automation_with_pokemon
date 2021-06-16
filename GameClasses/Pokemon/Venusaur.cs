using GameInterfaces;
using StatsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Venusaur: IPokemon
    {
        public string nickname;
        public IVManagement IVs { get; private set; }
        public string species
        {
            get { return "Venusaur"; }
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




        public Venusaur(int lvl, IPokeBall catchingWith)
        {
            hatched = false;
            captured = true;
            level = lvl;
            pokeball = catchingWith;
        }

        public Venusaur(Ivysaur ivy)
        {
            hatched = ivy.hatched;
            captured = ivy.captured;
            level = ivy.level;
            pokeball = ivy.pokeball;
            IVManagement ivs = new IVManagement();
            IVs = ivs;
        }
        public IVManagement GetThisPokemonIVs()
        {
            return IVs;
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

        public int GetCaptureRate()
        {
            return 25;
        }


        public string GetSpecies()
        {
            return species;
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
            if (heldItem == null) {
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
