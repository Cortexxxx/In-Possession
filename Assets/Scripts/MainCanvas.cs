using UnityEngine;

public class MainCanvas : MonoBehaviour
{
	public static MainCanvas instance;
	public GameObject interactSpan;
	public GameObject interactButtonText;
	public GameObject plantChoosingPanel;
	public GameObject watering;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
