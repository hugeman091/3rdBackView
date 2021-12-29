using System;
using UnityEngine;

[CreateAssetMenu]
public class SharedIntegerVariable : ScriptableObject
{
#if UNITY_EDITOR
	[TextArea]
	[Tooltip("Doesn't do anything. Just comments shown in inspector")]
	public string Comments = "Comments";
#endif
	public int _Value;

	public void SetValue(int value) => _Value = value;
	public void SetValue(SharedIntegerVariable value) => _Value = value._Value;

	public void ApplyChange(int amount) => _Value += amount;
	public void ApplyChange(SharedIntegerVariable amount) => _Value += amount._Value;
}
