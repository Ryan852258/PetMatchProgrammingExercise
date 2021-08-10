using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PetModel
    {
        public string Name { get; set; }
        public PetClassification Classification { get; set; }
        public PetType Type { get; set; }

        public PetWeightClass WeightClass { get; private set; }

        private void CalculateWeightClass(float weight)
        {
            if ( weight <= 1.0)
                WeightClass = PetWeightClass.ExtraSmall;
            else if (weight <= 5.0)
                WeightClass = PetWeightClass.Small;
            else if (weight <= 15.0)
                WeightClass = PetWeightClass.Medium;
            else if (weight <= 30.0)
                WeightClass = PetWeightClass.Large;
            else if (weight > 30.0)
                WeightClass = PetWeightClass.ExtraLarge;
        }

        private float _Weight;

        public float Weight 
        { 
            get { return _Weight; }
            set
            {
                // throw Argument Exception if given negative weight
                if (value < 0)
                    throw new ArgumentException("Must be greater than 0");
                CalculateWeightClass(value);
                _Weight = value;
            }
        }
    }
}
