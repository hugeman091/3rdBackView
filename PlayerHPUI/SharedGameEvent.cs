using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class SharedGameEvent : ScriptableObject
{
	/// <summary>
	/// The list of listeners that this event will notify if it is raised.
	/// </summary>
	private readonly List<SharedGameEventListener> eventListeners =
		new List<SharedGameEventListener>();

	public void Raise()
	{
		for (int i = eventListeners.Count - 1; i >= 0; i--)
			eventListeners[i].OnEventRaised();
	}

	public void RegisterListener(SharedGameEventListener listener)
	{
		if (!eventListeners.Contains(listener))
			eventListeners.Add(listener);
	}

	public void UnregisterListener(SharedGameEventListener listener)
	{
		if (eventListeners.Contains(listener))
			eventListeners.Remove(listener);
	}
}
