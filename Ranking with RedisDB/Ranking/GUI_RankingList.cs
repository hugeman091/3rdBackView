using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_RankingList : MonoBehaviour
{
	[SerializeField] private TMP_Text _rank;
	[SerializeField] private TMP_Text _score;
	[SerializeField] private TMP_Text _nickname;

	[SerializeField] private Image _medal;
	[SerializeField] private Image _nationalFlag;

	private const string _goldMedalPath = "Prefabs/Ranking/icon_color_medal_gold";
	private const string _silverMedalPath = "Prefabs/Ranking/icon_color_medal_silver";
	private const string _bronzeMedalPath = "Prefabs/Ranking/icon_color_medal_bronze";

	public void Init(GUI_Ranking.rankingData ranker, int rank)
	{
		_rank.text = rank.ToString();
		_score.text = ranker.score.ToString();
		_nickname.text = ranker.nickname;

		setMedal(rank);
	}

	void setMedal(int rank)
	{
		if (rank > 3)
		{
			_medal.gameObject.SetActive(false);
			_rank.gameObject.SetActive(true);
		}
		
		else
		{
			_rank.gameObject.SetActive(false);
			_medal.gameObject.SetActive(true);
			getMedalImage(rank);
		}
	}

	void setFlag()
	{

	}

	void getMedalImage(int rank)
	{
		string medelpath = string.Empty;
		switch (rank)
		{
			case 1: medelpath = _goldMedalPath;
				break;
			case 2: medelpath = _silverMedalPath;
				break;
			case 3: medelpath = _bronzeMedalPath;
				break;
		}

		var sprite = GlobalContainers.Resource.Load<Sprite>(medelpath);
		_medal.sprite = sprite;
	}
}