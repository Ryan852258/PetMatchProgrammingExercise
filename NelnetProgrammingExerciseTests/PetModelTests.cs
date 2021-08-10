using NelnetProgrammingExercise.Models;
using System;
using Xunit;

namespace NelnetProgrammingExerciseTests
{
    public class PetModelTests
    { 
        [Theory]
        [InlineData(14.91f, PetWeightClass.Medium)]
        [InlineData(19.38f, PetWeightClass.Large)]
        [InlineData(32.49f, PetWeightClass.ExtraLarge)]
        [InlineData(.32f, PetWeightClass.ExtraSmall)]
        [InlineData(2f, PetWeightClass.Small)]
        public void CheckWeightClassCalculation(float weight, PetWeightClass expectedWeightClass)
        {
            var pet = new PetModel() { Weight = weight };
            Assert.Equal(expectedWeightClass, pet.WeightClass);
            Assert.Equal(weight, pet.Weight);
        }

        [Theory]
        [InlineData(-2.0f)]
        [InlineData(-1.0f)]
        [InlineData(-0.2f)]
        public void NegativeWeightTest(float weight)
        {
            Assert.Throws<ArgumentException>(() => new PetModel() { Weight = weight });     
        }
    }
}
