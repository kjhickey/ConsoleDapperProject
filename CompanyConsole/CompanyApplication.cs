using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CompanyConsole
{
    public class CompanyApplication
    {

        ICompanyRepository companyRepository;
        IEmployeeRepository employeeRepository;

        public CompanyApplication()
        {
            string connectionString = Helper.CnnVal("CompanyDB");
            companyRepository = new CompanyDatabaseRepository(connectionString);
            employeeRepository = new EmployeeDatabaseRepository();
        }


        public void SelectOption()
        {
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("Welcome To Dapper Example :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("1. List Companies");
            Console.WriteLine("2. Find Company by ID");
            Console.WriteLine("3. Add Company");
            Console.WriteLine("4. Update Company");
            Console.WriteLine("5. Delete Company");
            Console.WriteLine("6. List Employees");
            Console.WriteLine("7. Close");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    GetCompanies();
                    break;
                case 2:
                    GetCompanyByID();
                    break;
                case 3:
                    AddCompany();
                    break;
                case 4:
                    UpdateCompany();
                    break;
                case 5:
                    DeleteCompany();
                    break;
                case 6:
                    GetEmployees();
                    break;
                case 7:
                    End();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
        }

        public void Start()
        {
            SelectOption();
        }

        public void End()
        {
            Environment.Exit(0);
        }

        public void AddCompany()
	   {
		  Company newCompany = new Company();

            RequestChanges(newCompany);

            
            //if (issues.Any())
            //{

                companyRepository.Add(newCompany);

                Console.WriteLine("Comapny successfully added!");
    //        }
    //        else
		  //{
    //            foreach(var issue in issues)
			 //{
    //                Console.WriteLine(issue.ErrorMessage);
			 //}
		  //}

	   }

	   private static void RequestChanges(Company newCompany)
	   {
		  Console.WriteLine("Enter the Company Name:");
		  newCompany.Name = Console.ReadLine();

		  Console.WriteLine("Enter the Year the company was established:");
		  newCompany.YearEstablished = Convert.ToInt32(Console.ReadLine());

		  Console.WriteLine("Enter the Company's revenue:");
		  newCompany.Revenue = Convert.ToInt32(Console.ReadLine());

		  Console.WriteLine("Enter the Company's state of origin:");
		  newCompany.State = Console.ReadLine();
	   }
        private static void RequestChanges(Employee newEmployee)
        {
            Console.WriteLine("Enter the Employee's First Name:");
            newEmployee.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Employee's Last Name:");
            newEmployee.LastName = Console.ReadLine();

            Console.WriteLine("Enter the Employee's phone number:");
            newEmployee.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the Employee's email address:");
            newEmployee.EmailAddress = Console.ReadLine();

            Console.WriteLine("Enter the Employee's company ID:");
            newEmployee.CompanyId = Convert.ToInt32(Console.ReadLine());
        }

        public void GetCompanyByID()
	   {
            Console.WriteLine("Enter Company ID for info.");
            string input = Console.ReadLine();

            Company matchingCompany = null;

            int companyID;
		  if (int.TryParse(input, out companyID))
            {
                matchingCompany = companyRepository.GetById(companyID);
            }
            else
            {
                Console.WriteLine("Invalid Company ID.");
            }
            if (matchingCompany != null)
		  {
                Console.WriteLine(matchingCompany.ToString());
		  }
            else
		  {
                Console.WriteLine("Company could not be found.");
		  }


        }

        public void GetCompanies()
        {
            Console.WriteLine("***** Companies: *****");

            List<Company> companies = companyRepository.GetAll();
            foreach (Company c in companies)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void UpdateCompany()
        {
            Console.WriteLine("Ender company ID to update.");
            string input = Console.ReadLine();
            
            Company matchingCompany = null;

            int companyID;
            if (int.TryParse(input, out companyID))
            {
                matchingCompany = companyRepository.GetById(companyID);               
            }
            else
            {
                Console.WriteLine("Invalid Company ID.");
            }

            if (matchingCompany != null)
            {
                Console.WriteLine(matchingCompany.ToString());
            }
            else
            {
                Console.WriteLine("Company could not be found.");
                SelectOption();
            }

            RequestChanges(matchingCompany);
            companyRepository.Update(matchingCompany);

        }

        public void DeleteCompany()
	   {
            Console.WriteLine("Enter an ID to delete.");

            int companyID = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out companyID))
		  {
                companyRepository.Delete(companyID);
		  }
		  else
		  {
                Console.WriteLine("Invalid Company ID.");
		  }

	   }

        public void GetEmployees()
        {
            Console.WriteLine("***** Employees: *****");

            List<Employee> employees = employeeRepository.GetAll();
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.ToString());

            }

            Console.WriteLine("1. Find Employee");
            Console.WriteLine("2. Add Empoyee");
            Console.WriteLine("3. Update Employee info");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Delete ALL employees from company:");
            Console.WriteLine("6. Close");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    GetEmployeeById();
                    break;
                case 2:
                    AddEmployee();
                    break;
                case 3:
                    UpdateEmployee();
                    break;
                case 4:
                    DeleteEmployee();
                    break;
                case 5:
                    DeleteAllEmployeesFromCompany();
                    break;
                case 6:
                    End();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));

        }
        public void AddEmployee()
        {
            Employee newEmployee = new Employee();

            RequestChanges(newEmployee);

            employeeRepository.Add(newEmployee);

            Console.WriteLine("Employee successfully added!");

        }

        public void UpdateEmployee()
	   {
            Console.WriteLine("Ender employee ID to update.");
            string input = Console.ReadLine();

            Employee matchingEmployee = null;

            int employeeID;
            if (int.TryParse(input, out employeeID))
            {
                matchingEmployee = employeeRepository.GetById(employeeID);
            }
            else
            {
                Console.WriteLine("Invalid employee ID.");
            }

            if (matchingEmployee != null)
            {
                Console.WriteLine(matchingEmployee.ToString());
            }
            else
            {
                Console.WriteLine("Employee could not be found.");
                GetEmployees();
            }

            RequestChanges(matchingEmployee);
            employeeRepository.Update(matchingEmployee);
        }

        public void GetEmployeeById()
	   {
            Console.WriteLine("Enter Employee's ID:");
            string input = Console.ReadLine();

            Employee matchingEmployee = null;

            int employeeID;
            if (int.TryParse(input, out employeeID))
            {
                matchingEmployee = employeeRepository.GetById(employeeID);
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
            if (matchingEmployee != null)
            {
                Console.WriteLine(matchingEmployee.ToString());
            }
            else
            {
                Console.WriteLine("Employee could not be found.");
            }
        }

        public void DeleteEmployee()
	   {
            Console.WriteLine("Enter an ID to delete.");

            int employeeID = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out employeeID))
            {
                employeeRepository.Delete(employeeID);
            }
            else
            {
                Console.WriteLine("Invalid employee ID.");
            }
        }

        public void DeleteAllEmployeesFromCompany()
	   {
            Console.WriteLine("Enter a company Id to delete ALL employees.");

            int companyID = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out companyID))
            {
                employeeRepository.DeleteAll(companyID);
            }
            else
            {
                Console.WriteLine("Invalid company ID.");
            }

        }
    }
}
