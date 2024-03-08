using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	[SerializeField] private GameObject pickupPanel;
	private KeyCode interactKey = KeyCode.F;
	[SerializeField] private Item nearestItem;

	private void Update()
	{
		if (Input.GetKeyDown(interactKey) && nearestItem != null)
		{
			Pickup();
		}
	}
	private void FixedUpdate()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one / 2, 0);
		List<Item> items = new List<Item>();
		foreach (var collider in colliders)
		{
			Item item = collider.GetComponent<Item>();
			if (item && item.isPickupable)
			{
				items.Add(item);
			}
		}
		if (items.Count > 0)
		{
			nearestItem = items[0];
			foreach (var item in items)
			{
				if (Vector2.Distance(transform.position, item.gameObject.transform.position) <
					Vector2.Distance(transform.position, nearestItem.gameObject.transform.position) && item.isPickupable)
				{
					nearestItem = item;
				}
			}
			pickupPanel.SetActive(true);
			MainCanvas.instance.interactButtonText.GetComponent<TextMeshProUGUI>().text = interactKey.ToString();
		}
		else
		{
			pickupPanel.SetActive(false);
		}
	}
	private void Pickup()
	{
		GetComponent<PlayerInventory>().AddItem(nearestItem.itemSO, nearestItem.amount);
		Destroy(nearestItem.gameObject);
	}
}
