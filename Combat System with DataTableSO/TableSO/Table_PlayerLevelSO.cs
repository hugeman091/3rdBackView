using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PlayerStatusTableData
{
	public int level;
	public StatusTableData table;
}

[Serializable]
public struct StatusTableData
{
	public long attack;
	public long defence;
	public long hp;
	public long magic;
	public long damage;
	[Space(20)]
	public short darkResist;
	public short fireResist;
	public short lightResist;
	public short waterResist;
	public short woodResist;
}

[CreateAssetMenu(fileName = "Table_PlayerLevelSO",menuName = "table/Manager_PlayerStatus")]
public class Table_PlayerLevelSO : SingleTonSO<Table_PlayerLevelSO>
{
#if UNITY_EDITOR
	[TextArea]
	[Tooltip("Doesn't do anything. Just comments shown in inspector")]
	public string Comments = "Comments";
#endif

	public PlayerStatusTableData[] _Table;

	public StatusTableData Find(int level)
	{
		var data = Array.Find(_Table, (e) => e.level == level);
		return data.table;
	}
}
