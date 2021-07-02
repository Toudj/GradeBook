using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateAverage()
        {
            //arrange
           var book = new Book("");

           book.AddGrade(89.1);
           book.AddGrade(100);
           book.AddGrade(50);
           book.AddGrade(2);
           book.AddGrade(18);

            //act
            
           var result = book.GetStatistics();

            //assert
            Assert.Equal(259.1, result.Total, 1);
            Assert.Equal(5, result.nAcademics);
            Assert.Equal(51.8, result.Average, 1);
            Assert.Equal(2.0, result.Low, 1);
            Assert.Equal(100.0, result.High, 1);
            Assert.Equal('F', result.Letter);
            
        }
    }
}
