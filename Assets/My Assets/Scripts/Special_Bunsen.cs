using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Bunsen : MonoBehaviour {

	Animator animator;
	public float maxDistance = 5f;
	float distance;
	GameObject tempParent;

	public GameObject tube;
	public GameObject flames;

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
		if(distance <= maxDistance && tube.activeInHierarchy) {
			animator.SetBool("open", !animator.GetBool("open"));
			flames.SetActive(!flames.activeInHierarchy);
		}
	}
}