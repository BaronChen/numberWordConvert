using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberToWord.Core
{
	public class NumberTextConverter
	{

		static string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
		static string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
		static string[] tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
		static string[] thousandsGroups = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };
		private static string hundred = "hundred";
		private static string zero = "zero";

		private Dictionary<string, long> numberDic;


		public NumberTextConverter()
		{
			numberDic = new Dictionary<string, long>();
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
			numberDic.Add("thousand", 1000);
			numberDic.Add("million", 1000000);
			numberDic.Add("billion", 1000000000);
			numberDic.Add("trillion", 1000000000000);
			numberDic.Add("quadrillion", 1000000000000000);
			numberDic.Add("quintillion", 1000000000000000000);
		}

		private string FriendlyInteger(long n, string leftDigits, int thousands, bool isUS)
		{
			if (n == 0)
			{
				return leftDigits;
			}
			string friendlyInt = leftDigits;
			if (friendlyInt.Length > 0)
			{
				friendlyInt += " ";
			}

			if (n < 100 && n > 0)
			{
				string[] array = leftDigits.Split(' ');
				if ((array[array.Count() - 1].Equals(hundred)) && !isUS)
				{
					friendlyInt += "and ";
				}
			}
			if (n < 10)
			{
				friendlyInt += ones[n];
			}
			else if (n < 20)
			{
				friendlyInt += teens[n - 10];
			}
			else if (n < 100)
			{
				friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0, isUS);
			}
			else if (n < 1000)
			{
				string[] a = leftDigits.Split(' ');
				var shouldNotAddAnd = isUS || string.IsNullOrWhiteSpace(friendlyInt) || Array.IndexOf(thousandsGroups, a[a.Count() - 1]) >= 2;
                friendlyInt += (shouldNotAddAnd ? "":"and ") + FriendlyInteger(n % 100, (ones[n / 100] + " " + hundred), 0, isUS);
			}
			else
			{
				var nextThousands = thousands + 1;
				if (nextThousands >= thousandsGroups.Length)
				{
					nextThousands = 1;
				}
                friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", nextThousands, isUS), 0, isUS);
			}

			string[] s = friendlyInt.Split(' ');
			if (Array.IndexOf(thousandsGroups, s[s.Count() - 1]) >= 2)
			{
				return friendlyInt;
			}


			return friendlyInt + (string.IsNullOrWhiteSpace(thousandsGroups[thousands])? "" : " ") + thousandsGroups[thousands];
		}

		private string getWritten(long n, bool isUS)
		{
			var tens = n % 100;
			var others = (n / 100) * 100;

			var tensStr = FriendlyInteger(tens, "", 0, isUS);
			var othersStr = FriendlyInteger(others, "", 0, isUS);

			var result = "";
			if (!string.IsNullOrWhiteSpace(tensStr) && !string.IsNullOrWhiteSpace(othersStr))
			{
				if (isUS)
				{
					result = othersStr + " " + tensStr;
				}
				else
				{
				  result = othersStr + " and " + tensStr;

				}
			}
			else if (!string.IsNullOrWhiteSpace(othersStr))
			{
				result = othersStr;
			}else if (!string.IsNullOrWhiteSpace(tensStr))
			{
				result = tensStr;
			}

			return result.ToLower().Trim();
		}

		public string IntegerToWritten(long n, bool isUS = false)
		{
			if (n == 0)
			{
				return zero;
			}else if (n < 0)
			{
				throw new Exception("Number need to be positive.");
			}
	
			return getWritten(n, isUS);
		}

		public long WrittenToInteger(string numberText)
		{
			numberText = numberText.Trim();
			numberText = numberText.ToLower();
			List<string> words = numberText.Split(' ').ToList();
			long number = 0;
			long tempNumber = 0;
			for (var i = 0;  i < words.Count; i++)
			{
				var word = words[i];
				if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
				{
					continue;
				}
				if (!numberDic.ContainsKey(word))
				{
					continue;

				}

				if (Array.IndexOf(thousandsGroups, word) >= 1)
				{
					tempNumber *= numberDic[word];
					number += tempNumber;
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
			if (tempNumber != 0)
			{
				number += tempNumber;
			}
			return number;
		}



	}
}
