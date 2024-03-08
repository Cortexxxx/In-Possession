using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interacting : MonoBehaviour
{
	[SerializeField] private GameObject interactingPanel;
	[HideInInspector] public Interactable interactingObject;
    private KeyCode interactKey = KeyCode.E;
    private delegate void InteractDelegate();
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
			if (interactable && interactable.canInteract)
			{
				interactables.Add(interactable);
			}
		}
		if (interactables.Count > 0)
		{
			RemoveAllListeners();
			Interactable closestInteractable = interactables[0];
			foreach (var interactable in interactables)
			{
                if (Vector2.Distance(transform.position, interactable.gameObject.transform.position) < 
					Vector2.Distance(transform.position, closestInteractable.gameObject.transform.position) && interactable.canInteract) {
					closestInteractable = interactable;
				}
			}
			interactingPanel.SetActive(true);
			MainCanvas.instance.interactButtonText.GetComponent<TextMeshProUGUI>().text = interactKey.ToString();
            SetListener(closestInteractable.OnInteract);
        }
		else
		{
			RemoveAllListeners();
			interactingPanel.SetActive(false);
		}
	}

}
