using UnityEngine;

public	class GemChangedListener : GameEventListener
{
	[SerializeField] private TMPro.TextMeshProUGUI _text;
	[SerializeField] private IntegerVariableSO _gem;

	//왜 콜백으로 업데이트는 안되는건지 참 답답허다
	void Update() => _text.SetText(Util.NumericFormatString(_gem._Value));
}