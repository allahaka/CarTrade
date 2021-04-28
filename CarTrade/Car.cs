using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Car
    {

        // base values for car
        public readonly decimal value;
        public readonly string brand;
        public readonly decimal mileage;
        public readonly string colour;
        public readonly string segment;
        public readonly string type;
        public string owner;

        //parts for car
        public Part[] parts;

        //helper method
        private bool needRepairing()
        {
            Random rng = new Random();
            return rng.Next(100) <= 50 ? true : false;
        }

        private void createParts() {
            this.parts[0] = new Part("Break", needRepairing(), 10);
            this.parts[1] = new Part("Suspension", needRepairing(), 20);
            this.parts[2] = new Part("Engine", needRepairing(), 100);
            this.parts[3] = new Part("Body", needRepairing(), 50);
            this.parts[4] = new Part("Gearbox", needRepairing(), 50);
        }

        private decimal finalPrice() {
            decimal final = this.value;
            for (int i = 0; i < 5; i++) {
                final = this.parts[i].needRepairing ? final + this.value * this.parts[i].valueIncrease : final;
            }
            return final;
        }

        private string[] displayCar() {
            string firstLine = $"The {this.colour} {this.brand} \n {this.type} car out of {this.segment} segment.";
            string secondLine = $"Price: {this.finalPrice()}";
            string parts = "";
            for (int i = 0; i < 5; i++) {
                parts += $"{this.parts[i]}: {(this.parts[i].needRepairing ? "Repair is needed" : "Perfect")} \n";
            }
            return new String[3] {firstLine, secondLine, parts};
        }

    }
}
