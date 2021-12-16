using System;
using UnityEngine;
using UnityEngine.InputSystem;

class AimViewController : MonoBehaviour
{
	[SerializeField] private Channel_Controller _channelController;
	[SerializeField] GameObject m_ViewCamera;
	[SerializeField] GameObject m_AimCamera;

	//Editor InputSetting
	public InputAction fireAction;
	public InputAction AimingAction;

	void OnEnable()
	{
		fireAction.Enable();
		AimingAction.Enable();
	}

	void OnDisable()
	{
		fireAction.Disable();
		AimingAction.Disable();
	}

	private void Update()
	{
		Aiming();
		Fire();
	}

	void Fire()
	{
		if (AimingAction.ReadValue<float>() > 0.5f)
			_channelController.RaiseFireAnimationEvent(gameObject.GetHashCode(), fireAction.triggered);
	}

	void Aiming()
	{
		var aim = AimingAction.ReadValue<float>();
		if (aim > 0.5f && !m_AimCamera.activeInHierarchy)
		{
			m_ViewCamera.SetActive(false);
			m_AimCamera.SetActive(true);
			_channelController.RaiseAimingAnimationEvent(gameObject.GetHashCode(), true);
		}
		else if (aim < 0.5f && !m_ViewCamera.activeInHierarchy)
		{
			m_ViewCamera.SetActive(true);
			m_AimCamera.SetActive(false);
			_channelController.RaiseAimingAnimationEvent(gameObject.GetHashCode(), false);
		}
	}
}