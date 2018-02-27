using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
	public  class StringUtility
	{
		public  double[] findNumbersInText(string text)
		{
			double[] result = new double[] { };
			var regex = new Regex("[^\\d,/.]");
			IEnumerable<string> spliters = regex.Split(text).Where(a => a != "");
			if (spliters.Count() > 0)
			{
				result = (from x in spliters
						  select Convert.ToDouble(x)).ToArray();
			}
			return result;
		}
	}
}
