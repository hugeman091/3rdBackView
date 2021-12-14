using UnityEngine;
using UnityEngine.InputSystem;

class AimViewController : MonoBehaviour
{
	[SerializeField] GameObject m_MainCamera;
	[SerializeField] GameObject m_aimCamera;

	public bool m_IsAiming;

	private float aim;
	private float fire;

	public void OnFire(InputValue value) { fire = value.Get<float>(); }
	public void OnAim(InputValue value) { aim = value.Get<float>(); }

	private void LateUpdate()
	{
		if (aim > 0.5f && !m_aimCamera.activeInHierarchy)
		{
			m_MainCamera.SetActive(false);
			m_aimCamera.SetActive(true);
			m_IsAiming = true;
		}
		else if (aim < 0.5f && !m_MainCamera.activeInHierarchy)
		{
			m_MainCamera.SetActive(true);
			m_aimCamera.SetActive(false);
			m_IsAiming = false;
		}
	}
}