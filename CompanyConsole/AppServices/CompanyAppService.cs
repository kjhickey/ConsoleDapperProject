using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsole.AppServices
{
    public class CompanyAppService
    {
	   private ICompanyRepository _companyRepository;

	   public CompanyAppService(ICompanyRepository companyRepository)
	   {
		  this._companyRepository = companyRepository;
	   }

	   public bool Add(Company company)
	   {
		  bool result = false;

		  var issues = company.Validate(null);

		  if (issues.Any())
		  {
			 return false;
		  }
		  else
		  {
			 result = _companyRepository.Add(company);
		  }
		  
		  return result;
	   }
    }
}
