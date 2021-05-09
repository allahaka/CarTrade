using System;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace CarTrade {
    class Helpers{

        //helper function
        public int RandomNumber(int max, int min = 0){
            Random rng = new Random();
            return rng.Next(min, max);
        }

        public decimal RandomDecimal(Random randomNumberGenerator, int precision, int scale){
            if (randomNumberGenerator == null)
                throw new ArgumentNullException("randomNumberGenerator");
            if (!(precision >= 1 && precision <= 28))
                throw new ArgumentOutOfRangeException("precision", precision, "Precision must be between 1 and 28.");
            if (!(scale >= 0 && scale <= precision))
                throw new ArgumentOutOfRangeException("scale", precision, "Scale must be between 0 and precision.");

            Decimal d = 0m;
            for(int i = 0; i < precision; i++){
                int r = randomNumberGenerator.Next(0, 10);
                d = d * 10m + r;
            }
            for(int s = 0; s < scale; s++){
                d /= 10m;
            }
            return d;
        }

        //Colour generation
        public readonly Color[] Colors =
            typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static)
           .Select(propInfo => propInfo.GetValue(null, null))
           .Cast<Color>()
           .ToArray();

        public readonly string[] ColorNames =
            typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(propInfo => propInfo.Name)
            .ToArray();

        private readonly Random rand = new Random();

        public string GetRandomColorName(){
            return ColorNames[rand.Next(0, Colors.Length)];
        }

    }
}
