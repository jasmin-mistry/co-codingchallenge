using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            this.shirts = shirts;
        }

        public SearchResults Search(SearchOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (shirts == null || !shirts.Any())
                return new SearchResults(new List<Shirt>());

            var searchCombination = options.GenerateSearchCombination();

            var result = shirts
                .Where(s => searchCombination.Contains(s.Combination))
                .Select(x => x).AsEnumerable();

            return new SearchResults(result.ToList());
        }
    }
}