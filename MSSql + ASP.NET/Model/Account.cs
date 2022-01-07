using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountServer.Model
{
	[ApiController]
	[Route("[controller]")]
	public class Account
	{
		public int AccountDbId { get; set; }
		public string AccountName { get; set; }
		public string Password { get; set; }
	}
}
