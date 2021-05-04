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
        /// Cleans the screen
        /// </summary>
        public static void Clean() {
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
        /// Shows Main Menu for a player with actions that player can do
        /// </summary>
        /// <param name="currentPlayer"> Takes <see cref="Player"/> as param for current player info </param>
        /// <returns> ConsoleKeyInfo for Game to work on what player choose</returns>
        public static ConsoleKeyInfo MainMenu(Player currentPlayer) {
            Console.WriteLine($"Player: {currentPlayer.name}, Moves: {currentPlayer.amountOfMoves}, Account: {currentPlayer.account} \n");
            Console.WriteLine("[B]uy a car                                      [V]iew Owned cars");
            Console.WriteLine("[R]epair a car                                   Buy an [A]d");
            Console.WriteLine("[S]ell a car                                     Check [H]istory of actions ");
            Console.WriteLine("Check sum of all [P]ayments for owned cars       [Q]uit");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo BuyCarMenu(){
            Console.WriteLine("Buy Car Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo ViewOwnedCarsMenu(){
            Console.WriteLine("Owned Cars Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo RepairCarMenu(){
            Console.WriteLine("Repair Car Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo BuyAdMenu(){
            Console.WriteLine("Buy Ad Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo SellCarMenu(){
            Console.WriteLine("Sell Car Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo CheckHistoryMenu(){
            Console.WriteLine("Check History Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo CheckPaymentsMenu(){
            Console.WriteLine("Check Payments Menu");
            return Console.ReadKey();
        }
    }
}
