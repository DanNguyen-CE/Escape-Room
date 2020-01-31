using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour{

	public Animator animator;

	public void PlayGame ()
	{
		animator.SetTrigger("Play");
	}

	public void QuitGame ()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}
