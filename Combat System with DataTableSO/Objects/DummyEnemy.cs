using System;
using System.Collections;
using System.Collections.Generic;
using Assets.FantasyMonsters.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DummyEnemy : WorldObject
{
	public bool _IsDead = false;
	public bool _StartBattle = false;
	public bool _CanAttack = false;
	public float _Speed = 70f;
	public float _attackdistance = 1f;
	public float _GameSpeed = 1f;

	public PositionSO _BattlePosition;
	public PositionSO _StartPosition;

	public MonsterTableData _TableData;

	public UnityEvent<GameObject> _OnCanAttackEvent;
	public UnityEvent<GameObject> _OnDeadEvent;

	public ulong HP
	{
		get => _TableData.hp;
		set => _TableData.hp = value;
	}

	void OnEnable()
	{
		transform.position = _StartPosition.Position;
		transform.localScale = _StartPosition.Scale;
	}

	void Update()
	{
		if (_CanAttack) return;
		if (_StartBattle) MoveTo();
	}

	void MoveTo()
	{
		SetState(MonsterState.Walk);
		var battlePosition = _BattlePosition.Position;

		var dist = battlePosition - transform.position;
		if (dist.magnitude > _attackdistance)
		{
			var translate = dist.normalized * Time.deltaTime * _Speed * _GameSpeed;
			transform.Translate(new Vector3(translate.x, 0, 0));
		}
		else
		{
			_CanAttack = true;
			_OnCanAttackEvent.Invoke(this.gameObject);
		}
	}

	public void OnDead()
	{
		_OnDeadEvent.Invoke(null);
		_IsDead = true;
		Die();
	}

	//Death Animation End Event
	public void DeadAnimationEnd()
	{
		DeActivate();
	}
}
