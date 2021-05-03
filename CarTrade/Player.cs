using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Player
    {
        public string name;
        public decimal account;
        public Car[] ownedCars;

        public Player(string name, decimal account){
            this.name = name;
            this.account = account;
        }
    }
}
