using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedData
{
	[CreateAssetMenu(menuName = "ItemData")]
	public class ItemDatas : ScriptableObject
	{
		public List<WeaponData> weapons;
		public List<ArmorData> armors;
		public List<ConsumableData> consumables;
	}
}
