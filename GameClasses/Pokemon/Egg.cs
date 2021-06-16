using GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Egg
    {
        public IPokemon pokemon {
            get; private set;
        }

        public Egg(IPokemon child)
        {
            pokemon = child;
        }
    }
}
