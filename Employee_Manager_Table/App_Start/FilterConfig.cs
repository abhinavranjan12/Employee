using System.Web;
using System.Web.Mvc;

namespace Employee_Manager_Table
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
