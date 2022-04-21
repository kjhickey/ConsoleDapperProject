using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CompanyConsole
{
    public class CompanyDatabaseRepository : ICompanyRepository
    {
	   public CompanyDatabaseRepository(string connectionString)
	   {
		  this._connectionString = connectionString;
	   }
	   private string _connectionString;
	  
	   public bool Add(Company company)
	   {
		  var companies = GetAll();
		  int newId = 1;
			 
		  if(companies.Count > 0)
			 newId = companies.Max(x => x.ID) + 1;

		  string sql = "INSERT INTO CompaniesTest Values (@Id, @Name, @YearEstablished, @Revenue, @State)";
		  using (IDbConnection connection = new SqlConnection(_connectionString))
		  {
			 var affectedRows = connection.Execute(sql, new { Id = newId, @Name = company.Name, @YearEstablished = company.YearEstablished, @Revenue = company.Revenue, @State = company.State });
			 return affectedRows > 0;
		  }
		
	   }

	   public bool Delete(int id)
	   {
		  
		  string sql = "DELETE FROM CompaniesTest WHERE Id = @Id";
		  using (IDbConnection connection = new SqlConnection(_connectionString))
		  {
			 int affectedRows = connection.Execute(sql, new { Id = id });

			 return affectedRows > 0;
		  }
			 		 
	   }

	   public List<Company> GetAll()
	   {
		  string sql = "select * from CompaniesTest";
		  using (IDbConnection connection = new SqlConnection(_connectionString))
		  {
			 return connection.Query<Company>(sql).ToList();
		  }
	   }

	   public Company GetById(int id)
	   {
		  string sql = "select * from CompaniesTest where Id = @Id";
		  using (IDbConnection connection = new SqlConnection(_connectionString))
		  {
			 return connection.QuerySingleOrDefault<Company>(sql, new { Id = id });
		  }
	   }

	   public bool Update(Company company)
	   {
			 string sql = "UPDATE CompaniesTest SET Name = @Name, YearEstablished = @YearEstablished, Revenue = @Revenue, State = @State WHERE Id = @Id;";
			 using (IDbConnection connection = new SqlConnection(_connectionString))
			 {
				var affectedRows = connection.Execute(sql, new { Id = company.ID, company.Name, company.YearEstablished, company.Revenue, company.State });
				return affectedRows > 0;
			 }  

	   }
    }
}
