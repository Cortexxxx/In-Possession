using System.Collections.Generic;
using UnityEngine;

public class StepsSoundManager
{
	string stepsFolder = "Sounds/Steps";
	public enum SurfaceType
	{
		Grass,
		Wood,
		Cobblestone,
		Dirt
	}
	private List<string> surfaceNames = new List<string>() { 
		"Grass", "Wood", "Cobblestone", "Dirt"
	};
	public void SetSound(AudioSource audioSource, SurfaceType type)
	{
		switch (type)
		{
			case SurfaceType.Grass:
				AudioClip[] clips = Resources.LoadAll<AudioClip>($"{stepsFolder}/Grass");
				audioSource.clip = clips[Random.Range(0, clips.Length)];
				break;
			case SurfaceType.Wood:
				clips = Resources.LoadAll<AudioClip>($"{stepsFolder}/Wood");
				audioSource.clip = clips[Random.Range(0, clips.Length)];
				break;
			case SurfaceType.Cobblestone:
				clips = Resources.LoadAll<AudioClip>($"{stepsFolder}/Cobblestone");
				audioSource.clip = clips[Random.Range(0, clips.Length)];
				break;
			case SurfaceType.Dirt:
				clips = Resources.LoadAll<AudioClip>($"{stepsFolder}/Dirt");
				audioSource.clip = clips[Random.Range(0, clips.Length)];
				break;
		}
	}
}
