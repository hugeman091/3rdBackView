using UnityEngine;

namespace SharedData
{
	[CreateAssetMenu(fileName = "weapon", menuName = "newItem/weapon")]
	public class WeaponData : SharedItemData
	{
		public string weaponType;
		public string damage;
	}
}
