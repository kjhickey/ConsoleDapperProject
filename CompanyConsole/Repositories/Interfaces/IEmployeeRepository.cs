using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsole
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        bool Add(Employee employee);

        Employee GetById(int id);

        bool Update(Employee employee);

        bool Delete(int id);
	   bool DeleteAll(int companyID);
    }
}