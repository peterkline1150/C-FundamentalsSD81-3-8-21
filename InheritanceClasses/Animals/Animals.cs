using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InheritanceClasses
{
    public enum DietType { Herbivore = 1, Omnivore, Carnivore}
    public class Animals
    {
        public Animals()
        {
            Console.WriteLine("This is an Animal Constructor");
        }
        public string AnimalName { get; set; }
        public int NumberOfLegs { get; set; }
        public bool IsMammal { get; set; }
        public bool HasFur { get; set; }
        public DietType DietType { get; set; }
        
        public virtual void Move()
        {
            Console.WriteLine($"This {GetType().Name} moves.");
        }
    }
}
