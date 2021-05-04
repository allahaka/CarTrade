using System;
using System.Collections.Generic;

namespace CarTrade
{
    /// <summary>
    /// 
    /// </summary>
    class Menus
    {
        /// <summary>
        /// Holds all players in the game as list of class player
        /// </summary>
        public List<Player> players;

        /// <summary>
        /// Hold player object for current move switches between players available in <c>players</c>
        /// </summary>
        public Player currentPlayer;

        /// <summary>
        /// Adds List of players to Menus class as availability to work on this data during game itself
        /// </summary>
        /// <param name="players"> The <see cref="Player"/> list is provided to add possibility for game to go through players </param>
        public void AddPlayers(List<Player> players){
            this.players = players;
        }

        /// <summary>
        /// Cleans the screen
        /// </summary>
        public void Clean() {
            Console.Clear();
        }

        /// <summary>
        /// Collects all needed information about the game, as difficulty, amount of players and nicks of players
        /// </summary>
        /// <returns>List of <see cref="String"/> with all player names difficulty and amount of players in it</returns>
        public List<string> StartGame(){
            List<string> result = new List<string>();
            int numberPlayers;

            Console.WriteLine("How many players: ");
            
            while (!int.TryParse(Console.ReadLine(), out numberPlayers)) {
                Console.WriteLine("Please Enter a valid numerical value:");
            }

            result.Add(numberPlayers.ToString());

            Clean();

            for(int i=0; i<numberPlayers; i++){
                Console.WriteLine($"Enter the names of player{i}: ");
                string name = Console.ReadLine();
                result.Add(name);
                Clean();
            }

            Console.WriteLine("On what difficulty you want to play? ([E]asy, [M]edium, [H]ard)");

            while(true){
                string a = Console.ReadLine().ToLower();
                if( a == "e" || a == "easy"){
                    result.Add("easy");
                    break;
                }else if(a == "m" || a == "medium") {
                    result.Add("medium");
                    break;
                }else if(a == "h" || a == "hard"){
                    result.Add("hard");
                    break;
                }else{
                    Console.WriteLine("Wrong Input");
                }
            }

            Clean();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public void MainMenu() {
            Console.WriteLine($"Player: {currentPlayer.name}, Moves: {currentPlayer.amountOfMoves}, Account: {currentPlayer.account} \n");
            Console.WriteLine("[B]uy a car                                      [V]iew Owned cars");
            Console.WriteLine("[R]epair a car                                   Buy an [A]d");
            Console.WriteLine("[S]ell a car                                     Check [H]istory of actions ");
            Console.WriteLine("Check sum of all [P]ayments for owned cars       [Q]uit");
            MainMenuLogic();
        }

        public void BuyCarMenu(){
            Console.WriteLine("Buy Car Menu");
            BuyCarLogic();
        }

        public void ViewOwnedCarsMenu(){
            Console.WriteLine("Owned Cars Menu");
            ViewOwnedCarsLogic();
        }

        public void RepairCarMenu(){
            Console.WriteLine("Repair Car Menu");
            RepairCarLogic();
        }

        public void BuyAdMenu(){
            Console.WriteLine("Buy Ad Menu");
            BuyAdLogic();
        }

        public void SellCarMenu(){
            Console.WriteLine("Sell Car Menu");
            SellCarLogic();
        }

        public void CheckHistoryMenu(){
            Console.WriteLine("Check History Menu");
            CheckHistoryLogic();
        }

        public void CheckPaymentsMenu(){
            Console.WriteLine("Check Payments Menu");
            CheckPaymentsLogic();
        }

        //Logics
        public void MainMenuLogic() {
            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key) {
                case ConsoleKey.B:
                    Clean();
                    BuyCarMenu();
                    break;
                case ConsoleKey.V:
                    Clean();
                    ViewOwnedCarsMenu();
                    break;
                case ConsoleKey.R:
                    Clean();
                    RepairCarMenu();
                    break;
                case ConsoleKey.A:
                    Clean();
                    BuyAdMenu();
                    break;
                case ConsoleKey.S:
                    Clean();
                    SellCarMenu();
                    break;
                case ConsoleKey.H:
                    Clean();
                    CheckHistoryMenu();
                    break;
                case ConsoleKey.P:
                    Clean();
                    CheckPaymentsMenu();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
        public void BuyCarLogic(){
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void ViewOwnedCarsLogic() {
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void RepairCarLogic(){
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void BuyAdLogic(){
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void SellCarLogic(){
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void CheckAccountLogic() {
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void CheckHistoryLogic() {
            ConsoleKeyInfo ck = Console.ReadKey();
        }
        public void CheckPaymentsLogic() {
            ConsoleKeyInfo ck = Console.ReadKey();
        }
    }
}
