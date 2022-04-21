using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CompanyConsole;
using System.IO;

namespace CompanyConsole.Tests
{
    public class CompanyTests
    {
	   private readonly CompanyDatabaseRepository _sut;

	   public CompanyTests()
	   {
		  _sut = new CompanyDatabaseRepository("Server=.;Database=CompanyInfo;Trusted_Connection=True;TrustServerCertificate=True;");
	   }

	   [Fact]
	   public void DeleteCompany_ShouldFail()
	   {
		  bool result = _sut.Delete(0);

		  Assert.False(result, "There shouldn't be a company with id 0.");
	   }

	   [Theory]
	   [InlineData(-1)]
	   [InlineData(0)]
	   public void DeleteCompanyZeroAndNegativeValues_ShouldFail(int value)
	   {
		  bool result = _sut.Delete(value);

		  Assert.False(result, $"There shouldn't be a company with id { value }.");
	   }


	   [Fact]
	   public void DeleteCompany_ShouldWork()
	   {
		  bool result = _sut.Delete(1);

		  Assert.True(result, "Company with id 1 should be deleted.");
	   }

	   [Fact]
	   public void GetCompanyByID_ShouldWork()
	   {
		  
		  
	   }

	   [Fact]
	   public void CompanyRepository_Add_Success()
	   {

		  // Arrange
		  Company newCompany = new Company();

		  // Act
		  bool result = _sut.Add(newCompany);

		  // Assert
		  Assert.True(result);

	   }

	   [Fact]
	   public void CompanyRepository_Add_ValidationFailure()
	   {

	   }
    }
}
