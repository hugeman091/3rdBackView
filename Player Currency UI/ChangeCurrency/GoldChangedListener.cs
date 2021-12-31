using UnityEngine;

public	class GoldChangedListener : GameEventListener
{
	[SerializeField] private TMPro.TextMeshProUGUI _text;
	[SerializeField] private IntegerVariableSO _gold;

	//왜 콜백으로 업데이트는 안되는건지 참 답답허다
	void Update() => _text.SetText(Util.NumericFormatString(_gold._Value));
}