﻿namespace CarTrade
{
    class Part
    {
        public readonly string name;
        public bool needRepairing;
        public readonly int valueIncrease;

        public Part(string name, bool needRepairing, int valueIncrease) {
            this.name = name;
            this.needRepairing = needRepairing;
            this.valueIncrease = valueIncrease;
        }

        public void Repair() {
            this.needRepairing = false;
        }
    }
}
