using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOpen : MonoBehaviour {

	private Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator>();

		// Updates the animator during the physic loop in order to
		// have the animation system synchronized with the physics engine.
		animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
	}

	void OnMouseUp ()
	{
		animator.SetBool("open", !animator.GetBool("open"));
	}
}