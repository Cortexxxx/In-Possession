using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySlot : MonoBehaviour
{
	public InventorySlot slot;
	public TMP_Text amountText;
	public Image itemIcon;
	public int amount;
	public ItemSO item;
	private Button button;
	private void Update()
	{
		amount = slot.amount;
		item = slot.item;
	}
	private void OnEnable()
	{
		if (!button)
		{
			button = GetComponent<Button>();
		}
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(SetItemInfo);
	}
	private void SetItemInfo()
	{
		if (slot.item)
		{
			InventoryContainer inventoryContainer = InventoryContainer.instance;
			inventoryContainer.inventoryItemName.text = slot.item.itemName;
			inventoryContainer.inventoryItemDescription.text = slot.item.itemDescription;
			inventoryContainer.inventoryItemIcon.sprite = slot.item.itemIcon;
			inventoryContainer.inventoryItemIcon.color = Color.white;
			inventoryContainer.dropButton.gameObject.SetActive(slot.item.canDropped);
			inventoryContainer.useButton.gameObject.SetActive(slot.item.canUsed);
			inventoryContainer.useButton.onClick.RemoveAllListeners();
			inventoryContainer.dropButton.onClick.RemoveAllListeners();
			if (slot.item.canDropped)
			{
				inventoryContainer.dropButton.onClick.AddListener(() => Player.Instance.GetComponent<PlayerInventory>().Drop(slot));
			}
			if (slot.item.canUsed)
			{
				inventoryContainer.useButton.onClick.AddListener(() => slot.item.itemPrefab.GetComponent<Item>().Use());
				inventoryContainer.useButton.onClick.AddListener(() => Player.Instance.GetComponent<PlayerInventory>().Remove(slot, 1));
				Debug.Log("AddListener");
			}
			
			FoodItemSO foodItem = slot.item as FoodItemSO ? (FoodItemSO)slot.item : null;
			inventoryContainer.stats.SetActive(slot.item.type == ItemType.Food);
			// Если предмет изменяет статы
			if (foodItem)
			{
				inventoryContainer.healthStat.SetActive(foodItem.healthAmount != 0);
				inventoryContainer.staminaStat.SetActive(foodItem.staminaAmount != 0);
				inventoryContainer.mindStat.SetActive(foodItem.mindAmount != 0);
				string healOperator = foodItem.healthAmount < 0 ? "" : "+";
				inventoryContainer.healthStat.GetComponentInChildren<TextMeshProUGUI>().text = healOperator + foodItem.healthAmount.ToString();
				string staminaOperator = foodItem.staminaAmount < 0 ? "" : "+";
				inventoryContainer.staminaStat.GetComponentInChildren<TextMeshProUGUI>().text = staminaOperator + foodItem.staminaAmount.ToString();
				string mindOperator = foodItem.mindAmount < 0 ? "" : "+";
				inventoryContainer.mindStat.GetComponentInChildren<TextMeshProUGUI>().text = mindOperator + foodItem.mindAmount.ToString();
			}
		}
	}
}
