using Assets.FantasyMonsters.Scripts;
using UnityEngine;
public class WorldObject : Monster
{
	public void Activate() => gameObject.SetActive(true);
	public void DeActivate() => gameObject.SetActive(false);

}