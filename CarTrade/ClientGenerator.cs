using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CarTrade {
    class ClientGenerator {

        readonly Helpers help = new Helpers(); 

        public List<Client> GenerateClient(int amount){
            List<Client> clients = new List<Client>();
            for (int i = 0; i < amount; i++) {
                string name = GenerateName();
                decimal cash = GenerateCash();
                string interestedInType = GenerateInterestedType();
                string[] interestedIn = GenerateInterestedInBrands();
                bool acceptedDamagedParts = true;
                clients.Add(new Client(name, cash, interestedInType, interestedIn, acceptedDamagedParts));
            }
            return clients; 
        }

        public string GenerateName(){
            JObject o1 = JObject.Parse(File.ReadAllText("first-names.json"));
            string a = o1.ToString();
            List<string> name = a.Split(',').ToList();
            return name[help.RandomNumber(name.Count())];
        }

        public decimal GenerateCash(){
            return Convert.ToDecimal(help.RandomNumber(1000000, 25000));
        }

        public string GenerateInterestedType(){
            string[] types = new string[3] {"cargo", "normal", "motorcycle"};
            return types[help.RandomNumber(types.Length)];
        }

        public string[] GenerateInterestedInBrands(){
            string[] brands = new string[25] { "Fiat", "Honda", "Hyundai", "Kia", "Opel", "Peugeot", "Renault", "Toyota", "Audi", 
                                                "BMW", "Jeep", "Land Rover", "Lexus", "Mercedes-Benz", "Volkswagen", "Volvo", "Alfa Romeo", 
                                                "Aston Martin", "Bugatti", "Dodge", "Ferrari", "Lamborghini", "McLaren", "Rolls-Royce", "Tesla" };

            int firstBrand = help.RandomNumber(brands.Length);
            var list = new List<string>(brands);
            list.Remove(brands[firstBrand]);
            string[] brands2 = list.ToArray();

            string[] interestedIn = new string[2] { brands[firstBrand] , brands2[help.RandomNumber(brands2.Length)] };
            return interestedIn;
        }

        public bool DoesAcceptDemagedParts(){
            return help.RandomNumber(100) > 80;
        }

    }
}
