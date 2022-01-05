using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_SkillCountdown : MonoBehaviour , IPointerClickHandler
{
	[SerializeField] private Image _background;
	[SerializeField] private Image _icon;

	[SerializeField] private Image _fill;
	[SerializeField] private TMP_Text _count;

	private float _skillTimer = 200;

	private IObservable<float> countdown(float timer) => Observable.Interval(TimeSpan.FromSeconds(0.01))
			.Select((x) => timer - x)
			.TakeWhile(x => x > 0);

	void Start()
	{
		_count.color = Color.white;
		_count.text = string.Empty;
		_fill.fillAmount = 0;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.clickCount == 1)
		{
			var _countdownObservable = countdown(_skillTimer).Publish();
			_countdownObservable
				.Subscribe(timer =>
				{
					// onNext에서 시간을 표시한다.
					_count.text = Util.NumericFormatString(timer / 100, 1);
					var val = Util.Ratio(timer, _skillTimer);
					_fill.fillAmount = val;
				}, () =>
				{
					// onComplete에서 문자를 지운다.
					_count.color = Color.white;
					_count.text = string.Empty;
					_fill.fillAmount = 0;
				}).AddTo(gameObject);

			// 타이머가 10초 이하로 되는 타이밍에 색을 붉은 색으로 한다.
			_countdownObservable
				.First(timer => timer <= 100)
				.Subscribe(_ => _count.color = Color.red);
			_countdownObservable.Connect();
		}
	}
}