using GameInterfaces;
using OpenQA.Selenium;
using PageObjects;
using StatsManagement;
using System.Collections.Generic;

namespace UIModules
{
    public class PokemonDetailPageModule
    {

        public WebPageAbtract _wp;

        public PokemonDetailPageModule(WebPageAbtract wp)
        {
            _wp = wp;
        }

        public string FindPokemonNameInPage()
        {
            PokemonDetailPagePokedex dexObject = new PokemonDetailPagePokedex(_wp);
            dexObject.FindPokemonNameHeaderLabel();
            string name = null;
            if (dexObject.PokemonNameHeader.amountElements == 1)
            {
                IWebElement nameElement = dexObject.PokemonNameHeader.ReturnTheIWebElementInPosition(1);
                name = nameElement.Text;
            }
            return name;
        }

        public string FindPokemonNationalNumber()
        {
            PokemonDetailPagePokedex dexObject = new PokemonDetailPagePokedex(_wp);
            dexObject.FindNationalDexNumberLabel();
            string number = null;
            if (dexObject.TabBasicContainer_DataContainer_NationalDexNumber.amountElements == 1)
            {
                IWebElement numberElement = dexObject.TabBasicContainer_DataContainer_NationalDexNumber.ReturnTheIWebElementInPosition(1);
                number = numberElement.Text;
            }
            return number;
        }

        public List<IPokemonType> FindPokemonTypes()
        {
            PokemonDetailPagePokedex dexObject = new PokemonDetailPagePokedex(_wp);
            dexObject.FindPokemonTypesLabels();
            List<IPokemonType> typesPage = new List<IPokemonType>();
            int amountTypes = dexObject.TabBasicContainer_DataContainer_PokemonTypes.amountElements;
            for (int i = 0; i <= amountTypes - 1; i++)
            {
                IWebElement typeElement = dexObject.TabBasicContainer_DataContainer_PokemonTypes.ReturnTheIWebElementInPosition(i + 1);
                string typeName = typeElement.Text;
                int slot = i + 1;
                bool isValid = PokemonTypeManagement.IsThisAValidType(typeName);
                if (isValid)
                {
                    IPokemonType type = PokemonTypeManagement.RetrieveType(typeName);
                    type.SetTypeSlot(slot);
                    typesPage.Add(type);
                }
            }
            return typesPage;
        }


        public string FindPokemonBaseHP()
        {
            PokemonDetailPageStats statsObject = new PokemonDetailPageStats(_wp);
            ElementAbstract hpElement = statsObject.FindHPBaseStatusData();
            string hp = null;
            if (hpElement.amountElements == 1)
            {
                IWebElement stat = hpElement.ReturnTheIWebElementInPosition(1);
                hp = stat.Text;
            }
            return hp;
        }

        public string FindPokemonBaseAttack()
        {
            PokemonDetailPageStats statsObject = new PokemonDetailPageStats(_wp);
            ElementAbstract attElement = statsObject.FindAttackBaseStatusData();
            string att = null;
            if (attElement.amountElements == 1)
            {
                IWebElement stat = attElement.ReturnTheIWebElementInPosition(1);
                att = stat.Text;
            }
            return att;
        }

        public string FindPokemonBaseDefense()
        {
            PokemonDetailPageStats statsObject = new PokemonDetailPageStats(_wp);
            ElementAbstract defElement = statsObject.FindDefenseBaseStatusData();
            string def = null;
            if (defElement.amountElements == 1)
            {
                IWebElement stat = defElement.ReturnTheIWebElementInPosition(1);
                def = stat.Text;
            }
            return def;
        }

        public string FindPokemonBaseSpAttack()
        {
            PokemonDetailPageStats statsObject = new PokemonDetailPageStats(_wp);
            ElementAbstract spaElement = statsObject.FindSpAttackBaseStatusData();
            string spa = null;
            if (spaElement.amountElements == 1)
            {
                IWebElement stat = spaElement.ReturnTheIWebElementInPosition(1);
                spa = stat.Text;
            }
            return spa;
        }

        public string FindPokemonBaseSpDefense()
        {
            PokemonDetailPageStats statsObject = new PokemonDetailPageStats(_wp);
            ElementAbstract spdElement = statsObject.FindSpDefenseBaseStatusData();
            string spd = null;
            if (spdElement.amountElements == 1)
            {
                IWebElement stat = spdElement.ReturnTheIWebElementInPosition(1);
                spd = stat.Text;
            }
            return spd;
        }

        public string FindPokemonBaseSpeed()
        {
            PokemonDetailPageStats statsObject = new PokemonDetailPageStats(_wp);
            ElementAbstract spedElement = statsObject.FindSpeedBaseStatusData();
            string spe = null;
            if (spedElement.amountElements == 1)
            {
                IWebElement stat = spedElement.ReturnTheIWebElementInPosition(1);
                spe = stat.Text;
            }
            return spe;
        }


        public IPokemonType GetPokemonPrimaryType(List<IPokemonType> types)
        {
            IPokemonType type = null;
            foreach (IPokemonType pkt in types)
            {
                if (pkt.GetTypeSlot() == 1)
                {
                    type = pkt;
                    break;
                }
            }
            return type;
        }


        public bool ThisPokemonHasASecondType(List<IPokemonType> types)
        {
            bool hasSecond = false;
            foreach (IPokemonType pkt in types)
            {
                if (pkt.GetTypeSlot() == 2)
                {
                    hasSecond = true;
                    break;
                }
            }
            return hasSecond;
        }


        public IPokemonType GetPokemonSecondaryType(List<IPokemonType> types)
        {
            IPokemonType type = null;
            foreach (IPokemonType pkt in types)
            {
                if (pkt.GetTypeSlot() == 2)
                {
                    type = pkt;
                    break;
                }
            }
            return type;
        }

    }
}
