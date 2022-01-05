
using System.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_ItemSlot : MonoBehaviour, IPointerClickHandler
{
	private ItemTableData _tableData;
	public Image _BackGround;
	public Image _Icon;
	public TMP_Text _Count;

	private const string _defaultPath = "Prefabs/Item/";
	void Start()
	{
		string iconPath = _defaultPath + _tableData.IconPath;
		Debug.Log(iconPath);
		_Icon.sprite = GlobalContainers.Resource.Load<Sprite>(iconPath);
		_BackGround.color = rarity();
	}

	public void Init(ItemTableData data) => _tableData = data;

	Color rarity()
	{
		return _tableData.rarity switch
		{
			Rarity.Normal => Util.ToColor("021334"),
			Rarity.Unique => Util.ToColor("270A08"),
			Rarity.Rare => Util.ToColor("210D34"),
			_ => Color.black
		};
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		int clickCount = eventData.clickCount;
		if (clickCount == 2)
		{

		}
	}
}
