using System;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTest
    {
        int count = 0;
        public delegate string WriteLogDelegateCanPoint(string message);

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
        WriteLogDelegateCanPoint log = ReturnValue;
        log+=ReturnValue;
        
        //When
        var result =  log("Hello");
        
        //Then
        Assert.Equal("Hello", result);
        }


        public string ReturnValue(string message)
        {   
            count++;
            return message;
        }

        [Fact]
        public void BookCaclulatesStats()
        {   
            //arrange - variable declaration
            var book = new BookInMemory("");
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
