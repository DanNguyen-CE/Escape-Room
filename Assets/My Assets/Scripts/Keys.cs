using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

	public static string keyDown;

	public float maxDistance = 4.0f;
	
	GameObject tempParent;
	float distance;

	void Start()
	{
		tempParent = GameObject.Find("Guide");
	}

	void Update()
	{
		distance = Vector3.Distance(transform.position, tempParent.transform.position);
	}

	void OnMouseUp()
	{
		if(distance <= maxDistance)
			keyDown = this.name;
	}
}
