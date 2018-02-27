using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class MyContent
	{
		[Required]
		public string input { set; get; }
		public string output { set; get; }

		public MyContent()
		{
			this.input = "Jhon Smith \n \"123.45\" ";
		}
	}
}