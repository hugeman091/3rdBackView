using Data;
using Google.Protobuf.Protocol;
using UnityEngine;

public class Item
{

	public static Item CreateInstance(ItemInfo itemInfo)
	{
		Item item = null;

		ItemData itemData = null;
		Managers.Data.ItemDict.TryGetValue(itemInfo.TemplateId, out itemData);

		if (itemData == null)
			return null;

		switch (itemData.itemType)
		{
			case ItemType.Weapon:
				item = new Weapon(itemInfo.TemplateId);
				break;
			case ItemType.Armor:
				item = new Armor(itemInfo.TemplateId);
				break;
			case ItemType.Consumable:
				item = new Consumable(itemInfo.TemplateId);
				break;
		}

		if (item != null)
		{
			item.ItemDbId = itemInfo.ItemDbId;
			item.Count = itemInfo.Count;
			item.Slot = itemInfo.Slot;
			item.Equipped = itemInfo.Equipped;
		}
		return item;
	}
	public ItemInfo Info { get; } = new ItemInfo();

	public int ItemDbId
	{
		get => Info.ItemDbId;
		set => Info.ItemDbId = value;
	}

	public int TemplateId
	{
		get => Info. TemplateId;
		set => Info.TemplateId = value;
	}

	public int Count
	{
		get => Info.Count;
		set => Info.Count = value;
	}

	public int Slot
	{
		get => Info.Slot;
		set => Info.Slot = value;
	}

	public bool Equipped
	{
		get => Info.Equipped;
		set => Info.Equipped = value;
	}

	public ItemType ItemType { get; private set; }
	public bool Stackable { get; protected set; }

	public Item(ItemType itemType)
	{
		ItemType = itemType;
	}
}

public class Weapon : Item
{
	public WeaponType _WeaponType;
	public int _Damage;

	public Weapon(int templateId) : base(ItemType.Weapon)
	{
		Init(templateId);
	}

	void Init(int templateId)
	{
		ItemData itemData = null;
		Managers.Data.ItemDict.TryGetValue(templateId, out itemData);
		if (itemData.itemType != ItemType.Weapon)
			return;

		WeaponData data = (WeaponData)itemData;
		{
			TemplateId = data.id;
			Count = 1;
			_WeaponType = data.weaponType;
			_Damage = data.damage;
			Stackable = false;
		}
	}
}

public class Armor : Item
{
	public ArmorType ArmorType { get; private set; }
	public int Defence { get; private set; }

	public Armor(int templateId) : base(ItemType.Armor)
	{
		Init(templateId);
	}

	void Init(int templateId)
	{
		ItemData itemData = null;
		Managers.Data.ItemDict.TryGetValue(templateId, out itemData);
		if (itemData.itemType != ItemType.Armor)
			return;

		ArmorData data = (ArmorData)itemData;
		{
			TemplateId = data.id;
			Count = 1;
			ArmorType = data.armorType;
			Defence = data.defence;
			Stackable = false;
		}
	}
}

public class Consumable : Item
{
	public ConsumableType ConsumableType { get; private set; }
	public int MaxCount { get; set; }

	public Consumable(int templateId) : base(ItemType.Consumable)
	{
		Init(templateId);
	}

	void Init(int templateId)
	{
		ItemData itemData = null;
		Managers.Data.ItemDict.TryGetValue(templateId, out itemData);
		if (itemData.itemType != ItemType.Consumable)
			return;

		ConsumableData data = (ConsumableData)itemData;
		{
			TemplateId = data.id;
			Count = 1;
			MaxCount = data.maxCount;
			ConsumableType = data.consumableType;
			Stackable = (data.maxCount > 1);
		}
	}
}
