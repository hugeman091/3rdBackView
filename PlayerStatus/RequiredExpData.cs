using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct RequiredEXP
{
	public ulong minExp;
	public ulong maxExp;
}

[CreateAssetMenu(menuName = "Info/RequiredEXP")]
public class RequiredExpData : ScriptableObject
{
	[Serializable]
	public class Entry : GenericDictionaryItem<int, RequiredEXP>
	{
	}

	[Serializable]
	public class ExpInfoDictionary : GenericDictionary<int, RequiredEXP, Entry>
	{

	}

	public ExpInfoDictionary RequiredEXPDatas;

	public bool IsValidate()
	{
		ulong minExp = 0;
		foreach (var e in RequiredEXPDatas)
		{
			if (e.Value.minExp != 0 && e.Value.minExp <= minExp)
			{
				Debug.LogError($"Invalid Data {e.Key}");
				return false;
			}

			minExp = e.Value.maxExp;
		}

		return true;
	}

	public int GetLevel(ulong curExp)
	{
		foreach (var e in RequiredEXPDatas)
		{
			if (curExp >= e.Value.minExp && curExp <= e.Value.maxExp)
				return e.Key;
		}

		return 0;
	}

	public RequiredEXP? GetRequiredExp(int level)
	{
		if (RequiredEXPDatas.ContainsKey(level))
			return RequiredEXPDatas[level];

		return null;
	}
}
