using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public PetClassification PreferredClassification { get; set; }
        public PetType PreferredType { get; set; }
        public PetWeightClass PreferredWeightClass { get; set; }
        public PetClassification[] ClassificationOverrides { get; set; }
        public PetType[] TypeOverrides { get; set; }
        public PetWeightClass[] WeightClassOverrides { get; set; }

        // Method to calculate a compatability value between person and pet 
        // compatability above zero is a good pet and zero and below is a bad pet
        // compatability changes by 2^(m-n) where m is the number of propreties in the hierarchy and n is the position of the current property in the hierarchy
        public int CalculateCompatibility(PetModel pet)
        {
            var compatibility = 0;

            // Preferences (positives)
            if (PreferredWeightClass == pet.WeightClass)
                compatibility += 1;
            if (PreferredClassification == pet.Classification)
                compatibility += 2;
            if (PreferredType == pet.Type)
                compatibility += 4;

            // Overrides (negatives)
            if (WeightClassOverrides != null && Array.Exists(WeightClassOverrides, element => element == pet.WeightClass))
                compatibility -= 8;
            if (ClassificationOverrides != null && Array.Exists(ClassificationOverrides, element => element == pet.Classification))
                compatibility -= 16;
            if (TypeOverrides != null && Array.Exists(TypeOverrides, element => element == pet.Type))
                compatibility -= 32;

            return compatibility;
        }

        // Method to get a sorted List of (Pet, compatibility Value) Key-Value Pairs
        public List<KeyValuePair<PetModel,int>> GetCompatibilityForPets(PetModel[] pets)
        {
            List<KeyValuePair<PetModel, int>> PetsCompatibility = new List<KeyValuePair<PetModel, int>>();

            foreach (PetModel pet in pets)
            {
                PetsCompatibility.Add(new KeyValuePair<PetModel, int>(pet, CalculateCompatibility(pet)));
            }

            // Sort the list in decending order
            PetsCompatibility.Sort((x, y) => y.Value.CompareTo(x.Value));

            return PetsCompatibility;
        }


    }
}
