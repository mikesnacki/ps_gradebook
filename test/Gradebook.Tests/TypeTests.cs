using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        Book GetBook(string name)
        {
            return new Book(name);
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {   
            //arrange - variable declaration
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act - method call for outputs

            //assert - test
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void GetBookReturnsSameObjects()
        {   
            //arrange - variable declaration
            var book1 = GetBook("Book 1");
            var book2 = book1;
            //act - method call for outputs

            //assert - test
            Assert.Same(book1, book2);
        }

        [Fact]
        public void CanSetNameFromReference()
        {   
            //arrange - variable declaration
            var book1 = GetBook("Book 1");
            SetName(book1, "NewName");
            //act - method call for outputs

            //assert - test
            Assert.Equal("NewName", book1.Name);
        }

        public void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void CSharpChangeName()
        {   
            //arrange - variable declaration
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "NewName");
            //act - method call for outputs

            //assert - test
            Assert.Equal("Book 1", book1.Name);
        }

        public void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpChangeNameRef()
        {   
            //arrange - variable declaration
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "NewName");
            //act - method call for outputs

            //assert - test
            Assert.Equal("NewName", book1.Name);
        }

        public void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void TestName()
        {
            //Given
            var x = GetInt();
            SetInt(ref x);
            
            //When
            
            //Then
            Assert.Equal(43, x);
        }

        public int GetInt()
        {
            return 3;
        }
        public int SetInt(ref int x)
        {
            x = 43;
            return x;
        }
    }
}
;