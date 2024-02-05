using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	protected KeyCode interactKey = KeyCode.F;
	private GameObject interactSpan;
	private Item nearestItem;

	private void Update()
	{
		if (Input.GetKeyDown(interactKey) && nearestItem != null)
		{
			// Pickup(nearestItem);
		}
	}
	private void FixedUpdate()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one / 2, 0);
		List<Item> items = new List<Item>();
		foreach (var collider in colliders)
		{
			Item item = collider.GetComponent<Item>();
			if (item)
			{
				items.Add(item);
			}
		}
		interactSpan = MainCanvas.instance.interactSpan;
		if (items.Count > 0)
		{
			Item closestitem = items[0];
			foreach (var item in items)
			{
				if (Vector2.Distance(transform.position, item.gameObject.transform.position) <
					Vector2.Distance(transform.position, closestitem.gameObject.transform.position) && item.isPickupable)
				{
					closestitem = item;
				}
			}
			if (true)
			{

			}
			interactSpan.SetActive(true);
			MainCanvas.instance.interactButtonText.GetComponent<TextMeshProUGUI>().text = interactKey.ToString();
		}
		else
		{
			interactSpan.SetActive(false);
		}
	}
}
