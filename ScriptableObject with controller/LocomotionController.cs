using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class LocomotionController : MonoBehaviour
{
	[SerializeField] private Channel_Controller _channelController;
	[SerializeField] Animator m_Animator;

	private void Awake()
	{
		_channelController.ListenRunAnimationRequest(gameObject.GetHashCode(), RunAnimation, true);
		_channelController.ListenAimingAnimationRequest(gameObject.GetHashCode(), Aiming, true);
		_channelController.ListenFireAnimationRequest(gameObject.GetHashCode(), Fire, true);

	}

	private void OnDisable()
	{
		_channelController.ListenRunAnimationRequest(gameObject.GetHashCode(), RunAnimation, false);
		_channelController.ListenAimingAnimationRequest(gameObject.GetHashCode(), Aiming, false);
		_channelController.ListenFireAnimationRequest(gameObject.GetHashCode(), Fire, false);
	}

	private void Start()
	{
		if (!m_Animator)
			m_Animator = GetComponent<Animator>();
	}

	public void RunAnimation(bool isMoving, float speed)
	{
		m_Animator.SetBool("IsMoving", isMoving);
		m_Animator.SetFloat("VelocityY", speed);
	}

	public void Aiming(bool isAiming)
	{
		m_Animator.SetBool("IsAiming", isAiming);
	}
	public void Fire(bool isFired)
	{
		m_Animator.SetBool("Fire", isFired);
	}

	private void OnAnimatorMove()
	{
		//좌표이동 애니메이션이 있으면 여기서 사용
	}
}