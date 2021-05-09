namespace CarTrade
{
    class Part{
        public readonly string name;
        public bool needRepairing;
        public readonly int valueIncrease;
        public decimal repairPrice;

        public Part(string name, bool needRepairing, int valueIncrease){
            this.name = name;
            this.needRepairing = needRepairing;
            this.valueIncrease = valueIncrease;
            RepairPrice();
        }

        public void Repair(){
            this.needRepairing = false;
        }

        public void Destroy(){
            this.needRepairing = true;
        }

        public void RepairPrice(){ 
            switch(name){
                case "Break":
                    repairPrice = 100.0m;
                    break;
                case "Suspension":
                    repairPrice = 1500.0m;
                    break;
                case "Engine":
                    repairPrice = 4000.0m;
                    break;
                case "Body":
                    repairPrice = 400.0m;
                    break;
                case "Gearbox":
                    repairPrice = 7000.0m;
                    break;
            }
        }
    }
}
