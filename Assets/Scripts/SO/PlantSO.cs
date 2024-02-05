using UnityEngine;
[CreateAssetMenu(fileName = "Plant", menuName = "PlantSO", order = 0)]
public class PlantSO : ScriptableObject
{

    public float stageGrowTime;
    public PatchPart.Plants plant;
    public string plantName;
	public Sprite[] stagesSprites;
	public Sprite plantIcon;
	public int maxStages;
}
