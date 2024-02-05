using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float damping;
	[SerializeField] private Vector3 offset;
	private Vector3 velocity = Vector3.zero;
	private void FixedUpdate()
	{
		Vector3 movePosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
		transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
