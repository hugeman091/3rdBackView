using UnityEngine;
using UnityEngine.UI;

public class GUI_Inventory : MonoBehaviour
{
	[SerializeField] private Button _categoryAll;
	[SerializeField] private GameObject _categoryAllFocus;
	[SerializeField] private Button _categoryWeapon;
	[SerializeField] private GameObject _categoryWeaponFocus;
	[SerializeField] private Button _categoryArmor;
	[SerializeField] private GameObject _categoryArmorFocus;
	[SerializeField] private Button _categoryAccessary;
	[SerializeField] private GameObject _categoryAccessaryFocus;

	[SerializeField] private GameObject _tabFocus;

	private GridLayoutGroup _Inventory;
	private const string ItemSlotPath = "Prefabs/UI/Inventory/Itemslot";
	
	void Start()
	{
		_Inventory = GetComponentInChildren<GridLayoutGroup>();
		_categoryAll.onClick.AddListener(delegate { filter(ItemType.None); });
		_categoryWeapon.onClick.AddListener(delegate { filter(ItemType.Weapon); });
		_categoryArmor.onClick.AddListener(delegate { filter(ItemType.Armor); });
		_categoryAccessary.onClick.AddListener(delegate { filter(ItemType.Accessary); });

		//default
		filter();
	}
	void clearGridLayout()
	{
		for (int i = 0; i < _Inventory.transform.childCount; i++)
			Destroy(_Inventory.transform.GetChild(i).gameObject);
	}

	void filter(ItemType type = ItemType.None)
	{
		clearGridLayout();

		foreach (var e in GlobalContainers.Inventory.GetItems())
		{
			var itemData = GlobalTables.ItemSO.Find(e.templateId);

			if (type == ItemType.None || itemData.type == type)
			{
				var pooledObject = GlobalContainers.Pool.Spawn(ItemSlotPath);
				if (!pooledObject)
				{
					var obj = GlobalContainers.Resource.Load(ItemSlotPath);
					pooledObject = GameObject.Instantiate(obj);
				}

				pooledObject.transform.SetParent(_Inventory.transform);
				Debug.Log($"ItemCreate{pooledObject.name}");

				var itemslot = pooledObject.GetComponent<GUI_ItemSlot>();
				if (itemslot) itemslot.Init(itemData);
			}
		}

		focus(type);
	}

	void focus(ItemType type = ItemType.None)
	{
		_categoryAllFocus.SetActive(type == ItemType.None);
		_categoryWeaponFocus.SetActive(type == ItemType.Weapon);
		_categoryArmorFocus.SetActive(type == ItemType.Armor);
		_categoryAccessaryFocus.SetActive(type == ItemType.Accessary);

		switch (type)
		{
			case ItemType.None:
				_tabFocus.transform.SetParent(_categoryAll.transform, false);
				return;
			case ItemType.Weapon:
				_tabFocus.transform.SetParent(_categoryWeapon.transform, false);
				return;
			case ItemType.Armor:
				_tabFocus.transform.SetParent(_categoryArmor.transform, false);
				return;
			case ItemType.Accessary: 
				_tabFocus.transform.SetParent(_categoryAccessary.transform, false);
				return;
		};
	}


}
