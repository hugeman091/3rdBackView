using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RankingServer.Model
{
	[ApiController]
	[Route("[controller]")]
	public class ScoreInfo
	{
		public string nickname { get; set; }
		public int score { get; set; }
	}
}
