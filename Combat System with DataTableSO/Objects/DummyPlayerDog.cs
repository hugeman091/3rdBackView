using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Assets.FantasyMonsters.Scripts;
using UnityEngine;

public class DummyPlayerDog : WorldObject
{
	public GameObject _Target;
	public PositionSO _StartPosition;

	public bool _IsAttack;
	void Start()
	{	
		transform.position = _StartPosition.Position;
		transform.localScale = _StartPosition.Scale;

		GlobalManagers.WorldObjects._OnCanAttackEvent.AddListener(SetTarget);
		GlobalManagers.WorldObjects._OnMonsterDeadEvent.AddListener(SetTarget);
	}

	void Update()
	{
		if (!_IsAttack && _Target != null)
		{
			StartCoroutine(Attack());
			GlobalManagers.WorldObjects.ServerAttackMonster(_Target);
		}
	}

	IEnumerator Attack()
	{
		//애니메이션
		base.Attack();
		_IsAttack = true;

		//최적화 필요
		yield return new WaitForSeconds(0.5f);
		_IsAttack = false;

		//대상 찾은 후(충돌처리) 서버로 전송
		//일단은 반대로 몬스터쪽에서 event로 공격할 수 있을때 신호를 보내도록 수정
		//자동 사냥 체력상관없이 무조건 원킬 // 그냥 귀찮으니 매니저로 임시 테스트
	}

	void SetTarget(GameObject target)
	{
		_Target = target;
		SetState(MonsterState.Ready);
	}
}
