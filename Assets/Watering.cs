using TMPro;
using UnityEngine;

public class Watering : MonoBehaviour
{
	public GameObject parent;
	[SerializeField] Camera mainCamera;
	[SerializeField] new Collider2D collider;
	[SerializeField] int textureSize = 8;
	[SerializeField] Color waterColor;
	[SerializeField] SpriteRenderer waterRenderer;
	[SerializeField] TextMeshPro percentText;
	private Texture2D texture;
	public bool isWatered = false;
	private void OnEnable()
	{
		isWatered = false;
		texture = GetComponent<SpriteMask>().sprite.texture;
		texture.filterMode = FilterMode.Point;

		texture.Reinitialize(textureSize, textureSize);

		SetColor(texture, Color.clear);
		Texture2D waterTexture = waterRenderer.sprite.texture;
		SetColor(waterTexture, waterColor);
		percentText.text = FindProcentPaintedPixels() + "%";
	}
	private void SetColor(Texture2D texture, Color color)
	{
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				texture.SetPixel(i, j, color);
			}
		}
		texture.Apply();
	}
	private void Update()
	{

		if (Input.GetMouseButton(0))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
			if (hit)
			{
				DrawPixelInMousePosition(hit);
				percentText.text = FindProcentPaintedPixels() + "%";
			}
			if (FindProcentPaintedPixels() == 100)
			{
				isWatered = true;
			}
		}
	}
	private void DrawPixelInMousePosition(RaycastHit2D hit)
	{
		float downLeftX = transform.position.x - collider.bounds.size.x / 2;
		float downLeftY = transform.position.y - collider.bounds.size.y / 2;
		float topRightX = transform.position.x + collider.bounds.size.x / 2;
		float topRightY = transform.position.y + collider.bounds.size.y / 2;
		int x = (int)(Mathf.InverseLerp(downLeftX, topRightX, hit.point.x) * textureSize);
		int y = (int)(Mathf.InverseLerp(downLeftY, topRightY, hit.point.y) * textureSize);
		Debug.Log(texture.width);
		Debug.Log(texture.height);
		texture.SetPixel(x, y, Color.black);
		texture.Apply();
	}
	public float FindProcentPaintedPixels()
	{
		int width = texture.width;
		int height = texture.height;
		int paintedPixels = 0;
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				if (texture.GetPixel(x, y) == Color.black)
				{
					paintedPixels++;
				}
			}
		}
		Debug.Log(paintedPixels);
		return Mathf.Round((float)paintedPixels / (width * height) * 100);
	}
}