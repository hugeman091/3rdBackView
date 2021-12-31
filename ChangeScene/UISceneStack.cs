using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class UISceneStack : ScriptableObject
{
	public Stack<string> _UIStack = new Stack<string>();

	public void MemorizeCurrentScene(string scene)
	{
		_UIStack.Push(scene);
	}

	public void GotoPriviousScene()
	{
		if (_UIStack.Count > 0)
		{
			var priviousScene = _UIStack.Pop();
			Debug.Log(priviousScene);
			UnityEngine.SceneManagement.SceneManager.LoadScene(priviousScene);
		}
	}
	public void SceneStackUndo()
	{
		Debug.Log("StackUndo");
		var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
		_UIStack.Push(scene.name);
	}
}
