using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedData
{
	[CreateAssetMenu(fileName = "armor", menuName = "newItem/armor")]
	public class ArmorData : SharedItemData
	{
		public string armortype;
		public string defence;
	}
}