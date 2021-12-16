using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor;

[CreateAssetMenu(fileName = "Channel", menuName = "Channel/Controller")]
public class Channel_Controller : Scriptableobject
{
	Dictionary<int, UnityAction<Vector3, bool>>
		OnMoveRequest = new Dictionary<int, UnityAction<Vector3, bool>>();

	Dictionary<int, UnityAction<Vector3>>
		OnPointMoveRequest = new Dictionary<int, UnityAction<Vector3>>();

	Dictionary<int, UnityAction<bool, float>>
		OnRunAnimationRequest = new Dictionary<int, UnityAction<bool, float>>();

	Dictionary<int, UnityAction<bool>>
		OnFireAnimationRequest = new Dictionary<int, UnityAction<bool>>();

	Dictionary<int, UnityAction<bool>>
		OnAimingAnimationRequest = new Dictionary<int, UnityAction<bool>>();

	public void ListenMoveRequest(int hash, UnityAction<Vector3, bool> action, bool listen)
	{
		if (listen)
			OnMoveRequest.Add(hash, action);
		else
			OnMoveRequest.Remove(hash);
	}
	public void ListenPointMoveRequest(int hash, UnityAction<Vector3> action, bool listen)
	{
		if (listen)
			OnPointMoveRequest.Add(hash, action);
		else
			OnPointMoveRequest.Remove(hash);
	}
	public void ListenRunAnimationRequest(int hash, UnityAction<bool, float> action, bool listen)
	{
		if (listen)
			OnRunAnimationRequest.Add(hash, action);
		else
			OnRunAnimationRequest.Remove(hash);
	}
	public void ListenFireAnimationRequest(int hash, UnityAction<bool> action, bool listen)
	{
		if (listen)
			OnFireAnimationRequest.Add(hash, action);
		else
			OnFireAnimationRequest.Remove(hash);
	}
	public void ListenAimingAnimationRequest(int hash, UnityAction<bool> action, bool listen)
	{
		if (listen)
			OnAimingAnimationRequest.Add(hash, action);
		else
			OnAimingAnimationRequest.Remove(hash);
	}


	public void RaiseMoveEvent(int hash, Vector3 dir, bool moved) => OnMoveRequest[hash].Invoke(dir, moved);
	public void RaisePointMoveEvent(int hash, Vector3 dir) => OnPointMoveRequest[hash].Invoke(dir);
	public void RaiseRunAnimationEvent(int hash, bool isMoving, float speed) =>
		OnRunAnimationRequest[hash].Invoke(isMoving, speed);
	public void RaiseFireAnimationEvent(int hash, bool triggered) => OnFireAnimationRequest[hash].Invoke(triggered);
	public void RaiseAimingAnimationEvent(int hash, bool triggered) => OnAimingAnimationRequest[hash].Invoke(triggered);

#if UNITY_EDITOR
	[ContextMenu("ClearCache")]
	public void ClearCache()
	{
		OnMoveRequest.Clear();
		OnPointMoveRequest.Clear();
		OnRunAnimationRequest.Clear();

		//유니티 애셋을 런타임에 변경할 경우 실제로 저장되도록 (container, newscriptableObject 모두 적용)
		EditorUtility.SetDirty(this);
	}
#endif
}
