using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class LocomotionController : MonoBehaviour
{
	[SerializeField] Animator m_Animator;
	[SerializeField] MoveController m_Mover;
	[SerializeField] AimViewController m_AimView;

	public InputAction fireAction;
	private void Start()
	{
		if (!m_Animator)
			m_Animator = GetComponent<Animator>();
		if (!m_Mover)
			m_Mover = GetComponent<MoveController>();
		if (!m_AimView)
			m_AimView = GetComponent<AimViewController>();
	}

	void OnEnable()
	{
		fireAction.Enable();
	}

	void OnDisable()
	{
		fireAction.Disable();
	}

	private void Update()
	{
		RunAnimation();
		AttackAnimation();
	}

	void RunAnimation()
	{
		if (!m_Mover)
			return;

		m_Animator.SetBool("IsMoving", m_Mover.m_IsMoving);
		m_Animator.SetFloat("VelocityY", m_Mover.m_MoveSpeed);
	}

	void AttackAnimation()
	{
		if (!m_AimView)
			return;

		m_Animator.SetBool("IsAiming", m_AimView.m_IsAiming);
		m_Animator.SetBool("Fire", fireAction.triggered);
	}
	private void OnAnimatorMove()
	{
		//좌표이동 애니메이션이 있으면 여기서 사용
	}
}