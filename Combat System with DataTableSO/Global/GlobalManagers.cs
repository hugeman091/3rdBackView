using UnityEngine;

public class GlobalManagers : MonoBehaviour
{
	private static GlobalManagers _instance = new GlobalManagers();
	public static GlobalManagers Instance => _instance;

	private Manager_PlayerStatus _playerStat = new Manager_PlayerStatus();
	private Manager_GameObjects _worldObjects = new Manager_GameObjects();

	public static Manager_PlayerStatus PlayerStat = Instance._playerStat;
	public static Manager_GameObjects WorldObjects = Instance._worldObjects;

	void Start()
	{
		WorldObjects.MonsterSetting();
	}



	void Update()
	{
		WorldObjects.Update();
	}
}
