using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InactiveOnClick : MonoBehaviour, IPointerDownHandler {

	public GameObject image;

	public void OnPointerDown (PointerEventData eventData)
	{
		image.SetActive(false);
	}
}
