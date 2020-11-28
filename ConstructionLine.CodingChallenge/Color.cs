using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Color : Resource
    {
        public static Color Red = new Color(Guid.NewGuid(), "Red");
        public static Color Blue = new Color(Guid.NewGuid(), "Blue");
        public static Color Yellow = new Color(Guid.NewGuid(), "Yellow");
        public static Color White = new Color(Guid.NewGuid(), "White");
        public static Color Black = new Color(Guid.NewGuid(), "Black");

        public static List<Color> All =
            new List<Color>
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            };

        private Color(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}