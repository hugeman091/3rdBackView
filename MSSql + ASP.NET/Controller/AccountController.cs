using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using AccountServer.DB;
namespace AccountServer.Controller
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{

		#region efcore
		//private AppDbContext _context;
		//private SharedDbContext _shared;

		//public AccountController(AppDbContext context, SharedDbContext shared)
		//{
		//	_context = context;
		//	_shared = shared;
		//}
		//[HttpPost]
		//[Route("create")]
		//public CreateAccountPacketRes CreateAccount([FromBody] CreateAccountPacketReq req)
		//{
		//	var res = new CreateAccountPacketRes();

		//	var account = _context.Accounts
		//		.AsNoTracking()
		//		.Where(a => a.AccountName == req.AccountName)
		//		.FirstOrDefault();

		//	if (account == null)
		//	{
		//		_context.Accounts.Add(new AccountDb()
		//		{
		//			AccountName = req.AccountName,
		//			Password = req.Password
		//		});

		//		bool success = _context.SaveChangeEx();
		//		res.CreateOk = success;
		//	}
		//	else
		//	{
		//		res.CreateOk = false;
		//	}

		//	return res;
		//}

		//[HttpPost]
		//[Route("login")]
		//public LoginAccountPacketRes LoginAccount([FromBody] LoginAccountPacketReq req)
		//{
		//	var res = new LoginAccountPacketRes();
		//	var account = _context.Accounts
		//		.AsNoTracking()
		//		.Where(a => a.AccountName == req.AccountName && a.Password == req.Password)
		//		.FirstOrDefault();

		//	if (account == null)
		//	{
		//		res.LoginOk = false;
		//	}
		//	else
		//	{
		//		res.LoginOk = true;

		//		//토큰 발급
		//		DateTime expired = DateTime.UtcNow;
		//		expired.AddSeconds(600);

		//		TokenDB tokenDb = _shared.Tokens.Where(t => t.AccountDBID == account.AccountDbId).FirstOrDefault();
		//		if (tokenDb  != null)
		//		{
		//			tokenDb .Token = new Random().Next(Int32.MinValue, Int32.MaxValue);
		//			tokenDb .Expired = expired;
		//			_shared.SaveChangeEx();
		//		}
		//		else
		//		{
		//			tokenDb = new TokenDB()
		//			{
		//				AccountDBID = account.AccountDbId,
		//				Token = new Random().Next(Int32.MinValue, Int32.MaxValue),
		//				Expired = expired
		//			};
		//			_shared.Add(tokenDb);
		//			_shared.SaveChangeEx();
		//		}

		//		res.AccountId = account.AccountDbId;
		//		res.Token = tokenDb.Token;
		//		res.ServerList = new List<ServerInfo>();

		//		foreach (var db in _shared.Servers)
		//		{
		//			res.ServerList.Add(new ServerInfo()
		//			{
		//				Name = db.Name,
		//				IpAddress = db.IpAddress,
		//				Port = db.Port,
		//				BusyScore = db.BusyScore
		//			});
		//		}

		//		//res.ServerList = new List<ServerInfo>()
		//		//{
		//		//	new ServerInfo() { Name = "게임서버1", IpAddress = "127.0.0.1", BusyScore = 0 },
		//		//	new ServerInfo() { Name = "게임서버2", IpAddress = "127.0.0.1", BusyScore = 3 }
		//		//};
		//	}

		//	return res;
		//}
		#endregion

		[HttpPost("mssqlconnectTest")]
		public void CreateAccount() => SQLManager.ConnectDBTest();
	}
}
