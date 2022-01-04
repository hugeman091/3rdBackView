using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct ExpTableData
{
	public ulong minExp;
	public ulong maxExp;
}

[CreateAssetMenu(fileName = "Table_Experience",menuName = "table/Exp")]
public class Table_ExperienceSO : SingleTonSO<Table_ExperienceSO>
{
	[Serializable] public class Entry : GenericDictionaryItem<int, ExpTableData>{}
	[Serializable] public class ExpInfoDictionary : GenericDictionary<int, ExpTableData, Entry>{}

	public ExpInfoDictionary _ExpTables;

	public bool IsValidate()
	{
		ulong minExp = 0;
		foreach (var e in _ExpTables)
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

	public short GetLevel(ulong curExp)
	{
		foreach (var e in _ExpTables)
		{
			if (curExp >= e.Value.minExp && curExp <= e.Value.maxExp)
				return (short)e.Key;
		}

		return 0;
	}

	public ExpTableData? GetExpTable(int level)
	{
		if (_ExpTables.ContainsKey(level))
			return _ExpTables[level];

		return null;
	}
}
