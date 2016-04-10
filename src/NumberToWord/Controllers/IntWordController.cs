using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using NumberToWord.Core;
using NumberToWord.models;

namespace NumberToWord.Controllers
{
    [Route("api/intword")]
    public class IntWordController : Controller
    {

	    private readonly NumberTextConverter NumberTextConverter;

	    public IntWordController(NumberTextConverter numberTextConverter)
	    {
		    this.NumberTextConverter = numberTextConverter;
	    }

	    [Route("index")]
	    [HttpGet]
	    public string Index()
	    {
		    return "Welcome!";
	    }

	    [Route("number-to-word")]   
        [HttpPost]
        public WordResult IntToWord([FromBody]IntInput numberInput)
        {
			var wordResult = new WordResult();

		    if (numberInput == null)
		    {
				wordResult.Message = "Please provide a valid number that larger than 0.";
				Response.StatusCode = 400;
				return wordResult;
			}

		    if (numberInput.Number < 0)
		    {
				wordResult.Message = "Number need to be larger than 0";
				Response.StatusCode = 400;
				return wordResult;
			}

		    try
		    {
			    wordResult.Result = NumberTextConverter.IntegerToWritten(numberInput.Number);
		    }
		    catch
		    {
			    wordResult.Message = "Internal Server Error";
			    Response.StatusCode = 500;
				return wordResult;
		    }

			return wordResult;
        }

		[Route("word-to-number")]
		[HttpPost]
		public IntResult WordToInt([FromBody]WordInput wordInput)
		{
			var intResult = new IntResult();

			try
			{
				intResult.Result = NumberTextConverter.WrittenToInteger(wordInput.Word);
			}
			catch
			{
				intResult.Message = "Internal Server Error";
				Response.StatusCode = 500;
				return intResult;
			}

			return intResult;
		}

	}
}
