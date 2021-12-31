using UnityEngine;

[CreateAssetMenu]
public class ChangeSceneBase : ScriptableObject
{
	[SerializeField] protected string _SceneMoveTo;

	public void GotoScene()
	{
		Debug.Log($"GoTo{_SceneMoveTo}");
		UnityEngine.SceneManagement.SceneManager.LoadScene(_SceneMoveTo);
	}
}
