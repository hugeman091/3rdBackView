using UnityEngine;

public class SingleTonSO<T> : ScriptableObject where T : ScriptableObject
{
	private static T _instance;
	public static T GetInstance(string path)
	{
		if (_instance == null)
			_instance = Resources.Load(path + typeof(T).Name) as T;
		return _instance;
	}
}