using System;

namespace CarTrade
{
    class Car{

        // base values for car
        public readonly decimal value;
        public readonly string brand;
        public readonly decimal mileage;
        public readonly string colour;
        public readonly string segment; //premium, standard, budget
        public readonly string type; //cargo, normal, motorcycle
        public readonly int cargoSpace; //0-not important, other for cargo

        //parts for car
        public Part[] parts;

        readonly Helpers help = new Helpers();

        public Car(decimal value, string brand, decimal mileage, string colour, string segment, string type, int cargoSpace=0){
            this.value = value;
            this.brand = brand;
            this.mileage = mileage;
            this.colour = colour;
            this.segment = segment;
            this.type = type;
            this.cargoSpace = cargoSpace;
            CreateParts();
        }

        //helper method
        private bool NeedRepairing(){
            return help.RandomNumber(100) <= 40;
        }

        public void CreateParts(){
            parts = new Part[5];
            parts[0] = new Part("Break", NeedRepairing(), 10);
            parts[1] = new Part("Suspension", NeedRepairing(), 20);
            parts[2] = new Part("Engine", NeedRepairing(), 100);
            parts[3] = new Part("Body", NeedRepairing(), 50);
            parts[4] = new Part("Gearbox", NeedRepairing(), 50);
        }

        public decimal FinalPrice(){
            decimal final = value;
            for(int i = 0; i < parts.Length; i++){
                final = parts[i].needRepairing ? final: final + value * parts[i].valueIncrease;
            }
            return final;
        }

        public string[] DisplayCar(){
            string firstLine = $"The {colour} {brand} {type} type out of {segment} segment with mileage {mileage}";
            string secondLine = $"Price: {FinalPrice()}";
            string parts = "Status of parts: \n";
            for(int i = 0; i < parts.Length; i++){
                parts += $"\t{this.parts[i].name}: {(this.parts[i].needRepairing ? "Repair is needed" : "Perfect")} \n";
            }
            return new String[3] {firstLine, secondLine, parts};
        }

        public decimal RepairPrice(){
            decimal repairPrice = 0.0m;
            for(int i = 0; i < parts.Length; i++){
                repairPrice += parts[i].needRepairing ? 0.0m : parts[i].repairPrice;
            }
            return segment switch{
                "budget" => Decimal.Multiply(repairPrice, 0.95m),
                "standard" => repairPrice,
                "premium" => Decimal.Multiply(repairPrice, 1.2m),
                _ => repairPrice,
            };
        }

        public void RepairCar(int chance){
            if(help.RandomNumber(100) <= chance){
                for (int i = 0; i < parts.Length; i++){
                    if(chance == 80) {
                        if(help.RandomNumber(100) <= 2){
                            parts[i].Destroy();
                        }else{
                            parts[i].Repair();
                        }
                    } else {
                        parts[i].Repair();
                    }
                }
            }
        }
    }
}
