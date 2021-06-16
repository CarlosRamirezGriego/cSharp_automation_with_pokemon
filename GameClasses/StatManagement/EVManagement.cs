using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsManagement
{
    public class EVManagement
    {
        public int hp { get; private set; }
        public int attack { get; private set; }
        public int defense { get; private set; }
        public int specialAttack { get; private set; }
        public int specialDefense { get; private set; }
        public int speed { get; private set; }

        public EVManagement()
        {
            hp = 0;
            attack = 0;
            defense = 0;
            specialAttack = 0;
            specialDefense = 0;
            speed = 0;
        }

        public void ResetEVPoints()
        {
            hp = 0;
            attack = 0;
            defense = 0;
            specialAttack = 0;
            specialDefense = 0;
            speed = 0;
        }

        public int GetTotalEVPoints()
        {
            int total = hp + attack + defense + specialAttack + specialDefense + speed;
            return total;
        }
        public void AddEVPointsToHP(int evs)
        {
            AllocateEVPoints(evs, "hp");
        }

        public void AddEVPointsToAttack(int evs)
        {
            AllocateEVPoints(evs, "attack");
        }

        public void AddEVPointsToDefense(int evs)
        {
            AllocateEVPoints(evs, "defense");
        }


        public void AddEVPointsToSpecialAttack(int evs)
        {
            AllocateEVPoints(evs, "specialAttack");
        }


        public void AddEVPointsToSpecialDefense(int evs)
        {
            AllocateEVPoints(evs, "specialDefense");
        }


        public void AddEVPointsToSpeed(int evs)
        {
            AllocateEVPoints(evs, "speed");
        }


        private void AllocateEVPoints(int evs, string stat)
        {
            int TotalStatus = 0;
            if (evs >= 0)
            {
                int Total = GetTotalEVPoints();
                if (Total <= 510)
                {
                    int TotalEVs = Total + evs;
                    if (TotalEVs <= 510)
                    {
                        switch (stat)
                        {
                            case "hp":
                                TotalStatus = hp + evs;
                                if (TotalStatus <= 252)
                                {
                                    hp = TotalStatus;
                                }
                                break;
                            case "attack":
                                TotalStatus = attack + evs;
                                if (TotalStatus <= 252)
                                {
                                    attack = TotalStatus;
                                }
                                break;
                            case "defense":
                                TotalStatus = defense + evs;
                                if (TotalStatus <= 252)
                                {
                                    defense = TotalStatus;
                                }
                                break;
                            case "specialAttack":
                                TotalStatus = specialAttack + evs;
                                if (TotalStatus <= 252)
                                {
                                    specialAttack = TotalStatus;
                                }
                                break;
                            case "specialDefense":
                                TotalStatus = specialDefense + evs;
                                if (TotalStatus <= 252)
                                {
                                    specialDefense = TotalStatus;
                                }
                                break;
                            case "speed":
                                TotalStatus = speed + evs;
                                if (TotalStatus <= 252)
                                {
                                    speed = TotalStatus;
                                }
                                break;
                        }
                    }
                }
            }
        }

    }
}
