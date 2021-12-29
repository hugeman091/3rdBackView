using System;
using System.Collections;
using ClientCore;
using Google.Protobuf.Protocol;
using UnityEngine;

//ID 없음 클라이언트에서만 사용
class Effect : Poolable
{
	private static string _poolId = "Effects";

	public static Effect CreateInstance(Transform transfom)
	{
		var pooledObject = Managers.Pool.Pool(_poolId).Spawn() as Effect;
		if (!pooledObject)
		{
			pooledObject = Instantiate(Resources.Load<Effect>("Prefabs/DeathEffect"), transfom.position,
				transfom.rotation);
			Managers.Pool.Pool(_poolId).Add(pooledObject);
		}

		pooledObject.transform.position = transfom.position;
		pooledObject.Reset();

		return pooledObject;
	}

	public void Reset()
	{
		//Inactive상태일때는 코루틴 작동 안함.
		Activate();
		GetComponent<Animator>().Play("Death_Effect");
		StartCoroutine(CountDown());
	}


	IEnumerator CountDown()
	{
		yield return new WaitForSeconds(0.5f);
		Deactivate();
	}
}

