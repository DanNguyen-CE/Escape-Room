using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour {

	public Animator exitDoor; // Door Animator
	public string correctCode = "";
	public Text textbox;

	public AudioSource openSound;

	void Update()
	{
		if (Keys.keyDown != "Enter"){
			textbox.text += Keys.keyDown;
			Keys.keyDown = "";
		} else {
			checkCode();
			Keys.keyDown = "";
		}
	}

	void checkCode()
	{
		if(textbox.text == correctCode){
			textbox.text = "CORRECT!";
			exitDoor.SetBool("open", true); // Open Door
			openSound.Play();
		} else {
			textbox.text = "";
		}
	}
}
