using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_RankingMyList : MonoBehaviour
{
	[SerializeField] private TMP_Text _rank;
	[SerializeField] private TMP_Text _score;
	[SerializeField] private TMP_Text _nickname;

	[SerializeField] private Image _nationalFlag;

	public void Init(GUI_Ranking.rankingData ranker, int rank)
	{
		_rank.text = rank.ToString();
		_score.text = ranker.score.ToString();
		_nickname.text = ranker.nickname;

	}


	void setFlag()
	{

	}
}
