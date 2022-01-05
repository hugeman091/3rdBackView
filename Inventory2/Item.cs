using System;
using UnityEngine;

public enum ItemType
{
	None,
	Weapon,
	Armor,
	Consumable,
	Accessary,
	Misc,
}

public enum Rarity
{
	Normal,
	Rare,
	Unique
}

[Serializable]
public class Item
{
	//서버에서 받았으면 따로 dbid가 있었을것이다
	public int id;
	public int templateId;
}