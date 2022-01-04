using FlatBuffers;
using UnityEngine;
using UnityEngine.Android;

public class GlobalTables : MonoBehaviour
{
	private const string defaultPath = "SO/Table/";
	public static Table_StageSO StageSo => Table_StageSO.GetInstance(defaultPath);
	public static Table_MonsterSO MonsterSo => Table_MonsterSO.GetInstance(defaultPath);
	public static Table_ExperienceSO Exp => Table_ExperienceSO.GetInstance(defaultPath);
	public static Table_PlayerLevelSO LevelSo => Table_PlayerLevelSO.GetInstance(defaultPath);
}


