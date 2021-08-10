using NelnetProgrammingExercise.Models;
using System;
using Xunit;

namespace NelnetProgrammingExerciseTests
{
    public class PersonModelTests
    {
 
        [Theory]
        [InlineData(PetType.Betta, PetType.Betta)]
        [InlineData(PetType.Canary, PetType.Canary)]
        [InlineData(PetType.Cat, PetType.Cat)]
        public void PreferenceTypeEqualTest(PetType preferredType, PetType petType)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = preferredType,
                PreferredClassification = PetClassification.Fish,
                PreferredWeightClass = PetWeightClass.ExtraLarge
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = petType,
                Classification = PetClassification.Mammal,
                Weight = .1F
            };

            Assert.Equal(3, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(PetType.Betta, PetType.Dog)]
        [InlineData(PetType.Canary, PetType.Betta)]
        [InlineData(PetType.Cat, PetType.Canary)]
        public void PreferenceTypeDiffrentTest(PetType preferredType, PetType petType)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = preferredType,
                PreferredClassification = PetClassification.Fish,
                PreferredWeightClass = PetWeightClass.ExtraLarge
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = petType,
                Classification = PetClassification.Mammal,
                Weight = .1F
            };

            Assert.Equal(0, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(PetClassification.Mammal, PetClassification.Mammal)]
        [InlineData(PetClassification.Fish, PetClassification.Fish)]
        [InlineData(PetClassification.Bird, PetClassification.Bird)]
        public void PreferenceClassificationEqualTest(PetClassification preferredClassification, PetClassification petClassification)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Cat,
                PreferredClassification = preferredClassification,
                PreferredWeightClass = PetWeightClass.ExtraLarge
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Dog,
                Classification = petClassification,
                Weight = .1F
            };
            Assert.Equal(2, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(PetClassification.Arachnid, PetClassification.Bird)]
        [InlineData(PetClassification.Bird, PetClassification.Arachnid)]
        [InlineData(PetClassification.Reptile, PetClassification.Fish)]
        public void PreferenceClassificationDiffrentTest(PetClassification preferredClassification, PetClassification petClassification)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Cat,
                PreferredClassification = preferredClassification,
                PreferredWeightClass = PetWeightClass.ExtraLarge
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Dog,
                Classification = petClassification,
                Weight = .1F
            };
            Assert.Equal(0, person.CalculateCompatibility(pet));
        }


        [Theory]
        [InlineData(PetWeightClass.ExtraLarge, 32f)]
        [InlineData(PetWeightClass.Large, 29.9f)]
        [InlineData(PetWeightClass.Medium, 13.02f)]
        public void PreferenceWeightEqualTest(PetWeightClass preferredWeightClass, float petWeight)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Cat,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = preferredWeightClass
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Dog,
                Classification = PetClassification.Bird,
                Weight = petWeight
            };

            Assert.Equal(1, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(PetWeightClass.ExtraLarge, 3f)]
        [InlineData(PetWeightClass.ExtraSmall, 29.9f)]
        [InlineData(PetWeightClass.Small, 13.02f)]
        public void PreferenceWeightDiffrentTest(PetWeightClass preferredWeightClass, float petWeight)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Cat,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = preferredWeightClass
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Dog,
                Classification = PetClassification.Bird,
                Weight = petWeight
            };

            Assert.Equal(0, person.CalculateCompatibility(pet));
        }


        [Theory]
        [InlineData(new PetType[]{PetType.Cat } , PetType.Cat)]
        [InlineData(new PetType[]{ PetType.Rat, PetType.Goldfish }, PetType.Rat)]
        [InlineData(new PetType[]{ PetType.Dog, PetType.Rat, PetType.Cat, PetType.Dog}, PetType.Dog)]
        public void TypeOverrideEqualTest(PetType[] TypeOverrides, PetType petType)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Spider,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = PetWeightClass.ExtraLarge,
                TypeOverrides = TypeOverrides
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = petType,
                Classification = PetClassification.Bird,
                Weight = 0.1f
            };

            Assert.Equal(-8, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(new PetType[] { PetType.Cat }, PetType.Dog)]
        [InlineData(new PetType[] { PetType.Rat, PetType.Goldfish }, PetType.Dog)]
        [InlineData(new PetType[] { PetType.Dog, PetType.Rat, PetType.Cat, PetType.Dog }, PetType.Goldfish)]
        public void TypeOverrideDiffrentTest(PetType[] TypeOverrides, PetType petType)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Spider,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = PetWeightClass.ExtraLarge,
                TypeOverrides = TypeOverrides
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = petType,
                Classification = PetClassification.Bird,
                Weight = 0.1f
            };

            Assert.Equal(0, person.CalculateCompatibility(pet));
        }


        [Theory]
        [InlineData(new PetClassification[] { PetClassification.Arachnid }, PetClassification.Arachnid)]
        [InlineData(new PetClassification[] { PetClassification.Mammal, PetClassification.Arachnid }, PetClassification.Mammal)]
        [InlineData(new PetClassification[] { PetClassification.Arachnid, PetClassification.Fish, PetClassification.Bird, PetClassification.Fish}, PetClassification.Bird)]
        public void ClassificationOverrideEqualTest(PetClassification[] classificationOverrides, PetClassification petClassification)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Spider,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = PetWeightClass.ExtraLarge,
                ClassificationOverrides = classificationOverrides
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Betta,
                Classification = petClassification,
                Weight = 0.1f
            };

            Assert.Equal(-7, person.CalculateCompatibility(pet));
        }


        [Theory]
        [InlineData(new PetClassification[] { PetClassification.Arachnid }, PetClassification.Bird)]
        [InlineData(new PetClassification[] { PetClassification.Mammal, PetClassification.Arachnid }, PetClassification.Fish)]
        [InlineData(new PetClassification[] { PetClassification.Fish, PetClassification.Bird, PetClassification.Fish }, PetClassification.Arachnid)]
        public void ClassificationOverrideDiffrentTest(PetClassification[] classificationOverrides, PetClassification petClassification)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Spider,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = PetWeightClass.ExtraLarge,
                ClassificationOverrides = classificationOverrides
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Betta,
                Classification = petClassification,
                Weight = 0.1f
            };

            Assert.Equal(0, person.CalculateCompatibility(pet));
        }


        [Theory]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraLarge },32f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.ExtraLarge }, .5f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.Large, PetWeightClass.ExtraLarge, PetWeightClass.Small }, 2.2f)]
        public void WeightClassOverrideEqualTest(PetWeightClass[] WeightOverrides, float petWeight)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Spider,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = PetWeightClass.Medium,
                WeightClassOverrides = WeightOverrides
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Betta,
                Classification = PetClassification.Bird,
                Weight = petWeight
            };

            Assert.Equal(-6, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraLarge }, 29f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.ExtraLarge }, 14f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.Large, PetWeightClass.ExtraLarge, PetWeightClass.Medium }, 2.2f)]
        public void WeightClassOverrideDiffrentTest(PetWeightClass[] WeightOverrides, float petWeight)
        {
            var person = new PersonModel()
            {
                Name = "Uni Test",
                PreferredType = PetType.Spider,
                PreferredClassification = PetClassification.Reptile,
                PreferredWeightClass = PetWeightClass.ExtraSmall,
                WeightClassOverrides = WeightOverrides
            };
            var pet = new PetModel()
            {
                Name = "Tes nit",
                Type = PetType.Betta,
                Classification = PetClassification.Bird,
                Weight = petWeight
            };

            Assert.Equal(0, person.CalculateCompatibility(pet));
        }

    }
}
