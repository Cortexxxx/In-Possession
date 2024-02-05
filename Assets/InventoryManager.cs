using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	[SerializeField] private Transform inventoryPanel;
	[SerializeField] private GameObject inventoryParent;
	[SerializeField] private List<InventorySlot> inventorySlots = new List<InventorySlot>();
	private bool isOpened = false;
	private void Start()
	{
		inventorySlots = inventoryPanel.GetComponentsInChildren<InventorySlot>().ToList();
		inventoryParent.SetActive(false);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			isOpened = !isOpened;
			inventoryParent.SetActive(isOpened);
		}
	}
}
