using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
	public enum Type
	{
		Item,
		Door,
		Other
	}
	public Type type;
	public bool canInteract = true;
	public virtual void OnInteract() {
		if (!canInteract)
		{
			return;
		}
	}
}
