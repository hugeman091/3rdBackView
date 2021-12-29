using UnityEditor;
using UnityEngine;

public class MyPlayerHealthBarUI : MonoBehaviour
{
	[SerializeField] private GameObject _healthbar;
	[SerializeField] private SharedIntegerVariable _SharedHP;
	[SerializeField] private SharedIntegerVariable _SharedMaxHP;

	public void ScaleSharedHealth()
	{
		var ratio = (float)_SharedHP._Value / _SharedMaxHP._Value;
		ratio = Mathf.Clamp(ratio, 0, 1);
		_healthbar.transform.localScale = new Vector3(ratio, 1, 1);
	}
}
