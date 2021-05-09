using System;
using System.Collections.Generic;

namespace CarTrade
{
    class CarGenerator{
        readonly Helpers help = new Helpers();

        public List<Car> GenerateCar(int amount){
            List<Car> cars = new List<Car>();

            for(int i = 0; i < amount; i++){
                string type = CarType();
                string segment = CarSegment();
                string brand = GenerateBrand(segment);
                decimal value = GenerateBasePrice(segment, type);
                decimal mileage = help.RandomDecimal(new Random(), 6, 2);
                string colour = help.GetRandomColorName();
                int cargoSpace = type == "cargo" ? help.RandomNumber(10000, 1000) : 0;
                Car car = new Car(value, brand, mileage, colour, segment, type, cargoSpace);
                car.CreateParts();
                cars.Add(car); 
            }
            return cars;
        }

        public string CarType(){
            int typeRand = help.RandomNumber(1000);

            if(typeRand <= 600){
                return "normal";
            }else if (typeRand > 600 && typeRand <= 900){
                return "cargo";
            }else{
                return "motorcycle";
            }
        }

        public string CarSegment(){
            int segRand = help.RandomNumber(1000);

            if(segRand <= 500){
                return "budget";
            }else if (segRand > 500 && segRand <= 950){
                return "standard";
            }else{
                return "premium";
            }
        }

        public string GenerateBrand(string segment){
            string[] budget = new string[8] { "Fiat", "Honda", "Hyundai", "Kia", "Opel", "Peugeot", "Renault", "Toyota" };
            string[] standard = new string[9] { "Audi", "BMW", "Jeep", "Land Rover", "Lexus", "Mercedes-Benz", "Volkswagen", "Volvo", "Alfa Romeo" };
            string[] premium = new string[8] { "Aston Martin", "Bugatti", "Dodge", "Ferrari", "Lamborghini", "McLaren", "Rolls-Royce", "Tesla" };

            return segment switch{
                "budget" => budget[help.RandomNumber(budget.Length)],
                "standard" => standard[help.RandomNumber(standard.Length)],
                "premium" => premium[help.RandomNumber(premium.Length)],
                _ => budget[help.RandomNumber(budget.Length)],
            };
        }

        public decimal GenerateBasePrice(string segment, string type){
            return segment switch{
                "budget" => GenerateBudgetPrice(type),
                "standard" => GenerateStandardPrice(type),
                "premium" => GeneratePremiumPrice(type),
                _ => GenerateBudgetPrice(type),
            };
        }

        private decimal GenerateBudgetPrice(string type){
            decimal value = Convert.ToDecimal(help.RandomNumber(1000, 500));
            return DiffPriceOnType(value, type);
        }

        private decimal GenerateStandardPrice(string type){
            decimal value = Convert.ToDecimal(help.RandomNumber(2000, 1000));
            return DiffPriceOnType(value, type);
        }

        private decimal GeneratePremiumPrice(string type){
            decimal value = Convert.ToDecimal(help.RandomNumber(10000, 2500));
            return DiffPriceOnType(value, type);
        }

        private decimal DiffPriceOnType(decimal value, string type){
            return type switch {
                "cargo" => Decimal.Multiply(value, 1.1m),
                "motorcycle" => Decimal.Multiply(value, 0.9m),
                _ => value,
            };
        }
    }
}
