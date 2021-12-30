using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableUI : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		int clickCount = eventData.clickCount;

		if (clickCount == 1)
			OnSingleClick();
		else if (clickCount == 2)
			OnDoubleClick();
		else if (clickCount > 2)
			OnMultiClick();
	}

	protected virtual void OnSingleClick()
	{
		Debug.Log("Single Clicked");
	}

	protected virtual void OnDoubleClick()
	{
		Debug.Log("Double Clicked");
	}

	protected virtual void OnMultiClick()
	{
		Debug.Log("MultiClick Clicked");
	}
}