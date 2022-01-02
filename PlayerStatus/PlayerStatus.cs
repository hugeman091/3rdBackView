using UnityEngine;
public class PlayerStatus : MonoBehaviour
{
	public LongVariableSO _Attack;
	public LongVariableSO _Damage;
	public LongVariableSO _Defence;
	public LongVariableSO _Hp;
	public LongVariableSO _Magic;
	public LongVariableSO _MaxAttack;
	public LongVariableSO _MaxDamage;
	public LongVariableSO _MaxDefence;
	public LongVariableSO _MaxHp;
	public LongVariableSO _MaxMagic;
	[Space(10)]
	public ShortVariableSO _DarkResist;
	public ShortVariableSO _FireResist;
	public ShortVariableSO _LightResist;
	public ShortVariableSO _WaterResist;
	public ShortVariableSO _WoodResist;
	[Space(10)] 
	public RequiredExpData _expData;
	public LongVariableSO _Exp;
	public ShortVariableSO _Level;
	public LongVariableSO _MinExp;
	public LongVariableSO _MaxExp;
	[Space(10)]
	public GameEventSO _OnStatusChanged;
	public GameEventSO _OnResistenceChanged;
	public GameEventSO _OnExpChanged;

	public void StatusChanged(StatusInfo info)
	{
		//패킷을 파라미터로 받아서 호출
		var fakevalue = info;

		System.Random rng = new System.Random();
		//유저 Status 변경
		_Attack.SetValue(rng.Next(0,101));
		_Damage.SetValue(rng.Next(0, 101));
		_Defence.SetValue(rng.Next(0, 101));
		_Hp.SetValue(rng.Next(0, 101));
		_Magic.SetValue(rng.Next(0, 101));

		_MaxAttack.SetValue(100);
		_MaxDamage.SetValue(100);
		_MaxDefence.SetValue(100);
		_MaxHp.SetValue(100);
		_MaxMagic.SetValue(100);

		//Status변경 이벤트 Raise()
		_OnStatusChanged.Raise();
	}

	public void ResistenceChanged(ResistInfo info)
	{
		//패킷을 파라미터로 받아서 호출
		var fakeinfo = info;

		System.Random rng = new System.Random();
		//유저 Status 변경
		_DarkResist.SetValue((short)rng.Next(0,1001));
		_FireResist.SetValue((short)rng.Next(0, 1001));
		_LightResist.SetValue((short)rng.Next(0, 1001));
		_WaterResist.SetValue((short)rng.Next(0, 1001));
		_WoodResist.SetValue((short)rng.Next(0, 1001));

		//Status변경 이벤트 Raise()
		_OnResistenceChanged.Raise();
	}

	public void ExpChanged(ExpInfo info)
	{
		//패킷을 파라미터로 받아서 호출
		var fakeinfo = info;

		System.Random rng = new System.Random();
		//유저 Status 변경
		var playerRandomLevel = rng.Next(1, 6); // 랜덤으로 레벨 만듬

		var playerRandomExp = rng.Next(0, 50);
		_Exp.SetValue(playerRandomExp);
		_Level.SetValue((short)_expData.GetLevel((ulong)playerRandomExp));
		var expData = _expData.GetRequiredExp(_Level._Value);
		_MinExp.SetValue((long)expData.Value.minExp);
		_MaxExp.SetValue((long)expData.Value.maxExp);
		

		//Status변경 이벤트 Raise()
		_OnExpChanged.Raise();
	}
}

