using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RankingServer.Model;
using RankingServer.Redis;

namespace RankingServer.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class ScoreInfoController : ControllerBase
	{
		[HttpGet("TopRankings")] 
		public IEnumerable<ScoreInfo> GetTopRankings() => RedisManager.GetTopRankings();

		[HttpGet("UserRanking")]
		public long GetUserRank(string nickname) => RedisManager.GetUserRank(nickname);

		[HttpPost]
		public IActionResult Post(ScoreInfo scoreInfo)
		{
			RedisManager.Add_score(scoreInfo.nickname, scoreInfo.score);
			return Ok();
		}
	}
}
