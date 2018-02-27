using System;
using System.Text.RegularExpressions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyServices;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestTranslate()
		{
			string input = "Jhon Smith \"123.45\"";
			ITerbilang terbilang = new TerbilangUSD();
			string actual = terbilang.translate(input);
			Assert.AreEqual("Jhon Smith \""+"ONE HUNDRED TWENTY THREE DOLLARS AND FOURTY FIVE CENTS"+"\"", actual);
		}
	}
}
