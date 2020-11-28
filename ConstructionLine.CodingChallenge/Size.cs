using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Size : Resource
    {
        public static Size Small = new Size(Guid.NewGuid(), "Small");
        public static Size Medium = new Size(Guid.NewGuid(), "Medium");
        public static Size Large = new Size(Guid.NewGuid(), "Large");

        public static List<Size> All =
            new List<Size>
            {
                Small,
                Medium,
                Large
            };

        private Size(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}