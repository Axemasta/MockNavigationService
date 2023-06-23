using MockNavigationService.Helpers;

namespace MockNavigationService.UnitTests.Tests.Helpers;

public class EquivalenceHelperTests
{
    #region Tests

    [Theory]
    [MemberData(nameof(EquivalenceTestData))]
    public void Equivalent_WhenGivenObjects_ShouldReturnTrueIfAllPropertiesMatch(object a, object b, bool expectedResult)
    {
        // Arrange

        // Act
        var result = EquivalenceHelper.Equivalent(a, b);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    #endregion

    #region Test Data

    public static IEnumerable<object[]> EquivalenceTestData
    {
        get
        {
            // Basic compare int - values same
            yield return new object[]
            {
                1,
                1,
                true,
            };

            // Basic compare int - values different
            yield return new object[]
            {
                1,
                100,
                false,
            };

            // Basic compare string - values same
            yield return new object[]
            {
                "Maui",
                "Maui",
                true,
            };

            // Basic compare string - values different
            yield return new object[]
            {
                "Maui",
                "Xamarin",
                false,
            };

            var sameObjectTest = new TestPoco()
            {
                Id = 1337,
                Name = "Gamer",
                Created = new DateTime(2000, 1, 1),
                IsAdmin = true,
            };

            // Complex compare POCO - same object
            yield return new object[]
            {
                sameObjectTest,
                sameObjectTest,
                true,
            };

            // Complex compare POCO - different reference (same values)
            yield return new object[]
            {
                new TestPoco()
                {
                    Id = 2003,
                    Name = "I Miss",
                    Created = new DateTime(2021, 11, 1),
                    IsAdmin = false,
                },
                new TestPoco()
                {
                    Id = 2003,
                    Name = "I Miss",
                    Created = new DateTime(2021, 11, 1),
                    IsAdmin = false,
                },
                true,
            };

            // Complex compare POCO - different reference (different values)
            yield return new object[]
            {
                new TestPoco()
                {
                    Id = 2002,
                    Name = "Does This",
                    Created = new DateTime(2002, 11, 25),
                    IsAdmin = false,
                },
                new TestPoco()
                {
                    Id = 1999,
                    Name = "Of The",
                    Created = new DateTime(1999, 6, 1),
                    IsAdmin = true,
                },
                false,
            };

            // Compare different types
            yield return new object[]
            {
                new TestPoco()
                {
                    Id = 2004,
                    Name = "Three Cheers",
                    Created = new DateTime(2004, 6, 8),
                    IsAdmin = false,
                },
                "Hello World",
                false
            };
        }
    }

    private class TestPoco
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime? Created { get; set; }
    }

    #endregion Test Data
}

