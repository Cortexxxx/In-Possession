using UnityEngine;
public enum ItemType
{
	Default,
	Equipment,
	Clothes,
	Food
}
public class ItemSO : ScriptableObject
{
	public string itemName;
	public int maxAmount;
	public string itemDescription;
	public ItemType type;
	public GameObject itemPrefab;
}
