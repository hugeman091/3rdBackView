using System.CodeDom;
using System.Collections.Generic;
using System.Xml.Serialization;
using Google.Protobuf.Protocol;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/InventoryContainer")]
public class InventoryContainer : ScriptableObject
{
	[SerializeField] private Dictionary<int, Item> _Container = new Dictionary<int, Item>();
	public Dictionary<int, Item> Items => _Container;

	public SharedGameEvent _Event;

	public void Add(int id, Item item)
	{
		if (item == null)
		{
			Debug.Log($"{id} item is null");
			return;
		}

		if (!_Container.ContainsKey(id))
			_Container.Add(id, item);
	}

	public void Remove(int id)
	{
		if (_Container.ContainsKey(id))
			_Container.Remove(id);
	}

	public Item Find(int id)
	{
		Item go = null;
		_Container.TryGetValue(id, out go);
		return go;
	}

	public void Equip(S_EquipItem pkt)
	{
		var item = Find(pkt.ItemDbId);
		item.Equipped = pkt.Equipped;
		_Event.Raise();
	}
}
