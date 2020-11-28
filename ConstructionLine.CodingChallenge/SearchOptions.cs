using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchOptions
    {
        public List<Size> Sizes { get; set; } = new List<Size>();

        public List<Color> Colors { get; set; } = new List<Color>();

        public List<Tuple<Size, Color>> GenerateSearchCombination()
        {
            var searchSizes = Sizes.Count > 0 ? Sizes : Size.All;
            var searchColors = Colors.Count > 0 ? Colors : Color.All;

            var result = (searchSizes.SelectMany(size => searchColors,
                (size, color) => new Tuple<Size, Color>(size, color))).ToList();

            return result;
        }
    }
}