using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class PatchPart : Interactable
{
    public enum Plants
    {
        None,
        Wheat,
        Corn,
        Sunflower
    }
	[SerializeField] private float timeFromLastStage = 0;
	[SerializeField] private PlantSO currentPlant;
	[SerializeField] private int growStage = 0;
	[SerializeField] private bool isPlantGrown = false;
	[SerializeField] private bool needToBeWatered = true;
	[SerializeField] private SpriteRenderer plantSprite;
	private void Update()
    {
        if (currentPlant && !needToBeWatered && !isPlantGrown)
        {
            if (growStage < currentPlant.maxStages && timeFromLastStage > currentPlant.stageGrowTime)
            {
                MoveToNextStage();
				isPlantGrown = growStage == currentPlant.maxStages;

			}
			timeFromLastStage += Time.deltaTime;
        }
        if (isPlantGrown && !canInteract)
        {
			canInteract = true;
		}
    }

    private IEnumerator Water()
    {
		canInteract = false;
		Player player = Player.Instance;
		Animator playerAnimator = player.GetComponent<Animator>();
		PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
		playerMovement.ToggleMovement();
		playerAnimator.SetBool("isWatering", true);
		playerAnimator.SetTrigger("Water");
		Watering watering = MainCanvas.instance.watering.GetComponentInChildren<Watering>();
		watering.parent.SetActive(true);
		yield return new WaitUntil(() => watering.isWatered);
		watering.parent.SetActive(false);
		playerAnimator.SetBool("isWatering", false);
		needToBeWatered = false;
		playerMovement.ToggleMovement();
	}

	private void MoveToNextStage()
    {
        growStage++;
        timeFromLastStage = 0;
        plantSprite.sprite = currentPlant.stagesSprites[growStage - 1];
    }

    public void CollectHarvest()
    {
        // Inventory.Add(Plant)
        canInteract = true;
		growStage = 0;
        needToBeWatered = true;
        timeFromLastStage = 0;
        isPlantGrown = false;
        plantSprite.sprite = null;
        currentPlant = null;
	}

    public void Plant(Plants plant)
    {
        if (!currentPlant)
        {
			currentPlant = Resources.LoadAll<PlantSO>("ScriptableObjects/Plants").Where(x => x.plant == plant).First();
            MoveToNextStage();
		}
    }
    public override void OnInteract()
    {
        base.OnInteract();
        if (currentPlant) {
			if (isPlantGrown)
			{
				CollectHarvest();
			} else if (needToBeWatered)
			{
				StartCoroutine(Water());
			}
		} else
		{
			MainCanvas.instance.plantChoosingPanel.SetActive(true);
			Player.Instance.GetComponent<PlayerMovement>().ToggleMovement();
			MainCanvas.instance.plantChoosingPanel.GetComponent<PlantChoose>().currentPatch = this;
		}
	}
}
