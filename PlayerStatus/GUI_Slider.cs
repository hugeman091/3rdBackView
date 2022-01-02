using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class  GUI_Slider : MonoBehaviour
{
	[SerializeField] private Slider _slider;
	[SerializeField] private Image _fill;
	[SerializeField] private ColorVariableSO _color;

	void Start () => _fill.color = _color._Value;
	public void ChangeScaler(float value) => _slider.value = value;
	public void ChangeColor(Color value) => _fill.color = value;
	public void ChangeColor(ColorVariableSO value)
	{
		_color = value;
		_fill.color = _color._Value;
	}

}
