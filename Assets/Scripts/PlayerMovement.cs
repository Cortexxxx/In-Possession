using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] public float speed;
	public float currentSpeed;
	private Rigidbody2D rb;
	private Animator animator;
	private Vector3 direction;
	[HideInInspector] public bool isMoving = false;
	private bool canMove = true;
	private void OnEnable()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		currentSpeed = speed;
	}
	private void FixedUpdate()
	{
		if (canMove)
		{
			direction.x = Input.GetAxisRaw("Horizontal");
			direction.y = Input.GetAxisRaw("Vertical");
			if (direction != Vector3.zero)
			{
				isMoving = true;
			}
			else
			{
				isMoving = false;
			}
			animator.SetBool("Moving", isMoving);
			if (direction != Vector3.zero)
			{
				animator.SetFloat("Horizontal", direction.x);
				animator.SetFloat("Vertical", direction.y);
			}
		}

	}
	private void Update()
	{
		if (isMoving && canMove)
		{
			direction = direction.normalized;
			rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime);
		}
	}
	private void SetStepSounds()
	{

	}
	public void ToggleMovement()
	{
		canMove = !canMove;
		animator.SetBool("Moving", false);
	}


}
