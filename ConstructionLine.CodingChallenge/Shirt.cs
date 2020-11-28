using System;

namespace ConstructionLine.CodingChallenge
{
    public class Shirt
    {
        public Shirt(Guid id, string name, Size size, Color color)
        {
            Id = id;
            Name = name;
            Size = size;
            Color = color;
        }

        public Guid Id { get; }

        public string Name { get; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public Tuple<Size, Color> Combination => new Tuple<Size, Color>(Size, Color);
    }
}