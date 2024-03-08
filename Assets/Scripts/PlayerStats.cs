using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	private HUDContainer hudContainer;
	[SerializeField] private int health = 50;
	private int stamina = 50;
	private int mind = 50;
	[SerializeField] private int maxHealth = 100;
	private int maxStamina = 100;
	private int maxMind = 100;
	public bool IsDead { get; private set; } = false;
	public bool IsDrowsy { get; private set; } = false;
	public bool IsMad { get; private set; } = false;
	private void Start()
	{
		hudContainer = HUDContainer.Instance;
		hudContainer.healthBar.Set(health);
		hudContainer.mindBar.Set(mind);
		hudContainer.staminaBar.Set(stamina);
	}
	public int Health
	{
		get { return health; }
		set {
			health = Mathf.Clamp(value, 0, maxHealth);
			hudContainer.healthBar.Set(health);
			if (Health == 0)
			{
				IsDead = true;
			}
		}
	}
	public int Stamina
	{
		get { return stamina; }
		set
		{
			stamina = Mathf.Clamp(value, 0, maxStamina);
			hudContainer.staminaBar.Set(stamina);
			if (stamina == 0)
			{
				IsDrowsy = true;
			}
		}
	}
	public int Mind
	{
		get { return mind; }
		set
		{
			mind = Mathf.Clamp(value, 0, maxMind);
			hudContainer.mindBar.Set(mind);
			if (mind == 0)
			{
				IsMad = true;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Health -= 15;
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			Health += 15;
		}
	}
}
