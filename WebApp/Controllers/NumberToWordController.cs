using MyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class NumberToWordController : Controller
    {

		ITerbilang serviceTerbilang;
		public NumberToWordController(ITerbilang terbilang)
		{
			this.serviceTerbilang = terbilang;
		}

        // GET: NumberToWord
        public ActionResult Index(MyContent postData)
        {
		
			if (ModelState.IsValid)
			{
				postData.output = this.serviceTerbilang.translate(postData.input).Replace("\n","<br>");
			}
            return View(postData);
        }
    }
}