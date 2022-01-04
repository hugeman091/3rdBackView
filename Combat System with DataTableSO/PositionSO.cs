using UnityEngine;

[CreateAssetMenu(menuName = "Transform/PositionSO")]
public class PositionSO : ScriptableObject
{
	public Vector3 Position;
	public Vector3 Rotation;
	public Vector3 Scale;
}
