﻿using System;
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
        // compatability value range -21 - 6
        public int CalculateCompatibility(PetModel pet)
        {
            var compatibility = 0;

            // Preferences
            if (PreferredWeightClass == pet.WeightClass)
                compatibility += 1;
            if (PreferredClassification == pet.Classification)
                compatibility += 2;
            if (PreferredType == pet.Type)
                compatibility += 3;

            // Overrides
            if (WeightClassOverrides != null && Array.Exists(WeightClassOverrides, element => element == pet.WeightClass))
                compatibility -= 6;
            if (ClassificationOverrides != null && Array.Exists(ClassificationOverrides, element => element == pet.Classification))
                compatibility -= 7;
            if (TypeOverrides != null && Array.Exists(TypeOverrides, element => element == pet.Type))
                compatibility -= 8;

            return compatibility;
        }

        // Method to get a sorted List of (Pet, compatibility Value) Key-Value Pairs
        public List<KeyValuePair<PetModel,int>> GetPetsCompatibility(PetModel[] pets)
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