using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Channel_Listener : MonoBehaviour
{
	public Channel_ScriptableObject _Channel;
	public Image _Image;

	void Awake()
	{
		_Channel.OnRequest += (color) => { _Image.color = color; };
	}
}
