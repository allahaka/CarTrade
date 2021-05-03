using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Menus
    {
        public List<Player> players;

        public void AddPlayers(List<Player> players){
            this.players = players;
        }

        public void Clean() {
            Console.Clear();
        }

        public List<string> StartGame(){
            List<string> result = new List<string>();
            int players;

            Console.WriteLine("How many players: ");
            
            while (!int.TryParse(Console.ReadLine(), out players)) {
                Console.WriteLine("Please Enter a valid numerical value:");
            }

            result.Add(players.ToString());

            Clean();

            for(int i=0; i<players; i++){
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

        public void MainMenu() {
            Console.WriteLine("1. [B]uy a car                           2. [V]iew Owned cars");
            Console.WriteLine("3. [R]epair a car                        4. Buy an [A]d");
            Console.WriteLine("5. [S]ell a car                          6. [C]heck account");
            Console.WriteLine("7. Check [H]istory of actions            8. Check sum of all [P]ayments for owned cars");
            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key) {
                case ConsoleKey.B:
                    Clean();
                    this.BuyCarMenu();
                    break;
                case ConsoleKey.V:
                    Clean();
                    this.ViewOwnedCarsMenu();
                    break;
                case ConsoleKey.R:
                    Clean();
                    this.RepairCarMenu();
                    break;
                case ConsoleKey.A:
                    Clean();
                    this.BuyAdMenu();
                    break;
                case ConsoleKey.S:
                    Clean();
                    this.SellCarMenu();
                    break;
                case ConsoleKey.C:
                    Clean();
                    this.CheckAccountMenu();
                    break;
                case ConsoleKey.H:
                    Clean();
                    this.CheckHistoryMenu();
                    break;
                case ConsoleKey.P:
                    Clean();
                    this.CheckPaymentsMenu();
                    break;
            } 
        }

        public void BuyCarMenu() { 
        
        }

        public void ViewOwnedCarsMenu()
        {

        }

        public void RepairCarMenu()
        {

        }

        public void BuyAdMenu()
        {

        }

        public void SellCarMenu()
        {

        }

        public void CheckAccountMenu()
        {

        }
        public void CheckHistoryMenu()
        {

        }
        public void CheckPaymentsMenu()
        {

        }
    }
}
