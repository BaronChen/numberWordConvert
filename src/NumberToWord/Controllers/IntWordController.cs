using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using NumberToWord.models;

namespace NumberToWord.Controllers
{
    [Route("api/intword")]
    public class IntWordController : Controller
    {
	    [Route("index")]
	    [HttpGet]
	    public string Index()
	    {
		    return "Welcome!";
	    }

	    [Route("int-to-word")]   
        [HttpPost]
        public WordResult  IntToWord()
        {
			var wordResult = new WordResult();

			wordResult.Result = "lalal";

            return wordResult;
        }

		[Route("word-to-int")]
		[HttpPost]
		public IntResult WordToInt()
		{
			var intResult = new IntResult();

			intResult.Result = 12436;

			return intResult;
		}
	}
}
