using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;
using System.Diagnostics;
using AccountServer.Model;


namespace AccountServer.DB
{
	public class SQLManager
	{
		public static SqlConnection sqlcon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

		public static void ConnectDBTest()
		{
			try
			{
				SQLManager.sqlcon.Open();
				string strSql_Select = "select top (5) * from dbo.Account";


				SqlCommand cmd_Select = new SqlCommand(strSql_Select, SQLManager.sqlcon);



				SqlDataReader rd = cmd_Select.ExecuteReader();

				while (rd.Read())
				{
					var id = rd["AccountDbId"];
					var name = rd["AccountName"];
					var password = rd["Password"];
					Console.WriteLine($"{id} {name} {password}");
				}

				rd.Close();

				sqlcon.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.Source);
				Console.WriteLine(e.StackTrace);
			}
			finally
			{
				if (sqlcon != null)
					sqlcon.Close();
			}
		}
	}
}
