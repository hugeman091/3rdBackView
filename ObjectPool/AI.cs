using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using Google.Protobuf.Protocol;

class AI : WorldObject
{
	public static AI CreateInstance(ObjectInfo info)
	{
		_poolId = "AIs";
		var pooledObject = Managers.Pool.Pool(_poolId).Spawn() as AI;

		if (!pooledObject)
		{
			pooledObject = Instantiate(Resources.Load<AI>("Prefabs/AI"));
			Managers.Pool.Pool(_poolId).Add(pooledObject);
		}

		pooledObject.Activate();
		pooledObject.PosInfo.MergeFrom(info.PosInfo);
		pooledObject.ObjectInfo.MergeFrom(info);
		pooledObject.Reset();
		return pooledObject;
	}
	void Start()
	{
		Init();

	}

	public void Reset()
	{
		Init();
		if (_needReset)
		{
			PosX = PosInfo.PosX;
			PosY = PosInfo.PosY;
			Id = ObjectInfo.ObjectId;
			name = ObjectInfo.Name;

			_grid = Managers.Map.CurrentGrid;
			_healthBar.ScaleHealthBar(1f);
			_needReset = false;
		}
	}

	void Update()
	{
		UpdateAnimation();
		UpdateController();
	}
	protected virtual void UpdateAnimation()
	{
		if (_animator == null || _sprite == null)
			return;

		if (State == CreatureState.Idle)
		{
			switch (Dir)
			{
				case MoveDir.Down:
					_animator.Play("Idle_Front");
					break;
				case MoveDir.Up:
					_animator.Play("Idle_Back");
					break;
				case MoveDir.Right:
					_animator.Play("Idle_Side");
					_sprite.flipX = false;
					break;
				case MoveDir.Left:
					_animator.Play("Idle_Side");
					_sprite.flipX = true;
					break;

			}
		}
		else if (State == CreatureState.Moving)
		{
			switch (Dir)
			{
				case MoveDir.Down:
					_animator.Play("Walk_Front");
					break;
				case MoveDir.Up:
					_animator.Play("Walk_Back");
					break;
				case MoveDir.Right:
					_animator.Play("Walk_Side");
					_sprite.flipX = false;
					break;
				case MoveDir.Left:
					_animator.Play("Walk_Side");
					_sprite.flipX = true;
					break;
			}
		}
		else if (State == CreatureState.Skill)
		{
			switch (Dir)
			{
				case MoveDir.Up:
					_animator.Play("Attack_Back");
					_sprite.flipX = false;
					break;
				case MoveDir.Down:
					_animator.Play("Attack_Front");
					_sprite.flipX = false;
					break;
				case MoveDir.Left:
					_animator.Play("Attack_Side");
					_sprite.flipX = true;
					break;
				case MoveDir.Right:
					_animator.Play("Attack_Side");
					_sprite.flipX = false;
					break;
			}
		}
		else
		{

		}
	}
	protected virtual void UpdateController()
	{
		switch (State)
		{
			case CreatureState.Idle:
				UpdateIdle();
				break;
			case CreatureState.Moving:
				UpdateMoving();
				break;
			case CreatureState.Skill:
				UpdateSkill();
				break;
			case CreatureState.Dead:
				UpdateDead();
				break;
		}
	}
	protected virtual void UpdateIdle()
	{
	}
	protected virtual void UpdateSkill()
	{

	}
	protected virtual void MoveToNextPos()
	{

	}
	protected virtual void UpdateDead()
	{

	}

	public override void OnDead()
	{
		Effect.CreateInstance(transform);
		Managers.Object.Remove(Id);
		_needReset = true;
	}

	// 스르륵 이동하는 것을 처리
	protected virtual void UpdateMoving()
	{
		Vector3 destPos = Managers.Map.CurrentGrid.CellToWorld(new Vector3Int(PosX, PosY, 0));
		Vector3 moveDir = destPos - transform.position;

		// 도착 여부 체크
		float dist = moveDir.magnitude;
		if (dist < _speed * Time.deltaTime)
		{
			transform.position = destPos;
			MoveToNextPos();
		}
		else
		{
			transform.position += moveDir.normalized * _speed * Time.deltaTime;
			State = CreatureState.Moving;
		}
	}
}
