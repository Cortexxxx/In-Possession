using UnityEngine;
using UnityEngine.UI;

public class HUDContainer : MonoBehaviour
{
	public static HUDContainer Instance;
	public StatsBar healthBar;
	public StatsBar staminaBar;
	public StatsBar mindBar;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
