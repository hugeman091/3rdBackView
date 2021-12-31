using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GotoPreviousScene : ScriptableObject
{
	public UISceneStack _SceneHistory;
	public void GotoPriviousScene()
	{
		_SceneHistory.GotoPriviousScene();
	}

}
