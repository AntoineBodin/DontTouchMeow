using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeIndicator
{

	private GameObject sphere;

	public SwipeIndicator(GameObject _sphere)
	{
		sphere = _sphere;
		sphere.SetActive(false);
	}

	public void Start()
	{
		sphere.SetActive(true);
	}

	public void Start(Vector2 position)
	{
		sphere.SetActive(true);
		sphere.transform.position = position;
		sphere.GetComponent<TrailRenderer>().Clear();
	}

	public void Swipe(Vector2 newPos)
	{
		sphere.transform.position = newPos;
	}

	public void Stop()
	{
		sphere.GetComponent<TrailRenderer>().Clear();
		sphere.SetActive(false);
	}
}
