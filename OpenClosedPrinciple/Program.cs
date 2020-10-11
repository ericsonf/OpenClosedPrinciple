using System;
using System.Collections.Generic;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>
            {
                new Dog(new AnimalSummary { Name = "Akita"  }),
                new Bird(new AnimalSummary { Name = "Arara"  }),
                new Dog(new AnimalSummary { Name = "Doberman"  })
            };

            var animalSummarize = new AnimalSummarize(animals);
            Console.WriteLine($"Summarize animals:\n{ animalSummarize.Summarize() }");
        }
    }

    public class AnimalSummary
    {
        public string Name { get; set; }
    }

    public abstract class Animal
    {
        protected AnimalSummary AnimalSummary { get; }

        protected Animal(AnimalSummary animalSummary)
        {
            AnimalSummary = animalSummary;
        }
        public abstract string GetName();
    }

    public class Bird : Animal
    {
        public Bird(AnimalSummary animalSummary) : base(animalSummary)
        {
        }

        public override string GetName() => $"Bird's name: { AnimalSummary.Name }";
    }

    public class Dog : Animal
    {
        public Dog(AnimalSummary animalSummary) : base(animalSummary)
        {
        }

        public override string GetName() => $"Dog's name: { AnimalSummary.Name }";
    }

    public class AnimalSummarize
    {
        private readonly IEnumerable<Animal> _animals;
        public AnimalSummarize(IEnumerable<Animal> animals)
        {
            _animals = animals;
        }

        public string Summarize()
        {
            var content = string.Empty;
            foreach (var item in _animals)
            {
                content += $"Name: { item.GetName() } \n";
            }
            return content;
        }
    }
}
