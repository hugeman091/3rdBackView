using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputController3DBackView : MonoBehaviour
{
	[SerializeField] private Channel_Controller _channelController;
	[SerializeField] GameObject _followingTarget;
	[SerializeField] float _rotateSpeed = 3;
	[SerializeField] int _verticalAngleThresholdMax = 340;
	[SerializeField] int _verticalAngleThresholdMin = 40;

	#region Input
	private Vector2 move;
	private Vector2 look;
	private float canRotate;

	public void OnMove(InputValue value) { move = value.Get<Vector2>(); }
	public void OnLook(InputValue value) { look = value.Get<Vector2>(); }
	public void OnCanRotate(InputValue value) { canRotate = value.Get<float>(); }

	void OnEnable()
	{

	}

	void OnDisable()
	{

	}
	#endregion


	private void FixedUpdate()
	{
		MoveInput();
		if (canRotate > 0)
			RotateView();
	}

	void MoveInput()
	{
		var dir = (transform.forward * move.y).normalized;
		_channelController.RaiseMoveEvent(gameObject.GetHashCode(), dir, move.y != 0);
	}

	void RotateView()
	{
		//Input에 따른 FollowObj Rotate
		transform.rotation *= Quaternion.AngleAxis(look.x * _rotateSpeed * Time.deltaTime, Vector3.up);
		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);


		_followingTarget.transform.rotation *= Quaternion.AngleAxis(-look.y * _rotateSpeed * Time.deltaTime, Vector3.right);
		//angle threshold
		var angles = _followingTarget.transform.localEulerAngles;
		angles.z = 0; // roll lock
		var angle = _followingTarget.transform.localEulerAngles.x;
		if (angle > 180 && angle < _verticalAngleThresholdMax) { angles.x = _verticalAngleThresholdMax; }
		if (angle < 180 && angle > _verticalAngleThresholdMin) { angles.x = _verticalAngleThresholdMin; }
		_followingTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
	}
}