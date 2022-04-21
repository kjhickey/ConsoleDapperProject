using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyConsole;
using Xunit;
using System.IO;

namespace DemoCompanyConsole.Tests
{
    /*public class ExampleTests
    {
	   [Theory]
	   [InlineData(4, 3, 7)]
	   [InlineData(21, 5.25, 26.25)]
	   [InlineData(double.MaxValue, 5, double.MaxValue)]
	   public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
	   {
		  // Arrange
		  

		  // Act
		  double actual = Calculator.Add(x, y);

		  // Assert
		  Assert.Equal(expected, actual);
	   }

	   [Theory]
	   [InlineData(8, 4, 2)]
	   public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
	   {
		  // Arrange

		  // Act
		  double actual = Calculator.Divide(x, y);

		  // Assert
		  Assert.Equal(expected, actual);
	   }

	  [Fact]
	   public void Divide_DivideByZero()
	   {
		  // Arrange
		  double expected = 0;

		  // Act
		  double actual = Calculator.Divide(15, 0);

		  // Assert
		  Assert.Equal(expected, actual);
	   }

	   // More examples
	   [Fact]
	   public void ExampleLoadTextFIle_ValidNameShouldWork()
	   {
		  string actual = Examples.ExampleLoadTextFile("This is a valid file name.");

		  Assert.True(actual.Length > 0);
	   }

	   [Fact]
	   public void ExampleLoadTextFIle_InvalidNameShouldFail()
	   {
		  Assert.Throws<FileNotFoundException>(() => Examples.ExampleLoadTextFile(""));

		  // Assert.Throws<ArgumentException>("parameterName", () => Examples.ExampleLoadTextFile(""));

	   }

	   [Fact]
	   public void AddPersonToPeopleList_ShouldWork()
	   {
		  PersonModel newPerson = new PersonModel { FirstName = "Tim", LastName = "Corey" };
		  List<PersonModel> people = new List<PersonModel>();

		  DataAccess.AddPersonToPeopleList(people, newPeroson);

		  Assert.True(people.Count == 1);
		  Assert.Contains<PersonModel>(newPerson, people);
	   }

	   [Theory]
	   [InlineData("Tim", "", "LastName")]
	   [InlineData("", "Corey", "FirstName")]
	   public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
	   {
		  PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
		  List<PersonModel> people = new List<PersonModel>();

		  Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));

	   }

    }*/
}