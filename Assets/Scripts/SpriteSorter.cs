using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
	[SerializeField] private Transform sorterPoint;
	private new Renderer renderer;
	private PlayerMovement playerMovement;
	private Player player;
	private void Start()
	{
		renderer = GetComponentInParent<Renderer>();
		player = Player.Instance;
		playerMovement = Player.Instance.GetComponent<PlayerMovement>();
	}
	private void Update()
	{
		if (playerMovement.isMoving)
		{
			if (player.sortingTransform.position.y <= sorterPoint.position.y)
			{
				renderer.sortingOrder = player.renderer.sortingOrder - 1;
			} else
			{
				renderer.sortingOrder = player.renderer.sortingOrder + 4;
			}
		}
	}
}
