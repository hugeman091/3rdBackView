using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnergyChangedListener : GameEventListener
{
	[SerializeField] private TMPro.TextMeshProUGUI _text;
	[SerializeField] private IntegerVariableSO _energy;
	[SerializeField] private IntegerVariableSO _energyMax;

	//왜 콜백으로 업데이트는 안되는건지 참 답답허다
	void Update() => _text.SetText($"{Util.NumericFormatString(_energy._Value)}/{Util.NumericFormatString(_energyMax._Value)}");
}

