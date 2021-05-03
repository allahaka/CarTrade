using System;
using System.Collections.Generic;

namespace CarTrade
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus menu = new Menus();
            ClientGenerator cg = new ClientGenerator();
            CarGenerator carG = new CarGenerator();

            List<string> startingInfo = menu.StartGame();

            string difficulty = Game.GetDifficulty(startingInfo);
            List<Player> players = Game.CreatePlayers(startingInfo, difficulty);
            List<Client> clients = cg.GenerateClient(25);
            List<Car> carShop = carG.GenerateCar(30);

            menu.AddPlayers(players);
            Game game = new Game(players, difficulty, clients, carShop);
            game.Start();
        }
    }
}
