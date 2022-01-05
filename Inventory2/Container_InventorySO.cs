using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Container_InventorySO", menuName = "Container/Inventory")]
public class Container_InventorySO : SingleTonSO<Container_InventorySO>
{
#if UNITY_EDITOR
	[TextArea]
	[Tooltip("Doesn't do anything. Just comments shown in inspector")]
	public string Comments = "Comments";
#endif

	public List<Item> _inventoryContainer;

	public void AddRange(List<Item> itemList) => _inventoryContainer = itemList;
	public void AddRange(Item[] itemList) => _inventoryContainer = itemList.ToList();
	public void Add(Item item) => _inventoryContainer.Add(item);
	public Item Find(int id) => _inventoryContainer.Find((e) => e.id == id);
	public void Remove(int id) => _inventoryContainer.Remove(Find(id));
	public void Remove(Item item) => _inventoryContainer.Remove(item);
	public void Clear() => _inventoryContainer.Clear();

	public List<Item> GetItems() => _inventoryContainer;
	public Item[] GetItemsArray() => _inventoryContainer.ToArray();
}

