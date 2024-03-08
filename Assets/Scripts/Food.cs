using UnityEngine;

public class Food : Item
{
	public override void Use()
	{
		base.Use();
		FoodItemSO foodItem = (FoodItemSO)itemSO;
		PlayerStats playerStats = Player.Instance.GetComponent<PlayerStats>();
		playerStats.Health += foodItem.healthAmount;
		playerStats.Stamina += foodItem.staminaAmount;
		playerStats.Mind += foodItem.mindAmount;
	}
}
