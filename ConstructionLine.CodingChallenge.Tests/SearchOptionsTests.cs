using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchOptionsTests
    {
        private static IEnumerable<TestCaseData> SearchCombinationTestData
        {
            get
            {
                var allSearchCombinations = (from size in Size.All
                    from color in Color.All
                    select new Tuple<Size, Color>(size, color)).ToList();

                yield return new TestCaseData(new SearchOptions(), allSearchCombinations);
                yield return new TestCaseData(
                    new SearchOptions {Sizes = new List<Size>(), Colors = new List<Color>()},
                    allSearchCombinations);
                yield return new TestCaseData(
                    new SearchOptions
                    {
                        Sizes = new List<Size> {Size.Medium},
                        Colors = new List<Color> {Color.Red}
                    },
                    new List<Tuple<Size, Color>>
                    {
                        new Tuple<Size, Color>(Size.Medium, Color.Red)
                    });
                yield return new TestCaseData(
                    new SearchOptions
                    {
                        Sizes = new List<Size> {Size.Medium}
                    },
                    (from color in Color.All select new Tuple<Size, Color>(Size.Medium, color)).ToList());
                yield return new TestCaseData(
                    new SearchOptions
                    {
                        Colors = new List<Color> {Color.Red}
                    },
                    (from size in Size.All select new Tuple<Size, Color>(size, Color.Red)).ToList());
                yield return new TestCaseData(
                    new SearchOptions
                    {
                        Sizes = new List<Size> {Size.Small, Size.Medium},
                        Colors = new List<Color> {Color.Black, Color.Yellow, Color.Blue}
                    },
                    new List<Tuple<Size, Color>>
                    {
                        new Tuple<Size, Color>(Size.Small, Color.Black),
                        new Tuple<Size, Color>(Size.Small, Color.Yellow),
                        new Tuple<Size, Color>(Size.Small, Color.Blue),
                        new Tuple<Size, Color>(Size.Medium, Color.Black),
                        new Tuple<Size, Color>(Size.Medium, Color.Yellow),
                        new Tuple<Size, Color>(Size.Medium, Color.Blue)
                    });
            }
        }

        [Test]
        [TestCaseSource(nameof(SearchCombinationTestData))]
        public void GenerateSearchCombination_ShouldReturnExpectedSearchCombinationOfSizeAndColor
            (SearchOptions searchOptions, List<Tuple<Size, Color>> expectedCombination)
        {
            var result = searchOptions.GenerateSearchCombination();

            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(expectedCombination);
        }
    }
}