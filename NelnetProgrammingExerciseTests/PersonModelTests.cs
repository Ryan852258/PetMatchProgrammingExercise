using NelnetProgrammingExercise.Models;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;


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

            Assert.Equal(4, person.CalculateCompatibility(pet));
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
        [InlineData(new PetType[] { PetType.Cat }, PetType.Cat)]
        [InlineData(new PetType[] { PetType.Rat, PetType.Goldfish }, PetType.Rat)]
        [InlineData(new PetType[] { PetType.Dog, PetType.Rat, PetType.Cat, PetType.Dog }, PetType.Dog)]
        public void TypeOverrideMatchTest(PetType[] TypeOverrides, PetType petType)
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

            Assert.Equal(-32, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(new PetType[] { PetType.Cat }, PetType.Dog)]
        [InlineData(new PetType[] { PetType.Rat, PetType.Goldfish }, PetType.Dog)]
        [InlineData(new PetType[] { PetType.Dog, PetType.Rat, PetType.Cat, PetType.Dog }, PetType.Goldfish)]
        public void TypeOverrideNoMatchTest(PetType[] TypeOverrides, PetType petType)
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
        [InlineData(new PetClassification[] { PetClassification.Arachnid, PetClassification.Fish, PetClassification.Bird, PetClassification.Fish }, PetClassification.Bird)]
        public void ClassificationOverrideMatchTest(PetClassification[] classificationOverrides, PetClassification petClassification)
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

            Assert.Equal(-16, person.CalculateCompatibility(pet));
        }


        [Theory]
        [InlineData(new PetClassification[] { PetClassification.Arachnid }, PetClassification.Bird)]
        [InlineData(new PetClassification[] { PetClassification.Mammal, PetClassification.Arachnid }, PetClassification.Fish)]
        [InlineData(new PetClassification[] { PetClassification.Fish, PetClassification.Bird, PetClassification.Fish }, PetClassification.Arachnid)]
        public void ClassificationOverrideNoMatchTest(PetClassification[] classificationOverrides, PetClassification petClassification)
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
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraLarge }, 32f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.ExtraLarge }, .5f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.Large, PetWeightClass.ExtraLarge, PetWeightClass.Small }, 2.2f)]
        public void WeightClassOverrideMatchTest(PetWeightClass[] WeightOverrides, float petWeight)
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

            Assert.Equal(-8, person.CalculateCompatibility(pet));
        }

        [Theory]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraLarge }, 29f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.ExtraLarge }, 14f)]
        [InlineData(new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.Large, PetWeightClass.ExtraLarge, PetWeightClass.Medium }, 2.2f)]
        public void WeightClassOverrideNoMatchTest(PetWeightClass[] WeightOverrides, float petWeight)
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

        public static IEnumerable<object[]> GetCalculateCompatabilityTestData()
        {
            var constantPerson = new PersonModel()
            {
                Name = "Test Dandly",
                PreferredType = PetType.Cat,
                PreferredClassification = PetClassification.Bird,
                PreferredWeightClass = PetWeightClass.Medium,
                TypeOverrides = new PetType[] { PetType.Dog, PetType.Goldfish, PetType.Parrot },
                ClassificationOverrides = new PetClassification[] { PetClassification.Arachnid },
                WeightClassOverrides = new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.Small }
            };

            var constantPet = new PetModel()
            {
                Name = "Daddy Test",
                Type = PetType.Cat,
                Classification = PetClassification.Mammal,
                Weight = 15f
            };

            yield return new object[]
            {
               constantPerson,
               constantPet,
               5
            };

            yield return new object[]
            {
                constantPerson,
                new PetModel()
                {
                    Name = "Tessa",
                    Type = PetType.Parrot,
                    Classification = PetClassification.Bird,
                    Weight = 4.23f
                },
                -38
            };
            yield return new object[]
            {
                constantPerson,
                new PetModel()
                {
                    Name = "Bird Kitty",
                    Type = PetType.Cat,
                    Classification = PetClassification.Bird,
                    Weight = 12.12f
                },
                7
            };
            yield return new object[]
            {
                constantPerson,
                new PetModel()
                {
                    Name = "Parrot Spider",
                    Type = PetType.Parrot,
                    Classification = PetClassification.Arachnid,
                    Weight = .4f
                },
                -56
            };
            yield return new object[]
            {
                new PersonModel()
                {
                    Name = "Test Man",
                    PreferredType = PetType.Cat,
                    PreferredClassification = PetClassification.Mammal,
                    PreferredWeightClass = PetWeightClass.Medium,
                    TypeOverrides = new PetType[] { PetType.Dog, PetType.Goldfish, PetType.Parrot },
                    ClassificationOverrides = new PetClassification[] { PetClassification.Arachnid },
                    WeightClassOverrides = new PetWeightClass[] { PetWeightClass.Large, PetWeightClass.ExtraLarge}
                },
                constantPet,
                7
            };

            yield return new object[]
            {
                new PersonModel()
                {
                    Name = "Test Woman",
                    PreferredType = PetType.Dog,
                    PreferredClassification = PetClassification.Mammal,
                    PreferredWeightClass = PetWeightClass.Large,
                    TypeOverrides = new PetType[] { PetType.Cat, PetType.Snake, PetType.Spider },
                    ClassificationOverrides = new PetClassification[] { PetClassification.Arachnid, PetClassification.Reptile },
                    WeightClassOverrides = new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.ExtraLarge, PetWeightClass.Large, PetWeightClass.Small}
                },
                constantPet,
                -30
            };

            yield return new object[]
            {
                new PersonModel()
                {
                    Name = "Test NB",
                    PreferredType = PetType.Betta,
                    PreferredClassification = PetClassification.Fish,
                    PreferredWeightClass = PetWeightClass.Small,
                    TypeOverrides = new PetType[] { PetType.Snake, PetType.Spider },
                    ClassificationOverrides = new PetClassification[] { PetClassification.Arachnid, PetClassification.Reptile },
                    WeightClassOverrides = new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.ExtraLarge, PetWeightClass.Large, PetWeightClass.Small}
                },
                constantPet,
                0
            };
            yield return new object[]
            {
                new PersonModel()
                {
                    Name = "Test Kid",
                    PreferredType = PetType.Cat,
                    PreferredClassification = PetClassification.Mammal,
                    PreferredWeightClass = PetWeightClass.Medium,
                    TypeOverrides = new PetType[] { PetType.Cat, PetType.Snake, PetType.Spider },
                    ClassificationOverrides = new PetClassification[] { PetClassification.Mammal },
                    WeightClassOverrides = new PetWeightClass[] { PetWeightClass.ExtraSmall, PetWeightClass.Medium }
                },
                constantPet,
                -49
            };
        }

        [Theory]
        [MemberData(nameof(GetCalculateCompatabilityTestData))]
        public void CalculateCompatibilityTest(PersonModel person, PetModel pet, int expectedCompatibility) => Assert.Equal(expectedCompatibility, person.CalculateCompatibility(pet));

        public static IEnumerable<object[]> GetCompatibilityForPetsTestData()
        {
            var testPerson1 = new PersonModel()
            {
                Name = "Nelman",
                PreferredType = PetType.Cat,
                PreferredClassification = PetClassification.Mammal,
                PreferredWeightClass = PetWeightClass.Large,
                TypeOverrides = new PetType[] {  PetType.Snake, PetType.Spider },
                ClassificationOverrides = new PetClassification[] { PetClassification.Arachnid },
                WeightClassOverrides = new PetWeightClass[] { PetWeightClass.ExtraSmall }
            };

            var testPerson2 = new PersonModel()
            {
                Name = "Mandy",
                PreferredType = PetType.Parrot,
                PreferredClassification = PetClassification.Bird,
                PreferredWeightClass = PetWeightClass.Small,
                TypeOverrides = new PetType[] { PetType.Snake, PetType.Goldfish, PetType.Canary },
                ClassificationOverrides = new PetClassification[] { PetClassification.Arachnid, PetClassification.Fish },
                WeightClassOverrides = new PetWeightClass[] {  PetWeightClass.Large, PetWeightClass.ExtraLarge }
            };
            
            var testPetSet1 = new PetModel[]
            {
                new PetModel()
                {
                    Name = "Garfield",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Cat,
                    Weight = 20F
                },
                new PetModel()
                {
                    Name = "Odie",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Dog,
                    Weight = 15F

                },
                new PetModel()
                {
                    Name = "Peter Parker",
                    Classification = PetClassification.Arachnid,
                    Type = PetType.Spider,
                    Weight = 0.5F
                },
                new PetModel()
                {
                    Name = "Kaa",
                    Classification = PetClassification.Reptile,
                    Type = PetType.Snake,
                    Weight = 25F
                },
                new PetModel()
                {
                    Name = "Nemo",
                    Classification = PetClassification.Fish,
                    Type = PetType.Goldfish,
                    Weight = 0.5F
                },
                new PetModel()
                {
                    Name = "Alpha",
                    Classification = PetClassification.Fish,
                    Type = PetType.Betta,
                    Weight = 0.1F
                },
                new PetModel()
                {
                    Name = "Splinter",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Rat,
                    Weight = 0.5F
                },
                new PetModel()
                {
                    Name = "Coco",
                    Classification = PetClassification.Bird,
                    Type = PetType.Parrot,
                    Weight = 6.0F
                },
                new PetModel()
                {
                    Name = "Tweety",
                    Classification = PetClassification.Bird,
                    Type = PetType.Canary,
                    Weight = .05F
                }
            };

            var testPetSet2 = new PetModel[]
            {
                new PetModel()
                {
                    Name = "Big Spider Cat",
                    Classification = PetClassification.Arachnid,
                    Type = PetType.Cat,
                    Weight = 500F
                },
                new PetModel()
                {
                    Name = "Small Reptile Dog",
                    Classification = PetClassification.Reptile,
                    Type = PetType.Dog,
                    Weight = 3.23F

                },
                new PetModel()
                {
                    Name = "Cat Fish",
                    Classification = PetClassification.Fish,
                    Type = PetType.Cat,
                    Weight = 20F
                },
                new PetModel()
                {
                    Name = "Good Boy",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Dog,
                    Weight = 12.2F
                },
                new PetModel()
                {
                    Name = "Flying Fish",
                    Classification = PetClassification.Bird,
                    Type = PetType.Goldfish,
                    Weight = 0.5F
                },
                new PetModel()
                {
                    Name = "Sigma",
                    Classification = PetClassification.Reptile,
                    Type = PetType.Betta,
                    Weight = 0.4F
                },
                new PetModel()
                {
                    Name = "Splinter",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Rat,
                    Weight = 0.5F
                },
                new PetModel()
                {
                    Name = "Human?",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Parrot,
                    Weight = 6.0F
                },
                new PetModel()
                {
                    Name = "Big Bird",
                    Classification = PetClassification.Bird,
                    Type = PetType.Canary,
                    Weight = 24F
                }

            };

            yield return new object[]
            { 
                testPerson1, 
                testPetSet1,
                new PetModel[]{
                    testPetSet1[0], 
                    testPetSet1[1], 
                    testPetSet1[7], 
                    testPetSet1[6], 
                    testPetSet1[4], 
                    testPetSet1[5], 
                    testPetSet1[8], 
                    testPetSet1[3], 
                    testPetSet1[2]
                }
            };

            yield return new object[]
            {
                testPerson2,
                testPetSet1,
                new PetModel[]
                { 
                    testPetSet1[7], 
                    testPetSet1[1], 
                    testPetSet1[6], 
                    testPetSet1[0], 
                    testPetSet1[2], 
                    testPetSet1[5], 
                    testPetSet1 [8], 
                    testPetSet1[3], 
                    testPetSet1[4] 
                }
            };

            yield return new object[]
            {
                testPerson2,
                testPetSet2,
                new PetModel[]
                { 
                    testPetSet2[7], 
                    testPetSet2[1], 
                    testPetSet2[3], 
                    testPetSet2[5], 
                    testPetSet2[6], 
                    testPetSet2[0], 
                    testPetSet2[2], 
                    testPetSet2[4], 
                    testPetSet2[8] 
                }
            };
            yield return new object[]
            {
                testPerson1,
                testPetSet2,
                new PetModel[]
                { 
                    testPetSet2[2], 
                    testPetSet2[3], 
                    testPetSet2[7], 
                    testPetSet2[8], 
                    testPetSet2[1],
                    testPetSet2[6],
                    testPetSet2[4],
                    testPetSet2[5],
                    testPetSet2[0]
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetCompatibilityForPetsTestData))]
        public void GetCompatibilityForPetsTest(PersonModel person, PetModel[] pets, PetModel[] expectedOrder)
        {
            List<KeyValuePair<PetModel, int>> petCompatabilityPairs = person.GetCompatibilityForPets(pets);
            var sortedPets = petCompatabilityPairs.Select(pair => pair.Key ).ToArray();
            Assert.Equal(expectedOrder, sortedPets);
        }


    }
}
