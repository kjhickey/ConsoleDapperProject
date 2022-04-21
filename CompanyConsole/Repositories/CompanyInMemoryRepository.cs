using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsole
{
    class CompanyInMemoryRepository : ICompanyRepository
    {
	   private List<Company> _companies;

	   public CompanyInMemoryRepository()
	   {
		  _companies = new List<Company>();
	   }

	   public bool Add(Company companyToAdd)
	   {
		  companyToAdd.ID = _companies.Count > 0 ? _companies.Max(x => x.ID) + 1 : 1;
		  _companies.Add(companyToAdd);
		  return true;
	   }

	   public bool Delete(int id)
	   {
		  Company companyToDelete = _companies.SingleOrDefault(x => x.ID == id);
		  if (companyToDelete != null)
		  {
			 _companies.Remove(companyToDelete);
			 return true;
		  }

		  return false;
		 
	   }

	   public List<Company> GetAll()
	   {
		  return _companies;
	   }

	   public Company GetById(int id)
	   {
		  var company = _companies.SingleOrDefault(x => x.ID == id);
		  Company referenceBreaker = new()
		  {
			 ID = company.ID, Name = company.Name
		  };

		  return referenceBreaker;
	   }

	   public bool Update(Company company)
	   {
		  Company companyToUpdate = _companies.SingleOrDefault(x => x.ID == company.ID);
		  if (companyToUpdate == null)
		  {
			 return false;
		  }

		  companyToUpdate.Name = company.Name;

		  return true;
	   }
    }
}
