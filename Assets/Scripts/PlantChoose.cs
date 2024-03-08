using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantChoose : MonoBehaviour
{
	[SerializeField] private GameObject plantList;
	[SerializeField] private GameObject plantItem;
	[HideInInspector] public PatchPart currentPatch;
	private void OnEnable()
	{

		PlantSO[] plants = Resources.LoadAll<PlantSO>("ScriptableObjects/Plants");
		Button[] plantItems = plantList.GetComponentsInChildren<Button>();
		for (int i = 0; i < plantItems.Length; i++)
		{
			Destroy(plantItems[i].gameObject);
		}
		PlayerMovement playerMovement = Player.Instance.GetComponent<PlayerMovement>();
		for (int i = 0; i < plants.Length; i++)
		{
			GameObject item = Instantiate(plantItem, plantList.transform);
			item.GetComponentInChildren<TextMeshProUGUI>().text = plants[i].plantName;
			item.GetComponentsInChildren<Image>()[1].sprite = plants[i].plantIcon;
			Debug.Log(plants[i].plant);
			int index = i;
			Button itemButton = item.GetComponent<Button>();
			itemButton.onClick.AddListener(() => currentPatch.Plant(plants[index].plant));
			itemButton.onClick.AddListener(() => playerMovement.ToggleMovement());
			itemButton.onClick.AddListener(() => gameObject.SetActive(false));
		}
	}
}
