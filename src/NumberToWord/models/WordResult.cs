﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NumberToWord.models
{
    public class WordResult : BaseResult
    {
		[JsonProperty("result")]
		public string Result { get; set; }

    }
}
