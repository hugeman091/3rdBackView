using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	private List<ItemSlot> _Inventory = new List<ItemSlot>();
	public GameObject _Grid;

	private ItemSlot _SelectedSlot = null;

	void Start()
	{
		Init();
	}

	public void Init()
	{
		_Inventory.Clear();

		foreach (Transform child in _Grid.transform)
			Destroy(child.gameObject);

		for (int i = 0; i < 20; i++)
		{
			var go = ItemSlot.CreateInstance(_Grid.transform);
			_Inventory.Add(go);
		}

		RefreshUI();
	}

	public void RefreshUI()
	{
		if (_Inventory.Count == 0)
			return;

		List<Item> items = Managers.Inven.Items.Values.ToList();
		items.Sort((left, right) => { return left.Slot - right.Slot; });

		foreach (Item item in items)
		{
			if (item.Slot < 0 || item.Slot >= 20)
				continue;

			_Inventory[item.Slot].SetIcon(item);
			_Inventory[item.Slot].Select(item.Equipped);
		}
	}

	public void SelectIcon(ItemSlot slot)
	{
		if (_SelectedSlot)
		{
			_SelectedSlot.Select(false);
		}
		slot.Select(true);
		_SelectedSlot = slot;
	}
}

