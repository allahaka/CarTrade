using System.Collections.Generic;

namespace CarTrade
{
    class Player
    {
        public string name;
        public decimal account;
        public List<Car> ownedCars;
        public int amountOfMoves;

        public Player(string name, decimal account){
            this.name = name;
            this.account = account;
            this.ownedCars = new List<Car>();
            this.amountOfMoves = 0;
        }

        public void MadeMove(){
            this.amountOfMoves += 1;
        }
    }
}
