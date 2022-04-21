using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsole
{
    public class Company : IValidatableObject
    {
	   public int ID { get; set; }
	   
	   public string Name { get; set; }

	   public int YearEstablished { get; set; }

	   public double Revenue { get; set; }

	   public string State { get; set; }

	   public override string ToString()
	   {
		  return $"Id: {ID} Name: { Name } Year Established: { YearEstablished } Revenue: { Revenue } State: { State }";
	   }

	   public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	   {
		  if (YearEstablished > 2022)
		  {
			 yield return new ValidationResult("Year established can't be in the future.");
		  }

		  if (YearEstablished < 0)
		  {
			 yield return new ValidationResult("Year established can't be less then zero");
		  }

		  if (Name == null)
		  {
			 yield return new ValidationResult("Name cannot be empty");
		  }

		  if (State == null)
		  {
			 yield return new ValidationResult("State cannot be empty");
		  }
	   }
    }
}
