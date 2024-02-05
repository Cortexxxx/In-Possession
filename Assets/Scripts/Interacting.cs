using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interacting : MonoBehaviour
{
	[HideInInspector] public Interactable interactingObject;
    protected KeyCode interactKey = KeyCode.E;
    private delegate void InteractDelegate();
    private GameObject interactSpan;
    private InteractDelegate interactDelegate { get; set; }
    private void SetListener(InteractDelegate interactDelegate)
    {
		RemoveAllListeners();

		this.interactDelegate += interactDelegate;
    }
	private void RemoveAllListeners()
	{
		interactDelegate = null;
	}
    private void Update()
    {
		if (Input.GetKeyDown(interactKey) && interactDelegate != null)
		{
            interactDelegate.Invoke();
        }
    }
    private void FixedUpdate()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one / 2, 0);
		List<Interactable> interactables = new List<Interactable>();
		foreach (var collider in colliders)
		{
			Interactable interactable = collider.GetComponent<Interactable>();
			if (interactable)
			{
				interactables.Add(interactable);
			}
		}
        interactSpan = MainCanvas.instance.interactSpan;
		if (interactables.Count > 0 && interactables[0].canInteract)
		{
			RemoveAllListeners();
			Interactable closestInteractable = interactables[0];
			foreach (var interactable in interactables)
			{
                if (Vector2.Distance(transform.position, interactable.gameObject.transform.position) < 
					Vector2.Distance(transform.position, closestInteractable.gameObject.transform.position) && interactable.canInteract) 
					{
						closestInteractable = interactable;
					}
			}
            interactSpan.SetActive(true);
			MainCanvas.instance.interactButtonText.GetComponent<TextMeshProUGUI>().text = interactKey.ToString();
            SetListener(closestInteractable.OnInteract);
        }
		else
		{
			RemoveAllListeners();
            interactSpan.SetActive(false);
		}
	}

}
