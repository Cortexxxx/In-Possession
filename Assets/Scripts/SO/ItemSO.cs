using UnityEngine;

public enum ItemType
{
	Default,
	Equipment,
	Clothes,
	Food
}
[CreateAssetMenu(fileName = "FoodItem", menuName = "Inventory/Items/New Item")]
public class ItemSO : ScriptableObject
{
	public string itemName;
	public Sprite itemIcon;
	public int maxAmount;
	public string itemDescription;
	public ItemType type;
	public GameObject itemPrefab;
	public bool canDropped;
	public bool canUsed;
}
