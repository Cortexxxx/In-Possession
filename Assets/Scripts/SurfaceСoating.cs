using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceСoating : MonoBehaviour
{
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>())
		{
			collision.GetComponent<PlayerMovement>().currentSpeed++;
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() && collision.GetComponent<PlayerMovement>().currentSpeed == collision.GetComponent<PlayerMovement>().speed)
		{
			collision.GetComponent<PlayerMovement>().currentSpeed--;
		}
	}
}
