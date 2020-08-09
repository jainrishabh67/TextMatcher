using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatcher.Services;

namespace TextMatcher.Test
{
    [TestClass]
    public class TextMatcherTest
    {
        private readonly string _inputText = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
        private readonly string _inputText1 = "TWO ROADS DIVERGED IN A YELLOW WOOD ROADS";

        [TestMethod]
        public void FindInputNullMatch()
        {
            var subText = "Polly";
            var service = new TextMatcherService();
            var expected = "Either one or both of the string(s) are blank or null";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(null, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindSubTextNullMatch()
        {
            // Arrange
            var service = new TextMatcherService();
            var expected = "Either one or both of the string(s) are blank or null";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindBothNullMatch()
        {
            // Arrange
            var service = new TextMatcherService();
            var expected = "Either one or both of the string(s) are blank or null";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(null, null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindInputEmptyMatch()
        {
            // Arrange
            var subText = "Polly";
            var service = new TextMatcherService();
            var expected = "Either one or both of the string(s) are blank or null";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(string.Empty, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindSubTextEmptyMatch()
        {
            // Arrange
            var service = new TextMatcherService();
            var expected = "Either one or both of the string(s) are blank or null";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText1, "");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubTextWordMatch()
        {
            // Arrange
            var subText = "Polly";
            var service = new TextMatcherService();
            var expected = "1,26,51";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubTextWholeWordMatch()
        {
            // Arrange
            var subText = "TWO ROADS DIVERGED IN A YELLOW WOOD ROADS";
            var service = new TextMatcherService();
            var expected = "1";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText1, subText.ToLower());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubTextSpansWordMatch()
        {
            // Arrange
            var subText = " on, polly put ";
            var service = new TextMatcherService();
            var expected = "21,46";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubTextPartialWordMatch()
        {
            // Arrange
            var subText = "ll";
            var service = new TextMatcherService();
            var expected = "3,28,53,78,82";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubTextNotPresentMatch()
        {
            // Arrange
            var subText = "X";
            var service = new TextMatcherService();
            var expected = "No string matched..";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPartialSubTextMatch()
        {
            // Arrange
            var subText = "Polx";
            var service = new TextMatcherService();
            var expected = "No string matched..";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubTextOverRunMatch()
        {
            // Arrange
            var subText = "Teal";
            var service = new TextMatcherService();
            var expected = "No string matched..";

            // Act
            var actual = service.FindMatchingStringCharacterPositions(_inputText, subText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharMatchCaseInsenitive()
        {
            // Arrange
            var service = new TextMatcherService();

            // Check for A == B
            Assert.IsFalse(service.IsCaseInsensitiveCharacterMatching('A', 'B'));
            // Check for a == b
            Assert.IsFalse(service.IsCaseInsensitiveCharacterMatching('a', 'b'));
            // Check for a == B
            Assert.IsFalse(service.IsCaseInsensitiveCharacterMatching('a', 'B'));
            // Check for E == e
            Assert.IsTrue(service.IsCaseInsensitiveCharacterMatching('E', 'e'));
            // Check for D == d
            Assert.IsTrue(service.IsCaseInsensitiveCharacterMatching('D', 'd'));

            Assert.IsTrue(service.IsCaseInsensitiveCharacterMatching('X', 'X'));

            Assert.IsTrue(service.IsCaseInsensitiveCharacterMatching('y', 'y'));
        }
    }
}
