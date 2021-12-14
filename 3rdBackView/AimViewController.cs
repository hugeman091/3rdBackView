using System;
using UnityEngine;
using UnityEngine.InputSystem;

class AimViewController : MonoBehaviour
{
	[SerializeField] GameObject m_ViewCamera;
	[SerializeField] GameObject m_AimCamera;
	[SerializeField] LocomotionController m_Locomotion;

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

	void Start()
	{
		if (!m_Locomotion)
			m_Locomotion = GetComponent<LocomotionController>();
	}

	private void Update()
	{
		Aiming();
		Fire();
	}

	void Fire()
	{
		if (AimingAction.ReadValue<float>() > 0.5f)
			m_Locomotion.Fire(fireAction.triggered);
	}

	void Aiming()
	{
		var aim = AimingAction.ReadValue<float>();
		if (aim > 0.5f && !m_AimCamera.activeInHierarchy)
		{
			m_ViewCamera.SetActive(false);
			m_AimCamera.SetActive(true);
			m_Locomotion.Aiming(true);
		}
		else if (aim < 0.5f && !m_ViewCamera.activeInHierarchy)
		{
			m_ViewCamera.SetActive(true);
			m_AimCamera.SetActive(false);
			m_Locomotion.Aiming(false);
		}
	}
}