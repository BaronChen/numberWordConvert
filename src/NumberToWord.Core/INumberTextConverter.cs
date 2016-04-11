using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberToWord.Core
{
    public interface INumberTextConverter
    {
		string IntegerToWritten(string n, bool isUS = false);
	    string WrittenToInteger(string numberText);
    }
}
