using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedData
{
	[CreateAssetMenu(fileName = "consumable", menuName = "newItem/consumable")]
	public class ConsumableData : SharedItemData
	{
		public string consumableType;
		public string damage;
	}
}