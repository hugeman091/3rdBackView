using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Channel", menuName = "Channel/EventChannel")]
public class Channel_ScriptableObject : Scriptableobject
{
	public UnityAction<Color> OnRequest;

	public void RaiseEvent(Color color)
	{
		if (OnRequest == null)
		{
			Debug.LogWarning($"No Listening Objects");
		}

		OnRequest?.Invoke(color);
	}
}
 