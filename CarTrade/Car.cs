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
        public Part Break;
        public Part Suspension;
        public Part Engine;
        public Part Body;
        public Part Gearbox;

        //helper method
        private bool needRepairing()
        {
            Random rng = new Random();
            return rng.Next(100) <= 50 ? true : false;
        }

        private void createParts() {
            this.Break = new Part("Break", needRepairing(), 10);
            this.Suspension = new Part("Suspension", needRepairing(), 20);
            this.Engine = new Part("Engine", needRepairing(), 100);
            this.Body = new Part("Body", needRepairing(), 50);
            this.Gearbox = new Part("Gearbox", needRepairing(), 50);
        }

        private decimal finalPrice() {
            decimal final = this.value;
            final = this.Break.needRepairing ? final + this.value * this.Break.valueIncrease : final;
            final = this.Suspension.needRepairing ? final + this.value * this.Suspension.valueIncrease : final;
            final = this.Engine.needRepairing ? final + this.value * this.Engine.valueIncrease : final;
            final = this.Body.needRepairing ? final + this.value * this.Body.valueIncrease : final;
            final = this.Gearbox.needRepairing ? final + this.value * this.Gearbox.valueIncrease : final;
            return final;
        }

        private string[] displayCar() {
            string firstLine = $"The {this.colour} {this.brand} \n {this.type} car out of {this.segment} segment.";
            string secondLine = $"Price: {this.finalPrice()}";
            string parts = $"Breaks: {(this.Break.needRepairing ? "Repair is needed" : "Perfect")} " +
                $"\n Suspension: {(this.Suspension.needRepairing ? "Repair is needed" : "Perfect")} " +
                $"\n Engine: {(this.Engine.needRepairing ? "Repair is needed" : "Perfect")} " +
                $"\n Body: {(this.Body.needRepairing ? "Repair is needed" : "Perfect")} " +
                $"\n Gearbox: {(this.Gearbox.needRepairing ? "Repair is needed" : "Perfect")} ";
            return new String[3] {firstLine, secondLine, parts};
        }

    }
}
