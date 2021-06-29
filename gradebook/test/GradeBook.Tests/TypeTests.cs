using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
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

        void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            
            
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
           
            var book1 = GetBook("Book1");  
            GetBookSetName(book1, "New Name"); 

            Assert.Equal("Book1", book1._name); 
             
        }

        void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            
            
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           
            var book1 = GetBook("Book1");  
            SetName(book1, "New Name"); 

            Assert.Equal("New Name", book1._name); 
             
        }

        void SetName(Book book, string name)
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

         public void TwoVarsReferenceSameObject()
        {
            
            var book1 = GetBook("Book1");  
            var book2 = book1; 

            Assert.Same(book1, book2); 
            Assert.True(Object.ReferenceEquals(book1, book2)); 
                
            
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }

    }
}
