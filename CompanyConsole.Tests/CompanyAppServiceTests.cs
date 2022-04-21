using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CompanyConsole;
using System.IO;
using CompanyConsole.AppServices;

namespace CompanyConsole.Tests
{
    public class CompanyAppServiceTests
    {
	   private readonly CompanyAppService _sut;

	   public CompanyAppServiceTests()
	   {
		  _sut = new CompanyAppService(new CompanyDatabaseRepository("Server=.;Database=CompanyInfo;Trusted_Connection=True;TrustServerCertificate=True;"));
	   }
	      

	   [Fact]
	   public void CompanyRepository_Add_Success()
	   {

		  // Arrange
		  Company newCompany = new Company
		  {
			 Name = "Walmart",
			 State = "Texas",
			 YearEstablished = 1954,			 
		  };

		  // Act
		  bool result = _sut.Add(newCompany);

		  // Assert
		  Assert.True(result);

	   }

	   [Fact]
	   public void CompanyRepository_Add_ValidationFailure()
	   {
		  // Arrange
		  Company newCompany = new Company();

		  // Act
		  bool result = _sut.Add(newCompany);

		  // Assert
		  Assert.False(result);

	   }
    }
}
