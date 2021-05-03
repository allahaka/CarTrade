using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade {
    class Game {

        public List<Player> players;
        public string gameDifficulty;
        public List<Client> clients;
        public List<Car> carShop;
        private decimal startingAmount;

        public Game(List<Player> players, string gameDifficulty, List<Client> clients, List<Car> carShop){
            this.players = players;
            this.gameDifficulty = gameDifficulty;
            this.clients = clients;
            this.carShop = carShop;
        }

        public static List<Player> CreatePlayers(List<string> list, string difficulty) {
            List<Player> players = new List<Player>();
            list.RemoveAt(list.Count - 1);
            int iteration = Convert.ToInt32(list[1]);
            list.RemoveAt(0);

            for (int i=0; i<iteration; i++){
                players.Add(new Player(list[i], Game.getAmountFromDifficulty(difficulty)));
            }

            return players;
        }

        public static string GetDifficulty(List<string> list){
            string difficulty = list[^1];
            return difficulty;
        }

        public static decimal getAmountFromDifficulty(string difficulty){
            var amount = difficulty switch {
                "easy" => 200000,
                "medium" => 100000,
                "hard" => 50000,
                _ => 200000,
            };
            return Convert.ToDecimal(amount);
        }

        //TODO
        public void Start(){
            this.startingAmount = getAmountFromDifficulty(this.gameDifficulty);
        }
    }
}
