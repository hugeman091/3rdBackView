using UnityEngine;
using UnityEngine.UI;

public class Channel_Trigger : MonoBehaviour
{
	public Channel_ScriptableObject _Channel;
	public Color _Color = Color.black;

	public void Do()
	{
		_Channel.RaiseEvent(_Color);
	}
}
