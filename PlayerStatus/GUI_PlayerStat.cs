using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_PlayerStat : GameEventListener
{
	[SerializeField] private GUI_Slider _damageSlider;
	[SerializeField] private LongVariableSO _damage;
	[SerializeField] private LongVariableSO _maxDamage;
	[Space(10)]
	[SerializeField] private GUI_Slider _attackSlider;
	[SerializeField] private LongVariableSO _attack;
	[SerializeField] private LongVariableSO _maxAttack;
	[Space(10)]
	[SerializeField] private GUI_Slider _defenceSlider;
	[SerializeField] private LongVariableSO _defence;
	[SerializeField] private LongVariableSO _maxDefence;
	[Space(10)]
	[SerializeField] private GUI_Slider _healthSlider;
	[SerializeField] private LongVariableSO _health;
	[SerializeField] private LongVariableSO _maxHealth;
	[Space(10)]
	[SerializeField] private GUI_Slider _magicSlider;
	[SerializeField] private LongVariableSO _magic;
	[SerializeField] private LongVariableSO _maxMagic;

	void Start()
	{
		Response.AddListener(changedDamage);
		Response.AddListener(changedDefence);
		Response.AddListener(changedAttack);
		Response.AddListener(changedHp);
		Response.AddListener(changedMagic);

		changedAttack();
		changedDefence();
		changedHp();
		changedMagic();
		changedDamage();
	}

	void changedDamage() => _damageSlider.ChangeScaler(Util.Ratio(_damage._Value, _maxDamage._Value));
	void changedAttack() => _attackSlider.ChangeScaler(Util.Ratio(_attack._Value, _maxAttack._Value));
	void changedDefence() => _defenceSlider.ChangeScaler(Util.Ratio(_defence._Value, _maxDefence._Value));
	void changedHp() => _healthSlider.ChangeScaler(Util.Ratio(_health._Value, _maxHealth._Value));
	void changedMagic() => _magicSlider.ChangeScaler(Util.Ratio(_magic._Value, _maxMagic._Value));
}

