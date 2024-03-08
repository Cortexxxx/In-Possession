using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContainer : MonoBehaviour
{
	public static InventoryContainer instance;
	public Button dropButton;
	public Button useButton;
	public GameObject healthStat;
	public GameObject staminaStat;
	public GameObject mindStat;
	public GameObject buttonsAndStats;
	public GameObject stats;
	public TMP_Text inventoryItemName;
	public TMP_Text inventoryItemDescription;
	public Image inventoryItemIcon;
	public Transform inventoryPanel;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			gameObject.SetActive(false);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
