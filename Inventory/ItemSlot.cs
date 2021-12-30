using System.Dynamic;
using Google.Protobuf.Protocol;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlot : ClickableUI
{
	public static ItemSlot CreateInstance(Transform transform)
	{
		var go = Instantiate(Resources.Load<ItemSlot>("Prefabs/ItemSlot"), transform);
		return go;
	}

	public Image _Selected;
	public Image _ItemIcon;

	public Sprite sprite
	{
		get => _ItemIcon.sprite;
		set => _ItemIcon.sprite = value;
	}

	public int DbId { get; set; }

	public ItemType ItemType { get; set; }

	public void SetIcon(Item item)
	{
		Data.ItemData itemData = null;
		Managers.Data.ItemDict.TryGetValue(item.TemplateId, out itemData);

		_ItemIcon.sprite = Resources.Load<Sprite>(itemData.iconPath);
		_ItemIcon.gameObject.SetActive(true);

		ItemType = itemData.itemType;
		DbId = item.ItemDbId;
	}

	public void Select(bool selected)
	{
		_Selected.gameObject.SetActive(selected);
	}

	protected override void OnDoubleClick()
	{
		Debug.Log(DbId);
		var item = Managers.Inven.Find(DbId);
		if (item != null)
		{
			if (item.Equipped)
			{
				var pkt = new C_EquipItem();
				pkt.Equipped = false;
				pkt.ItemDbId = DbId;
				Managers.Network.Send(pkt);

			}
			else
			{
				var pkt = new C_EquipItem();
				pkt.Equipped = true;
				pkt.ItemDbId = DbId;
				Managers.Network.Send(pkt);
			}
			
		}
	}
}
