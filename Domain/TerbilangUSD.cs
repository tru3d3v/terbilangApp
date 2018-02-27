using MyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class TerbilangUSD:ITerbilang
    {
		IDictionary<int, string> numbers = new Dictionary<int, string>();
		IDictionary<int, string> tens = new Dictionary<int, string>();
		StringUtility stringUtility = new StringUtility();
		public TerbilangUSD() {

			// Basic Number
			numbers.Add(1, "One");
			numbers.Add(2, "Two");
			numbers.Add(3, "Three");
			numbers.Add(4, "Four");
			numbers.Add(5, "Five");
			numbers.Add(6, "Six");
			numbers.Add(7, "Seven");
			numbers.Add(8, "Eight");
			numbers.Add(9, "Nine");


			// Tens
			tens.Add(10, "Ten");
			tens.Add(11, "Eleven");
			tens.Add(12, "Twelve");
			tens.Add(13, "Thirteen");
			tens.Add(14, "Fourteen");
			tens.Add(15, "Fifteen");
			tens.Add(16, "Sixteen");
			tens.Add(17, "Seventeen");
			tens.Add(18, "Eighteen");
			tens.Add(19, "Nineteen");
			tens.Add(20, "Twenty");
			tens.Add(30, "Thirty");
			tens.Add(40, "Fourty");
			tens.Add(50, "Fifty");
			tens.Add(60, "Sixty");
			tens.Add(70, "Seventy");
			tens.Add(80, "Eighty");
			tens.Add(90, "Ninety");
		}

		/// <summary>
		/// 0
		/// </summary>
		/// <returns></returns>
		private string numsQuery(int number)
		{

			string word = string.Empty;

			var find = numbers.Where(x => x.Key == number);

			if (find.Count() > 0)
			{
				word = find.First().Value;
			}

			return word;
		}

		private string tensQuery(int number)
		{
			string word = string.Empty;
			var find = tens.Where(x => x.Key == number);

			if (find.Count() > 0)
			{
				//  Query to find tens in Dictionary
				word = find.First().Value;
			}
			else // Query Not Found
			{
				//Find from Nums other ten and Ones
				if (number > 0)
				{
					// Puluhan Splitter
					string strPuluhan = number.ToString().Substring(0, 1) + "0";

					// Satuan Split from puluhan
					string strSatuan = number.ToString().Substring(1);

					word = tensQuery(Convert.ToInt32(strPuluhan))+" "+numsQuery(Convert.ToInt32(strSatuan));
				}
				
			}

			return word;
		}

		private string queries(double number)
		{
			string word = string.Empty;

			try
			{
				int digitLength = number.ToString().Length;
				bool isFounded = false;
				int indexGroupDigitMoney = 0;
				string groupName = string.Empty;

				if (digitLength == 1) // ones
				{
					word = numsQuery(Convert.ToInt32(number));
					isFounded = true;
				}
				else if (digitLength == 2) // tens
				{
					word = tensQuery(Convert.ToInt32(number));
					isFounded = true;
				}
				else if (digitLength == 3)// hundreds
				{
					indexGroupDigitMoney = (digitLength % 3) + 1;
					groupName = " Hundred ";
				}
				else if (digitLength == 4 || digitLength == 5 || digitLength == 6)// Thousands
				{
					indexGroupDigitMoney = (digitLength % 4) + 1;
					groupName = " Thousand ";
				}
				else if (digitLength == 7 || digitLength == 8 || digitLength == 9)// Millions
				{
					indexGroupDigitMoney = (digitLength % 7) + 1;
					groupName = " Million ";
				}
				else if (digitLength == 10 || digitLength == 11 || digitLength == 12)// Billions's 
				{
					indexGroupDigitMoney = (digitLength % 10) + 1;
					groupName = " Billion ";
				}
				else
				{
					word = "Maximum numbers 12 digit";
					isFounded = true;
				}

				if (!isFounded)
				{
					string str1 = number.ToString().Substring(0, indexGroupDigitMoney);
					string str2 = number.ToString().Substring(indexGroupDigitMoney);
					if (str1 != "0" && str2 != "0") 
					{
						try // Recursive
						{
							word = queries(Convert.ToInt32(str1)) + groupName + queries(Convert.ToInt32(str2));
						}
						catch (Exception exc)
						{
							word = "Error recursive " + exc.Message;
						}
					}
					else
					{
						word = queries(Convert.ToInt32(str1)) + queries(Convert.ToInt32(str2));
					}
				}

				if (word.Trim().CompareTo(groupName) == 0)
				{
					word = string.Empty;
				}


			}
			catch (Exception exc)
			{
				word = "Error recursive " + exc.Message;
			}
			

			return word;

		}
		
		public string convertNumberToWord(double number)
		{
			string result = string.Empty,
				strAnd = string.Empty,
				digitPointAmountStr=string.Empty, 
				strCent = string.Empty;

			double fullAmount=0, digitPointAmount=0;

			try
			{
				int decimalIndex = number.ToString().IndexOf(".");
				if (decimalIndex > 0)
				{
					fullAmount = Convert.ToDouble(number.ToString().Substring(0, decimalIndex));
					digitPointAmount = Convert.ToDouble(number.ToString().Substring(decimalIndex + 1));

					if (digitPointAmount > 0)
					{
						strAnd = "and";// just to separate whole numbers from points/cents   
						strCent = "cents";

						if (digitPointAmount.ToString().Length > 2) // Only 2 digit Cents
						{
							return "[Maximum 2 digit Cents. Please correct your Amount]";
						}
						digitPointAmountStr = queries(digitPointAmount);
					}
				}
				else
				{
					fullAmount = number;
				}
				result = String.Format("{0} dollars {1} {2} {3}", queries(fullAmount).Trim(), strAnd, digitPointAmountStr, strCent);

			}
			catch
			{
				return "ERROR";
			}

			return result;
		}

		// Final Method
		public string translate(string text)
		{
			string result = text;

			// Find Amount collections  in Text
			double[] numberCollection = stringUtility.findNumbersInText(text);

			// Translate Amount Collection to Wording
			foreach (var amountItem in numberCollection)
			{
				string wordTranslated = this.convertNumberToWord(amountItem).ToUpper();

				result = result.Replace(amountItem.ToString(), wordTranslated);
			}

			return result;
		}
	}
}
