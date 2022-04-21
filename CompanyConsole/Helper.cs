using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CompanyConsole
{
    public static class Helper
    {
	   public static string CnnVal(string name)
	   {
		  return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
	   }
    }
}
