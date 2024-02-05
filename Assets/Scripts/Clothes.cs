using UnityEngine;

public class Clothes : MonoBehaviour
{
	public enum ClothesType
	{
		Body,
		Head,
		Legs,
		Boots
	}
	private string[] sides = new string[] { "down", "top", "left", "right" };
	private string animsPath = "Animations/Clothes";
	private Animator animator;
	private AnimatorOverrideController animatorOverrideController;
	private AnimationClipOverrides clipOverrides;

	public void Start()
	{
		animator = GetComponent<Animator>();

		animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
		animator.runtimeAnimatorController = animatorOverrideController;
		clipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
		animatorOverrideController.GetOverrides(clipOverrides);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SetClothes(ClothesType.Body, "Rags");
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			SetClothes(ClothesType.Body, "SerfShirt");
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			SetClothes(ClothesType.Head, "Blackhair");
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			SetClothes(ClothesType.Legs, "KhakiPants");
		}

	}
	public void SetClothes(ClothesType type, string clothesName)
	{
		AnimationClipOverrides updatedClipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
		updatedClipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
		animatorOverrideController.GetOverrides(updatedClipOverrides);
		for (int state = 0; state < Player.statesAmmount; state++)
		{
			for (int side = 0; side < sides.Length; side++)
			{
				string stateString = ((Player.States)state).ToString().ToLower();
				string typeString = type.ToString().ToLower();
				string animationName = $"{clothesName.ToLower()}_{stateString}_{sides[side]}";
				string currentName = $"{typeString}_empty_{((Player.States)state).ToString().ToLower()}_{sides[side]}";
				string fullAnimationPath = $"{animsPath}/{type}/{clothesName}/{animationName}";
				Debug.Log(fullAnimationPath);
				updatedClipOverrides[currentName] = Resources.Load<AnimationClip>(fullAnimationPath);
			}
		}
		animatorOverrideController.ApplyOverrides(updatedClipOverrides);
		animator.runtimeAnimatorController = animatorOverrideController;
	}

	/// <summary> Used to Put off player clothes on the "type param" part </summary>
	private void PutClothesOff(ClothesType type)
	{
		string baseAnimationName = $"{type.ToString().ToLower()}_empty";
		for (int state = 0; state < Player.statesAmmount; state++)
		{
			for (int side = 0; side < sides.Length; side++)
			{
				string animationName = $"{baseAnimationName}_{(Player.States)state}_{sides[side]}";
				clipOverrides[animationName] = Resources.Load<AnimationClip>($"{animsPath}/{type}/{animationName}");
			}
		}
		animatorOverrideController.ApplyOverrides(clipOverrides);
	}
}
 