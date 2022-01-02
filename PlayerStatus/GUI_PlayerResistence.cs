using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI_PlayerResistence : GameEventListener
{
	[SerializeField] private TMP_Text _fire;
	[SerializeField] private TMP_Text _water;
	[SerializeField] private TMP_Text _wood;
	[SerializeField] private TMP_Text _light;
	[SerializeField] private TMP_Text _dark;
	[Space(10)]
	[SerializeField] private ShortVariableSO _fireSO;
	[SerializeField] private ShortVariableSO _waterSO;
	[SerializeField] private ShortVariableSO _woodSO;
	[SerializeField] private ShortVariableSO _lightSO;
	[SerializeField] private ShortVariableSO _darkSO;

	void Start()
	{
		Response.AddListener(changedDark);
		Response.AddListener(changedFire);
		Response.AddListener(changedLight);
		Response.AddListener(changedWater);
		Response.AddListener(changedWood);

		changedDark();
		changedFire();
		changedLight();
		changedWater();
		changedWood();
	}

	void changedFire() => _fire.text = Util.NumericFormatString(_fireSO._Value);
	void changedWater() => _water.text = Util.NumericFormatString(_waterSO._Value);
	void changedWood() => _wood.text = Util.NumericFormatString(_woodSO._Value);
	void changedLight() => _light.text = Util.NumericFormatString(_lightSO._Value);
	void changedDark() => _dark.text = Util.NumericFormatString(_darkSO._Value);

}
