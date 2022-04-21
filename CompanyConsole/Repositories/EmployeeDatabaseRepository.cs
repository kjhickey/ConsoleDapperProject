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
    public class EmployeeDatabaseRepository : IEmployeeRepository
    {
	   public bool Add(Employee employee)
	   {
		  var procedure = "spEmployee_Add";
		  using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CompanyDB")))
		  {
			 var affectedRows = connection.Execute(procedure, 
			 new { employee.FirstName, employee.LastName, employee.PhoneNumber, employee.EmailAddress, employee.CompanyId },
			 commandType: CommandType.StoredProcedure);
			 return affectedRows > 0;
		  }

	   }

	   public bool Delete(int id)
	   {

		  var procedure = "spEmployee_DeleteEmployee";
		  using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CompanyDB")))
		  {
			 int affectedRows = connection.Execute(procedure, new { @id = id }, commandType: CommandType.StoredProcedure);

			 return affectedRows > 0;
		  }

	   }

	   public bool DeleteAll(int companyID)
	   {
		  var procedure = "spEmployee_DeleteAllEmployeesFromCompany";
		  using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CompanyDB")))
		  {
			 int affectedRows = connection.Execute(procedure, new { @companyID = companyID }, commandType: CommandType.StoredProcedure);

			 return affectedRows > 0;
		  }
	   }

	   public List<Employee> GetAll()
	   {
		  var procedure = "spEmployee_GetAll";
		  using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CompanyDB")))
		  {
			 return connection.Query<Employee>(procedure, commandType: CommandType.StoredProcedure).ToList();			
		  }
	   }

	   public Employee GetById(int id)
	   {
		  var procedure = "spEmployee_GetEmployee";
		  using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CompanyDB")))
		  {
			 return connection.QuerySingleOrDefault<Employee>(procedure, new { @id = id }, commandType: CommandType.StoredProcedure);
		  }
	   }

	   public bool Update(Employee employee)
	   {
		  var procedure = "spEmployee_Update";
		  using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CompanyDB")))
		  {
			 var affectedRows = connection.Execute(procedure,
			 new { id = employee.Id, employee.FirstName, employee.LastName, employee.PhoneNumber, employee.EmailAddress, employee.CompanyId }, 
			 commandType: CommandType.StoredProcedure);
			 return affectedRows > 0;
		  }

	   }
    }
}

