using UnityEngine;

public class Player : MonoBehaviour
{
	public enum States
	{
		Idle,
		Walk
	}
	public static int statesAmmount { get; private set; }
	public static Player Instance { get; private set; }
	public Transform sortingTransform;
	public new Renderer renderer;
	private void Start()
	{
		statesAmmount = 2;
	}
	private void Awake()
	{
		if (!Instance)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
