using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        private static IEnumerable<TestCaseData> SearchTestData
        {
            get
            {
                yield return new TestCaseData(new SearchOptions {Colors = new List<Color>(), Sizes = new List<Size>()});
                yield return new TestCaseData(new SearchOptions
                    {Colors = new List<Color> {Color.Red}, Sizes = new List<Size> {Size.Small}});
                yield return new TestCaseData(new SearchOptions
                    {Colors = new List<Color> {Color.Red}, Sizes = new List<Size> {Size.Medium}});
                yield return new TestCaseData(new SearchOptions
                    {Colors = new List<Color> {Color.Yellow}, Sizes = new List<Size> {Size.Large}});
                yield return new TestCaseData(new SearchOptions
                    {Colors = new List<Color> {Color.Yellow, Color.White}, Sizes = new List<Size>()});
            }
        }

        private static IEnumerable<TestCaseData> NoShirtsTestData
        {
            get
            {
                yield return new TestCaseData(null);
                yield return new TestCaseData(new List<Shirt>());
            }
        }

        [Test]
        [TestCaseSource(nameof(NoShirtsTestData))]
        public void Search_ShouldReturnEmptyShirtListAndCountOfSizeAndColorBeZero_WhenShirtsAreNotAvailable(
            List<Shirt> shirts)
        {
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };

            var searchEngine = new SearchEngine(shirts);

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts ?? new List<Shirt>(), searchOptions, results.SizeCounts);
            AssertColorCounts(shirts ?? new List<Shirt>(), searchOptions, results.ColorCounts);
        }

        [Test]
        [TestCaseSource(nameof(SearchTestData))]
        public void Search_ShouldReturnExpectedResult_WhenSearchOptionsAreProvided(SearchOptions searchOptions)
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue)
            };

            var searchEngine = new SearchEngine(shirts);

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }


        [Test]
        public void Search_ShouldThrowArgumentNullException_WhenSearchOptionsIsNull()
        {
            var searchEngine = new SearchEngine(new List<Shirt>());

            Should.Throw<ArgumentNullException>(() => searchEngine.Search(null));
        }
    }
}