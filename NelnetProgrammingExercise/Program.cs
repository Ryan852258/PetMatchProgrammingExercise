using NelnetProgrammingExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NelnetProgrammingExercise
{
    class Program
    {
        private static PersonModel[] People;
        private static PetModel[] Pets;

        #region Initialization

        private static void SetupObjects()
        {
            People = new PersonModel[]
            {
                new PersonModel()
                {
                    Name = "Dalinar",
                    PreferredClassification = PetClassification.Mammal,
                    PreferredType = PetType.Snake,
                    PreferredWeightClass = PetWeightClass.Medium,
                    ClassificationOverrides = new PetClassification[]{ PetClassification.Bird }

                },
                new PersonModel()
                {
                    Name = "Kaladin",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Goldfish,
                    PreferredWeightClass = PetWeightClass.ExtraSmall,
                    ClassificationOverrides = new PetClassification[]{PetClassification.Fish, PetClassification.Bird},
                    TypeOverrides = new PetType[]{PetType.Cat, PetType.Spider},
                    WeightClassOverrides = new PetWeightClass[]{PetWeightClass.Medium}
                }
            };

            Pets = new PetModel[]
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
        }

        #endregion

        private static string IsGood(int fitness)
        {
            return fitness > 0
                ? "good"
                : "bad";
        }

        static void Main(string[] args)
        {
            SetupObjects();

            foreach(PersonModel person in People) {
                Console.WriteLine(string.Format("Pets for {0}:", person.Name));

                var PetsCompatability = person.GetPetsCompatibility(Pets);
                foreach(KeyValuePair<PetModel,int> petCompatibilityPair in PetsCompatability)
                {
                    var pet = petCompatibilityPair.Key;
                    var petCompatibility = petCompatibilityPair.Value;

                    Console.WriteLine(string.Format("{0} would be a {1} pet.", pet.Name, IsGood(petCompatibility)));
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
