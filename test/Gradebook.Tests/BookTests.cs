using System;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BookCaclulatesStats()
        {   
            //arrange - variable declaration
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act - method call for outputs
            var result = book.GetStatistics();

            //assert - test
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
