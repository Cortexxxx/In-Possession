using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Inventory/Items/New Food Item")]
public class FoodItem : ItemSO
{
	public float healAmount;
	public float staminaAmount;
	private void Awake()
	{
		type = ItemType.Food;
	}
}
