using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Water : MonoBehaviour {

	Animator animator;
	public float maxDistance = 5f;
	float distance;
	GameObject tempParent;

	public GameObject otherHandle;
	public GameObject water;

	void Start () {
		animator = GetComponent<Animator>();
		tempParent = GameObject.Find("Guide");
	}
	
	void Update () 
	{
		distance = Vector3.Distance(transform.position, tempParent.transform.position);
	}

	void OnMouseUp ()
	{
		if(distance <= maxDistance && otherHandle.transform.rotation.z == 0.0f) {
			animator.SetBool("open", !animator.GetBool("open"));
			water.SetActive(!water.activeInHierarchy);

		} else if (distance <= maxDistance) {
			animator.SetBool("open", !animator.GetBool("open"));
		}
	}
}
