namespace CarTrade
{
    class Player
    {
        public string name;
        public decimal account;
        public Car[] ownedCars;
        public int amountOfMoves;

        public Player(string name, decimal account){
            this.name = name;
            this.account = account;
            this.amountOfMoves = 0;
        }

        public void MadeMove(){
            this.amountOfMoves += 1;
        }
    }
}
