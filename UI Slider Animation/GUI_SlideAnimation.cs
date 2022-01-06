using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_SlideAnimation : MonoBehaviour , IPointerClickHandler
{
	public Slider _Slider;

	void Awake() => DOTween.Init(true);


	void IncreaseValue()
	{
		DOTween.To(
				() => _Slider.value,
				x => _Slider.value = x, 0.7f, 2f)
			.SetEase(Ease.InOutCubic);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.clickCount == 1)
		{
			IncreaseValue();
		}
	}
}
