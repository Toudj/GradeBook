using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogMultipleDelegateCanPointToMethod()
        {
        //Given
            WriteLogDelegate log = ReturnMessage;
            //log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello!");

        //When
            Assert.Equal(3, count);
        //Then
        }
          string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
            WriteLogDelegate log;
            log = new WriteLogDelegate(ReturnMessage);
            //log = ReturnMessage;
            var result = log("Hello!");

            

        //When
            Assert.Equal("Hello!", result);
        //Then
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            
            string name = "Toudj"; 
            var upper = MakeUpper(name);
            Assert.Equal("Toudj", name);
            Assert.Equal("TOUDJ", upper); 
             
        }
        string MakeUpper(string param)
        {
            return param.ToUpper();
        }
        [Fact]
        public void IntByRef()
        {
            
            var x = GetInt(); 
            setInt(ref x);
            Assert.Equal(42, x); 
             
        }
        void setInt(ref int z)
        {
            z = 42;
        }
        int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            
            var book1 = GetBook("Book1");  
            GetBookSetName(ref book1, "New Name"); 

            Assert.Equal("New Name", book1._name); 
             
        }

        void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
           
            var book1 = GetBook("Book1");  
            GetBookSetName(book1, "New Name"); 

            Assert.Equal("Book1", book1._name); 
             
        }

        void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           
            var book1 = GetBook("Book1");  
            SetName(book1, "New Name"); 

            Assert.Equal("New Name", book1._name); 
             
        }

        void SetName(InMemoryBook book, string name)
        {
            book._name = name;
        }


        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            
            var book1 = GetBook("Book1");  
            var book2 = GetBook("Book2");   

            Assert.Equal("Book1", book1._name); 
            Assert.Equal("Book2", book2._name); 
            Assert.NotSame(book1, book2);    
            
        }
        [Fact]
         public void TwoVarsReferenceSameObject()
        {
            
            var book1 = GetBook("Book1");  
            var book2 = book1; 

            Assert.Same(book1, book2); 
            Assert.True(Object.ReferenceEquals(book1, book2)); 
                
            
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

    }
}
