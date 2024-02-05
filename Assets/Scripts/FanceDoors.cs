using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FanceDoors : Interactable
{
	[SerializeField] private Collider2D[] colliders;
	private Animator animator;
	public bool isOpened;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public override void OnInteract()
	{
		base.OnInteract();
		Toggle(!animator.GetBool("Opened"));
	}
	private void Toggle(bool toggle)
	{
		animator.SetBool("Opened", toggle);
		isOpened = toggle;
		StartCoroutine(ToggleColliders(toggle));
	}
	private IEnumerator ToggleColliders(bool toggle)
	{
		yield return new WaitForSeconds(1);
		foreach (var collider in colliders)
		{
			collider.isTrigger = toggle;
		}
	} 

}
