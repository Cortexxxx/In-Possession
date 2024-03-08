using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Inventory/Items/New Food Item")]
public class FoodItemSO : ItemSO
{
	public int healthAmount;
	public int staminaAmount;
	public int mindAmount;
	private void Awake()
	{
		type = ItemType.Food;
	}
}
