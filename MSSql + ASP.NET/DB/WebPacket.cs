﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Client -> Server
public class CreateAccountPacketReq
{
	public string AccountName { get; set; }
	public string Password { get; set; }
}

//Server Respond -> Client
public class CreateAccountPacketRes
{
	public bool CreateOk { get; set; }
}

public class LoginAccountPacketReq
{
	public string AccountName { get; set; }
	public string Password { get; set; }
}

public class ServerInfo
{
	public string Name { get; set; }
	public string IpAddress { get; set; }
	public int Port { get; set; }
	public int BusyScore { get; set; }
}

public class LoginAccountPacketRes
{
	public bool LoginOk { get; set; }
	public int AccountId { get; set; }
	public int Token { get; set; }
	public List<ServerInfo> ServerList { get; set; } = new List<ServerInfo>();
}