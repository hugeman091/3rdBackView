using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GUI_Ranking : MonoBehaviour
{
	[Serializable]
	public struct rankingData
	{
		public string nickname;
		public int score;
	}

	[SerializeField] private GameObject _rankingLists;
	[SerializeField] private GUI_RankingMyList _myRankingList;
	private const string _listPath = "Prefabs/Ranking/List";
	private const string _myListPath = "Prefabs/Ranking/ListMe";

	private UnityEvent _onListUp = new UnityEvent();

	private string tempMyName = "Bill";

	// Start is called before the first frame update
	void Start() => GetTextAsync(UnityWebRequest.Get("https://localhost:44323/scoreinfo/TopRankings"));
    void jsonToList(string json) => listUpRanking(Newtonsoft.Json.JsonConvert.DeserializeObject<rankingData[]>(json));

    void listUpRanking(rankingData[] lists)
    {
		// need clear Contents list

		for (int i = 0; i < lists.Length; ++i)
		{
			//추후 함수화 하여 개선 필요.
			{
				var pooledObject = GlobalContainers.Pool.Spawn(_listPath);
				if (!pooledObject)
				{
					var obj = GlobalContainers.Resource.Load(_listPath);
					pooledObject = GameObject.Instantiate(obj);
				}

				pooledObject.transform.SetParent(_rankingLists.transform);

				var rankingList = pooledObject.GetComponent<GUI_RankingList>();
				if (rankingList)
				{
					rankingList.Init(lists[i], i + 1);
					Debug.Log($"ranking list added{pooledObject.name}");
				}
			}


			//listme
			if (lists[i].nickname == tempMyName)
			{
				_myRankingList.Init(lists[i], i + 1);
				Debug.Log($"my ranking list added{tempMyName}");
			}
		}
    }

    // get async webrequest
    async UniTaskVoid GetTextAsync(UnityWebRequest req)
    {
	    var op = await req.SendWebRequest();

	    if (op.result == UnityWebRequest.Result.ProtocolError || op.result == UnityWebRequest.Result.ConnectionError)
	    {
		    // 실패시 예외 throw
		    throw new Exception(op.error);
	    }

	    jsonToList(op.downloadHandler.text.ToString());
    }

}
