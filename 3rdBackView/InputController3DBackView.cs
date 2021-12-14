using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputController3DBackView : MonoBehaviour
{
	[SerializeField] float m_RotationSpeed = 3;
	[SerializeField] int m_VirticalAngleThresholdMax = 340;
	[SerializeField] int m_VirticalAngleThresholdMin = 40;
	[SerializeField] GameObject m_FollowingTarget;

	[SerializeField] private MoveController m_Mover;

	#region Input
	private Vector2 move;
	private Vector2 look;
	private float canRotate;

	public void OnMove(InputValue value) { move = value.Get<Vector2>(); }
	public void OnLook(InputValue value) { look = value.Get<Vector2>(); }
	public void OnCanRotate(InputValue value) { canRotate = value.Get<float>(); }
	#endregion

	void Start()
	{
		if (!m_Mover)
			m_Mover = GetComponent<MoveController>();
	}

	private void FixedUpdate()
	{
		MoveInput();
		if (canRotate > 0)
			RotateView();
	}

	void MoveInput()
	{
		var dir = (transform.forward * move.y).normalized;
		m_Mover.MoveTo(dir, move.y != 0);
	}

	void RotateView()
	{
		//Input에 따른 FollowObj Rotate
		transform.rotation *= Quaternion.AngleAxis(look.x * m_RotationSpeed * Time.deltaTime, Vector3.up);
		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);


		m_FollowingTarget.transform.rotation *= Quaternion.AngleAxis(-look.y * m_RotationSpeed * Time.deltaTime, Vector3.right);
		//angle threshold
		var angles = m_FollowingTarget.transform.localEulerAngles;
		angles.z = 0; // roll lock
		var angle = m_FollowingTarget.transform.localEulerAngles.x;
		if (angle > 180 && angle < m_VirticalAngleThresholdMax) { angles.x = m_VirticalAngleThresholdMax; }
		if (angle < 180 && angle > m_VirticalAngleThresholdMin) { angles.x = m_VirticalAngleThresholdMin; }
		m_FollowingTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
	}

}