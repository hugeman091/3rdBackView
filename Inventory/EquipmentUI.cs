using System.Collections;
using System.Collections.Generic;
using Data;
using Google.Protobuf.Protocol;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
	public Text _CharacterName;
	public ItemSlot _WeaponSlot;
	public ItemSlot _ShieldSlot;
	public ItemSlot _HelmetSlot;
	public ItemSlot _ArmorSlot;
	public ItemSlot _Accessary1Slot;
	public ItemSlot _Accessary2Slot;

	public void RefreshUI()
	{
		_WeaponSlot._ItemIcon.gameObject.SetActive(false);
		_ShieldSlot._ItemIcon.gameObject.SetActive(false);
		_HelmetSlot._ItemIcon.gameObject.SetActive(false);
		_ArmorSlot._ItemIcon.gameObject.SetActive(false);
		_Accessary1Slot._ItemIcon.gameObject.SetActive(false);
		_Accessary2Slot._ItemIcon.gameObject.SetActive(false);

		foreach (var e in Managers.Inven.Items.Values)
		{
			if (!e.Equipped)
				continue;

			Equip(e);
		}
	}

	public void Equip(Item item)
	{
		Data.ItemData itemData;
		Managers.Data.ItemDict.TryGetValue(item.TemplateId, out itemData);
		switch (itemData.itemType)
		{
			case ItemType.Weapon:
				equipWeapon(itemData as WeaponData, item.ItemDbId);

				break;
			case ItemType.Armor:
			{
				var data = itemData as ArmorData;
				equipArmor(data, item.ItemDbId);
			}
				break;
		}
	}

	void equipWeapon(WeaponData item, int dbId)
	{
		var spr = Resources.Load<Sprite>(item.iconPath);
		_WeaponSlot._ItemIcon.gameObject.SetActive(true);
		_WeaponSlot.sprite = spr;
		_WeaponSlot.DbId = dbId;
	}

	void equipArmor(ArmorData item, int dbId)
	{
		switch (item.armorType)
		{
			case ArmorType.Armor:
			{
				var spr = Resources.Load<Sprite>(item.iconPath);
				_ArmorSlot._ItemIcon.gameObject.SetActive(true);
				_ArmorSlot.sprite = spr;
				_ArmorSlot.DbId = dbId;
			}
				break;
			case ArmorType.Helmet:
			{
				var spr = Resources.Load<Sprite>(item.iconPath);
				_HelmetSlot._ItemIcon.gameObject.SetActive(true);
				_HelmetSlot.sprite = spr;
				_HelmetSlot.DbId = dbId;
			}
				break;
		}

	}
}
