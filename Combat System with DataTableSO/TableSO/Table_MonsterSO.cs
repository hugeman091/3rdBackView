using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MonsterTableData
{
	public int temlateid;
	public ulong hp;
	public ulong damage;
	public ulong exp;
	public string path;
	public GameObject prefab;
	//item drop table
}

[CreateAssetMenu(fileName = "Table_MonsterSO", menuName = "table/MonsterSo")]
public class Table_MonsterSO : SingleTonSO<Table_MonsterSO>
{

#if UNITY_EDITOR
	[TextArea]
	[Tooltip("Doesn't do anything. Just comments shown in inspector")]
	public string Comments = "Comments";
#endif

	[Serializable] public class Entry : GenericDictionaryItem<int, MonsterTableData> {}
	[Serializable] public class MonsterTableDictionary : GenericDictionary<int, MonsterTableData, Entry>{}

	public MonsterTableDictionary _MonsterTable;

	public MonsterTableData? Find(int templateId)
	{
		if (_MonsterTable.ContainsKey(templateId))
			return _MonsterTable[templateId];

		return null;
	}

	public void TryGetValue(int templateId,out MonsterTableData table)
	{
		if (_MonsterTable.ContainsKey(templateId))
			table = _MonsterTable[templateId];

		table = new MonsterTableData();
	}

}