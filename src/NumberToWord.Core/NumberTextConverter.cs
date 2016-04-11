using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NumberToWord.Test;

namespace NumberToWord.Core
{
    public class NumberTextConverter : INumberTextConverter
    {
		static string[] Ones = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
		static string[] Teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
		static string[] Tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
		static string[] ThousandsGroups = { "tens", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion" };
		private static string hundred = "hundred";

		private Dictionary<string, int> numberDic;

		public NumberTextConverter()
		{
			numberDic = new Dictionary<string, int>();
			numberDic.Add("one", 1);
			numberDic.Add("two", 2);
			numberDic.Add("three", 3);
			numberDic.Add("four", 4);
			numberDic.Add("five", 5);
			numberDic.Add("six", 6);
			numberDic.Add("seven", 7);
			numberDic.Add("eight", 8);
			numberDic.Add("nine", 9);
			numberDic.Add("ten", 10);
			numberDic.Add("eleven", 11);
			numberDic.Add("twelve", 12);
			numberDic.Add("thirteen", 13);
			numberDic.Add("fourteen", 14);
			numberDic.Add("fifteen", 15);
			numberDic.Add("sixteen", 16);
			numberDic.Add("seventeen", 17);
			numberDic.Add("eighteen", 18);
			numberDic.Add("nineteen", 19);
			numberDic.Add("twenty", 20);
			numberDic.Add("thirty", 30);
			numberDic.Add("forty", 40);
			numberDic.Add("fifty", 50);
			numberDic.Add("sixty", 60);
			numberDic.Add("seventy", 70);
			numberDic.Add("eighty", 80);
			numberDic.Add("ninety", 90);
			numberDic.Add("hundred", 100);
		}


		public string IntegerToWritten(string n, bool isUs = false)
		{
			n = n.Replace(",", string.Empty);

			if (!IsDigitsOnly(n))
			{
				throw new NumberTextConverterException("Invalid number");
			}

		    if (n.Length > 36)
		    {
			    throw  new NumberTextConverterException("Number too big");
		    }

			if (n == "0")
			{
				return Ones[0];
			}

			var coreData = new Dictionary<string, int>();

		    var temp = n.Reverse().ToList();
		    var thousandGroupIndex = 0;
		    while (temp.Any())
		    {
			    var p = string.Concat(temp.Take(3).Reverse());
				coreData.Add(ThousandsGroups[thousandGroupIndex], Convert.ToInt32(p));
				temp = temp.Skip(3).ToList();
				thousandGroupIndex++;

		    }

			var transferedData = TransferData(isUs, coreData);

			var result = ConstructNumberText(isUs, transferedData);

			return result;
	    }

	    private string ConstructNumberText(bool isUs, Dictionary<string, string> transferedData)
	    {
		    var result = "";
		    foreach (var magName in ThousandsGroups.Reverse().ToList())
		    {
			    if (!transferedData.ContainsKey(magName))
				    continue;

			    if (string.IsNullOrWhiteSpace(transferedData[magName]))
				    continue;

			    if (magName == ThousandsGroups[0])
			    {
				    if (!isUs)
				    {
					    result = result.TrimEnd().Trim(',');
				    }

				    result += (!isUs && !string.IsNullOrWhiteSpace(result) ? " and" : "") +
				              (!string.IsNullOrWhiteSpace(result) ? " " : "") + transferedData[magName];
			    }
			    else
			    {
				    result += transferedData[magName] + " " + magName + ", ";
			    }
		    }

		    result = result.Trim().TrimEnd(',');
		    return result;
	    }

	    private Dictionary<string, string> TransferData(bool isUs, Dictionary<string, int> coreData)
	    {
		    var transferedData = new Dictionary<string, string>();

		    foreach (var key in coreData.Keys)
		    {
			    var value = coreData[key];

			    var str = ParseNumber(value, "", isUs);

			    transferedData.Add(key, str);
		    }
		    return transferedData;
	    }

		private bool IsDigitsOnly(string str)
		{
			return str.All(c => c >= '0' && c <= '9');
		}

		private string ParseNumber(int n, string leftStr, bool isUs = false)
		{
			if (n == 0)
			{
				return leftStr;
			}

			var friendlyInt = leftStr;

			if (friendlyInt.Any())
			{
				friendlyInt += " ";
			}

			if (n < 100 && n > 0)
			{
				string[] array = leftStr.Split(' ');
				if ((array[array.Count() - 1].Equals(hundred)) && !isUs)
				{
					friendlyInt += "and ";
				}
			}

			if (n < 10)
			{
				friendlyInt += Ones[n];
			}
			else if (n < 20)
			{
				friendlyInt += Teens[n - 10];
			}
			else if (n < 100)
			{
				friendlyInt += ParseNumber(n % 10, Tens[n / 10 - 2], isUs);
			}
			else
			{
				string[] a = leftStr.Split(' ');

				friendlyInt += ParseNumber(n % 100, (Ones[n / 100] + " " + hundred), isUs);
			}

			return friendlyInt;
		}

		public string WrittenToInteger(string numberText)
	    {
			numberText = numberText.Trim();
			numberText = numberText.ToLower();
			List<string> words = numberText.Split(new[] { ',', ' ' }).ToList();
			
			int tempNumber = 0;

		    words = words.Select(w =>
		    {
			    w = w.Trim().Trim(',');
			    return w;
		    }).ToList();

			words.RemoveAll(string.IsNullOrWhiteSpace);


			var transferedData = new Dictionary<string, int>();

			for (var i = 0; i < words.Count; i++)
			{
				var word = words[i];
				if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
				{
					continue;
				}
				if (!numberDic.ContainsKey(word) && !(Array.IndexOf(ThousandsGroups, word) >= 1))
				{
					continue;

				}

				if (Array.IndexOf(ThousandsGroups, word) >= 1)
				{
					transferedData.Add(word, tempNumber);
					tempNumber = 0;
					continue;
				}

				if (word.Equals(hundred))
				{
					tempNumber *= numberDic[word];
					continue;
				}

				tempNumber += numberDic[word];
			}

		    if (tempNumber > 0)
		    {
			    transferedData.Add(ThousandsGroups[0], tempNumber);
		    }

			//this will take care of zero
			if (!transferedData.Keys.Any())
			{
				return "0";
			}

			var highestIndex = GetHighestIndex(transferedData);

			for (int i = 0; i <= highestIndex; i++)
			{
				var magName = ThousandsGroups[i];
				if (!transferedData.ContainsKey(magName))
					transferedData.Add(magName, 0);
			}

			var result = ConstructInt(transferedData);

			return result;
		}

	    private string ConstructInt(Dictionary<string, int> transferedData)
	    {
		    var result = "";
		    foreach (var magName in ThousandsGroups.Reverse().ToList())
		    {
			    if (!transferedData.ContainsKey(magName))
				    continue;

			    result += transferedData[magName].ToString("D3");
		    }

		    result = result.Trim().TrimStart('0');
		    return result;
	    }

	    private int GetHighestIndex(Dictionary<string, int> transferedData)
	    {
			foreach (var magName in ThousandsGroups.Reverse().ToList())
			{
				if (transferedData.ContainsKey(magName))
					return Array.IndexOf(ThousandsGroups, magName);
			}

		    throw new NumberTextConverterException("Unknow error.");
	    }


	}
}
