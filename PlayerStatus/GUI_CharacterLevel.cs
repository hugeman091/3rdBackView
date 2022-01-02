using TMPro;
using UnityEngine;

public class GUI_CharacterLevel : GameEventListener
{
	[SerializeField] private TMP_Text _levelText;
	[SerializeField] private TMP_Text _expText;
	[SerializeField] private GUI_Slider _expSlider;

	[SerializeField] private ShortVariableSO _level;
	[SerializeField] private LongVariableSO _minExp;
	[SerializeField] private LongVariableSO _maxExp;
	[SerializeField] private LongVariableSO _exp;

	void Start()
	{
		Response.AddListener(changedExp);
		changedExp();
	}

	void changedExp()
	{
		_levelText.text = Util.NumericFormatString(_level._Value);

		var expPercent = (float)_exp._Value / _maxExp._Value * 100;
		_expText.text = Util.NumericFormatString(expPercent, 2) + "%";

		_expSlider.ChangeScaler(expPercent);
	}
}
