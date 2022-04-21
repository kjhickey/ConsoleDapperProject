using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsole
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();

        bool Add(Company company);

        Company GetById(int id);

        bool Update(Company company);

        bool Delete(int id);
    }
}
