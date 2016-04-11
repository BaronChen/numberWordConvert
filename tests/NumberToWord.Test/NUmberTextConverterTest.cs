using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NumberToWord.Core;
using Xunit;

namespace NumberToWord.Test
{
    public class NumberTextConverterTest
    {

		private NumberTextConverter Converter;
		private List<string> Words;
		private List<string> Numbers;
		public NumberTextConverterTest()
		{
			this.Converter = new NumberTextConverter();

			Words = new List<string>()
			{
				"zero",
				"one",
				"five",
				"eleven",
				"twelve",
				"fifteen",
				"twenty one",
				"twenty five",
				"fifty two",
				"one hundred and sixty six",
				"three hundred",
				"five hundred and fifteen",
				"one thousand",
				"one thousand and one hundred",
				"one thousand and two hundred and thirty four",
				"nine thousand and nine hundred and ninety nine",
				"one hundred thousand and one hundred",
				"two hundred and ten thousand and one hundred and nineteen",
				"one million",
				"one million and ten",
				"four million, nine hundred and ninety nine thousand and three hundred and twenty three",
				"six hundred and seventy eight million, one hundred and ten thousand and seventy",
				"one billion",
				"one billion, one million, one thousand and one hundred",
				"twenty billion, six hundred and seventy eight million, one hundred and ten thousand and seventy",
				"one hundred and ninety nine billion, six hundred and seventy eight million, one hundred and ten thousand and seventy",
				"two trillion, thirty four billion",
				"two hundred and thirty four trillion, one hundred and ninety nine billion, six hundred and seventy eight million, one hundred and ten thousand and seventy",
				"nine hundred and ninety nine quadrillion, two hundred and thirty four trillion, one hundred and ninety nine billion, six hundred and seventy eight million, one hundred and ten thousand and seventy",
				"nine quintillion, two hundred and twenty three quadrillion, three hundred and seventy two trillion, thirty six billion, eight hundred and fifty four million, seven hundred and seventy five thousand and eight hundred and seven",
				"nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand and nine hundred and ninety nine",
				"nine hundred and ninety nine septillion, nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand and nine hundred and ninety nine",
				"nine hundred and ninety nine octillion, nine hundred and ninety nine septillion, nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand and nine hundred and ninety nine",
				"nine hundred and ninety nine nonillion, nine hundred and ninety nine octillion, nine hundred and ninety nine septillion, nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand and nine hundred and ninety nine",
				"nine hundred and ninety nine decillion, nine hundred and ninety nine nonillion, nine hundred and ninety nine octillion, nine hundred and ninety nine septillion, nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand and nine hundred and ninety nine"
			};

			Numbers = new List<string>()
			{
				"0",
				"1",
				"5",
				"11",
				"12",
				"15",
				"21",
				"25",
				"52",
				"166",
				"300",
				"515",
				"1000",
				"1100",
				"1234",
				"9999",
				"100100",
				"210119",
				"1000000",
				"1000010",
				"4999323",
				"678110070",
				"1000000000",
				"1001001100",
				"20678110070",
				"199678110070",
				"2034000000000",
				"234199678110070",
				"999234199678110070",
				"9223372036854775807",
				"999999999999999999999999",
				"999999999999999999999999999",
				"999999999999999999999999999999",
				"999999999999999999999999999999999",
				"999999999999999999999999999999999999",

			};
		}

		[Fact]
		public void NumberToWordFact()
		{
			var inputs = Numbers;
			var expectedResults = Words;
			foreach (var input in inputs)
			{
				var index = inputs.IndexOf(input);
				//if (input == "1000")
				//{
				//	Debugger.Launch();
				//}
				Assert.Equal(expectedResults[index], Converter.IntegerToWritten(input, false));

			}
		}


		[Fact]
		public void InvalidNegativeNumber()
		{

			Exception ex = Assert.Throws<NumberTextConverterException>(() => Converter.IntegerToWritten("-12323", false));

			Assert.Equal("Invalid number", ex.Message);

		}

		[Fact]
		public void NumberTooBig()
		{

			Exception ex = Assert.Throws<NumberTextConverterException>(() => Converter.IntegerToWritten("99999999999999999999999999999999999999", false));

			Assert.Equal("Number too big", ex.Message);

		}

		[Fact]
		public void WordToNumber()
		{
			var inputs = Words;
			var expectedResults = Numbers;

			foreach (var input in inputs)
			{
				var index = inputs.IndexOf(input);
			
				Assert.Equal(expectedResults[index], Converter.WrittenToInteger(input));

			}

		}



	}
}
