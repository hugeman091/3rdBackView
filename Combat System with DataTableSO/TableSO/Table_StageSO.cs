using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StageTableData
{
	public int stage;
	public MonstersListData[] spawnMonsters;
}

[Serializable]
public struct MonstersListData
{
	public int templateId;
	public int count;
}

[CreateAssetMenu(fileName = "Table_StageSO", menuName = "table/StageSo")]
public class Table_StageSO : SingleTonSO<Table_StageSO>
{

#if UNITY_EDITOR
	[TextArea] [Tooltip("Doesn't do anything. Just comments shown in inspector")]
	public string Comments = "Comments";
#endif
	public StageTableData[] _Table;

	public StageTableData Find(int stage) => Array.Find(_Table, (e) => stage == e.stage);
}