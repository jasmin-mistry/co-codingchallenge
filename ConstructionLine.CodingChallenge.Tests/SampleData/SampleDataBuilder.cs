using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge.Tests.SampleData
{
    public class SampleDataBuilder
    {
        private readonly int numberOfShirts;

        private readonly Random random = new Random();

        public SampleDataBuilder(int numberOfShirts)
        {
            this.numberOfShirts = numberOfShirts;
        }

        public List<Shirt> CreateShirts()
        {
            return Enumerable.Range(0, numberOfShirts)
                .Select(i => new Shirt(Guid.NewGuid(), $"Shirt {i}", GetRandomSize(), GetRandomColor()))
                .ToList();
        }

        private Size GetRandomSize()
        {
            var sizes = Size.All;
            var index = random.Next(0, sizes.Count);
            return sizes.ElementAt(index);
        }

        private Color GetRandomColor()
        {
            var colors = Color.All;
            var index = random.Next(0, colors.Count);
            return colors.ElementAt(index);
        }
    }
}