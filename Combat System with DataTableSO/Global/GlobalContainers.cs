using UnityEngine;

public class GlobalContainers :MonoBehaviour
{
	private const string defaultPath = "SO/Container/";
	public static Container_ObjectPoolSO Pool => Container_ObjectPoolSO.GetInstance(defaultPath);
	public static Container_ResourcesSO Resource => Container_ResourcesSO.GetInstance(defaultPath);
}
