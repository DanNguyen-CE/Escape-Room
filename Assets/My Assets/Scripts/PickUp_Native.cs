using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Native : MonoBehaviour {

	public float throwForce = 600f;
	public float maxDistance = 4f;
	
	GameObject tempParent;
	bool isHolding = false;
	Vector3 objectPos;
	float distance;
	
	void Start()
	{
		tempParent = GameObject.Find("Guide");
	}

	void Update ()
	{
		distance = Vector3.Distance(transform.position, tempParent.transform.position);
		
		if(distance > maxDistance) {
			isHolding = false;
		}

		//Check if isHolding
		if(isHolding == true) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			transform.SetParent(tempParent.transform);

			if(Input.GetMouseButtonDown(1)) {
				GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
				isHolding = false;
			}
		} else {
				objectPos = transform.position;
				transform.SetParent(null);
				GetComponent<Rigidbody>().useGravity = true;
				transform.position = objectPos;
			}
	}

	void OnMouseDown ()
	{
		if(distance <= maxDistance) {
			isHolding = true;
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().detectCollisions = true;	
		}
	}

	void OnMouseUp ()
	{
		isHolding = false;
	}
}
