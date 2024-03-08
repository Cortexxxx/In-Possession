using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
	[SerializeField] private float lerpSpeed = 10f;
	private Slider slider;
	private float time;
	private float startValue;
	private float targetValue;
	private void Awake()
	{
		slider = GetComponent<Slider>();
	}
	private void Update()
	{
		time += lerpSpeed * Time.deltaTime;
		slider.value = Mathf.Lerp(startValue, targetValue, time);
	}
	public void Set(int value)
	{
		time = 0;
		targetValue = value;
		startValue = slider.value;
	}
}
