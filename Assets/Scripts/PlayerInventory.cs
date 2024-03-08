using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Inventory
{
	private bool isOpened = false;
	private List<PlayerInventorySlot> playerInventorySlots = new List<PlayerInventorySlot>();
	private void Start()
	{
		playerInventorySlots = InventoryContainer.instance.inventoryPanel.GetComponentsInChildren<PlayerInventorySlot>().ToList();
		for (int i = 0; i < playerInventorySlots.Count; i++)
		{
			inventorySlots.Add(new InventorySlot());
			playerInventorySlots[i].slot = inventorySlots[i]; 
		}
		InventoryContainer.instance.gameObject.SetActive(false);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			isOpened = !isOpened;
			Player.Instance.GetComponent<PlayerMovement>().ToggleMovement();
			InventoryContainer.instance.gameObject.SetActive(isOpened);
		}
		if (Input.GetKeyDown(KeyCode.Escape) && isOpened)
		{
			isOpened = false;
			Player.Instance.GetComponent<PlayerMovement>().ToggleMovement();
			InventoryContainer.instance.gameObject.SetActive(false);
		}
	}
	public override void AddItem(ItemSO item, int amount)
	{
		base.AddItem(item, amount);
		Refresh();
	}
	public override void Drop(InventorySlot slot)
	{
		base.Drop(slot);
		HideInfo();
		Refresh();
	}
	public override void Remove(InventorySlot slot, int amount)
	{
		base.Remove(slot, amount);
		Debug.Log(slot.amount - amount);
		if (slot.amount - amount < 0)
		{
			HideInfo();
		}
		Refresh();
	}
	private void Refresh()
	{
		foreach (var UISlot in playerInventorySlots)
		{
			if (UISlot.slot.item)
			{
				UISlot.GetComponent<Button>().enabled = true;
				UISlot.amountText.text = UISlot.slot.amount.ToString();
				UISlot.itemIcon.sprite = UISlot.slot.item.itemIcon;
				UISlot.itemIcon.color = Color.white;
			}
			else
			{
				UISlot.GetComponent<Button>().enabled = false;
				UISlot.amountText.text = "";
				UISlot.itemIcon.color = Color.clear;
			}
		}
	}
	private void HideInfo()
	{
		InventoryContainer inventoryContainer = InventoryContainer.instance;
		inventoryContainer.inventoryItemName.text = "";
		inventoryContainer.inventoryItemDescription.text = "";
		inventoryContainer.inventoryItemIcon.sprite = null;
		inventoryContainer.inventoryItemIcon.color = Color.clear;
		inventoryContainer.dropButton.gameObject.SetActive(false);
		inventoryContainer.useButton.gameObject.SetActive(false);
		inventoryContainer.healthStat.SetActive(false);
		inventoryContainer.staminaStat.SetActive(false);
		inventoryContainer.mindStat.SetActive(false);
	}
}