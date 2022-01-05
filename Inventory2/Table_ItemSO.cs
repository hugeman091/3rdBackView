using System;
using UnityEngine;

[Serializable] public struct ItemTableData
{
	public int temlateid;
	[Space(10)]
	public string name;
	public string IconPath;
	public ItemType type;
	public Rarity rarity;
}

[CreateAssetMenu(fileName = "Table_ItemSO", menuName = "table/item")]
public class Table_ItemSO : SingleTonSO<Table_ItemSO>
{
	public ItemTableData[] _weaponTable;
	public ItemTableData[] _armorTable;
	public ItemTableData[] _consumableTable;
	public ItemTableData[] _accessaryTable;
	public ItemTableData[] _miscTable;

	public ItemTableData Find(int templateId) => Array.Find<ItemTableData>(GetItemTypeTable(templateId), (e) => e.temlateid == templateId);
	public ItemTableData[] GetItemTypeTable(int templateId)
	{
		Debug.Log($"ItemType {getType(templateId)}");
		return getType(templateId) switch
		{
			ItemType.Weapon => _weaponTable,
			ItemType.Armor => _armorTable,
			ItemType.Consumable => _consumableTable,
			ItemType.Accessary => _accessaryTable,
			ItemType.Misc => _miscTable,
			_ => null
		};
	}
	private ItemType getType(int templateId) => (ItemType)(templateId / 1000);
}
