using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsole
{
    public class Employee : IValidatableObject
    {	
	   public int Id { get; set; }
	  
	   public string FirstName { get; set; }

	   public string LastName { get; set; }

	   public string PhoneNumber { get; set; }

	   public string EmailAddress { get; set; }

	   public int CompanyId { get; set; }

	   public override string ToString()
	   {
		  return $"Employee Id: {Id} Name: { FirstName + " " + LastName } Phone: { PhoneNumber } Email: { EmailAddress} Company Id: { CompanyId }";
	   }

	   public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	   {
		  if (FirstName == null)
		  {
			 yield return new ValidationResult("First name cannot be empty");
		  }

		  if (FirstName.Count() > 25)
		  {
			 yield return new ValidationResult("First name cannot be empty");
		  }

		  if (LastName == null)
		  {
			 yield return new ValidationResult("Last name cannot be empty");
		  }

		  if (PhoneNumber == null)
		  {
			 yield return new ValidationResult("Phone number cannot be empty");
		  }

		  if (EmailAddress == null)
		  {
			 yield return new ValidationResult("Email address cannot be empty");
		  }

		  if (CompanyId < 1)
		  {
			 yield return new ValidationResult("CompanyId cannot be zero or negative.");
		  }
	   }
    }
}
