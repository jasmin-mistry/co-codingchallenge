using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResults
    {
        public SearchResults(List<Shirt> shirtsFound)
        {
            Shirts = shirtsFound;
        }

        public List<Shirt> Shirts { get; }

        public List<SizeCount> SizeCounts
        {
            get
            {
                return Size.All.Select(x => new SizeCount
                {
                    Size = x,
                    Count = Shirts.Count(s => s.Size == x)
                }).ToList();
            }
        }

        public List<ColorCount> ColorCounts
        {
            get
            {
                return Color.All.Select(x => new ColorCount
                {
                    Color = x,
                    Count = Shirts.Count(s => s.Color == x)
                }).ToList();
            }
        }
    }
}