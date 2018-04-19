using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
	public class CoursePrivider : IValueProvider
	{
		public bool ContainsPrefix(string prefix)
		{
			return prefix=="hjyang";
		}
		public string Credits { get; set; }
		public string DepartmentID { get; set; }
		public string Title { get; set; }

		public ValueProviderResult GetValue(string key)
		{
			switch (key)
			{
				case "Credits":return new ValueProviderResult(Credits);
				case "DepartmentID": return new ValueProviderResult(DepartmentID);
				case "Title": return new ValueProviderResult(Title);
				default: return new ValueProviderResult("ABCD");
			}
		}
	}
}
