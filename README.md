# PluralSight Course
https://app.pluralsight.com/library/courses/nunit-3-dotnet-testing-introduction/exercise-files
#
# NUnit Attributes
#
[TestFixture]:	Mark a class that contains tests
#
[Test]:	Mark a method as a test
#
[Category]: Organize test into categories
#
[TestCase]: Data Driven Test Case
#
[Values]: Data driven test parameters
#
[Sequential]: How to combine test data
#
[Setup]: Run code before each test
#
[OneTimeSetup]: Run code before first test in class.
#
# https://www.automatetheplanet.com/nunit-cheat-sheet/
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| NUnit 3.x          | MSTest v2.x.       | xUnit.net 2.x           | Comments                                           |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [Test]             | [TestMethod]       | [Fact]                  | Marks a test method.                               |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [TestFixture]      | [TestClass]        | n/a                     | Marks a test class.                                |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [SetUp]            | [TestInitialize]   | Constructor             | Triggered before every test case.                  |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [TearDown]         | [TestCleanup]      | IDisposable.Dispose     | Triggered after every test case.                   |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [OneTimeSetUp]     | [ClassInitialize]  | IClassFixture<T>        | One-time triggered method before test cases start. |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [OneTimeTearDown]  | [ClassCleanup]     | IClassFixture<T>        | One-time triggered method after test cases end.    |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [Ignore("reason")] | [Ignore]           | [Fact(Skip="reason")]   | Ignores a test case.                               |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [Property]         | [TestProperty]     | [Trait]                 | Sets arbitrary metadata on a test.                 |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [Theory]           | [DataRow]          | [Theory]                | Configures a data-driven test.                     |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#| [Category("")]     | [TestCategory("")] | [Trait("Category", "")] | Categorizes the test cases or classes.             |  |
#+--------------------+--------------------+-------------------------+----------------------------------------------------+--+
#
# Assertions- Constraint Model (https://www.automatetheplanet.com/nunit-cheat-sheet/)
# https://docs.nunit.org/articles/nunit/writing-tests/constraints/Constraints.html
#
Assert.That(28, Is.EqualTo(_actualFuel)); // Tests whether the specified values are equal. 
#
Assert.That(28, Is.Not.EqualTo(_actualFuel)); // Tests whether the specified values are unequal. Same as AreEqual for numeric values.
#
Assert.That(_expectedRocket, Is.SameAs(_actualRocket)); // Tests whether the specified objects both refer to the same object
#
Assert.That(_expectedRocket, Is.Not.SameAs(_actualRocket)); // Tests whether the specified objects refer to different objects
#
Assert.That(_isThereEnoughFuel, Is.True); // Tests whether the specified condition is true
#
Assert.That(_isThereEnoughFuel, Is.False); // Tests whether the specified condition is false
#
Assert.That(_actualRocket, Is.Null); // Tests whether the specified object is null
#
Assert.That(_actualRocket, Is.Not.Null); // Tests whether the specified object is non-null
#
Assert.That(_actualRocket, Is.InstanceOf<Falcon9Rocket>()); // Tests whether the specified object is an instance of the expected type
#
Assert.That(_actualRocket, Is.Not.InstanceOf<Falcon9Rocket>()); // Tests whether the specified object is not an instance of type
#
Assert.That(_actualFuel, Is.GreaterThan(20)); // Tests whether the specified object greater than the specified value
#
Assert.That(28, Is.EqualTo(_actualFuel).Within(0.50));
#
// Tests whether the specified values are nearly equal within the specified tolerance.
#
Assert.That(28, Is.EqualTo(_actualFuel).Within(2).Percent);
#
// Tests whether the specified values are nearly equal within the specified % tolerance.
#
Assert.That(_actualRocketParts, Has.Exactly(10).Items);
#
// Tests whether the specified collection has exactly the stated number of items in it.
#
Assert.That(_actualRocketParts, Is.Unique);
#
// Tests whether the items in the specified collections are unique.
#
Assert.That(_actualRocketParts, Does.Contain(_expectedRocketPart));
#
// Tests whether a given items is present in the specified list of items.
#
Assert.That(_actualRocketParts, Has.Exactly(1).Matches<RocketPart>(part => part.Name == "Door" && part.Height == "200"));
#
// Tests whether the specified collection has exactly the stated item in it.
#
