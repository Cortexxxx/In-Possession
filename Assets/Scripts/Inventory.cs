using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
	protected List<InventorySlot> inventorySlots = new List<InventorySlot>();
	public virtual void AddItem(ItemSO item, int amount)
	{
		Debug.Log("AADDD");
		if (amount < 0 || !item)
		{
			return;
		}
		foreach (InventorySlot slot in inventorySlots)
		{
			if (slot.item == item && slot.amount != slot.item.maxAmount)
			{
				int avalibleAmount = slot.item.maxAmount - slot.amount;
				Debug.Log(avalibleAmount);
				Debug.Log(slot.item.maxAmount);
				Debug.Log(slot.amount);
				if (avalibleAmount >= amount)
				{
					slot.amount += amount;
				}
				else
				{
					slot.amount += avalibleAmount;
					amount -= avalibleAmount;
					break;
				}
				return;
			}
		}
		foreach (InventorySlot slot in inventorySlots)
		{
			if (slot.isEmpty) {
				
				int avalibleAmount = item.maxAmount;
				slot.item = item;
				if (avalibleAmount >= amount)
				{
					slot.amount = amount;
					slot.isEmpty = false;
					return;
				}
				else
				{
					slot.amount += avalibleAmount;
					amount -= avalibleAmount;
					slot.isEmpty = false;
				}
			}
		}
	}

	public virtual void Drop(InventorySlot slot)
	{
		if (slot != null && slot.amount > 0 && slot.item != null)
		{
			Item item = Instantiate(slot.item.itemPrefab, transform.position + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f)), Quaternion.identity).GetComponent<Item>();
			if (Input.GetKey(KeyCode.LeftShift))
			{
				item.amount = slot.amount;
				slot.item = null;
				slot.isEmpty = true;
				slot.amount = 0;
			} else
			{
				item.amount = 1;
				if (slot.amount == 1)
				{
					slot.item = null;
					slot.isEmpty = true;
					slot.amount = 0;
				}
				else
				{
					item.amount = 1;
					slot.amount--;
				}
			}
		}
	}
	public virtual void Remove(InventorySlot slot, int ammount)
	{
		slot.amount -= ammount;
		if (slot.amount < 1)
		{
			slot.item = null;
			slot.isEmpty = true;
		}
	}
}
