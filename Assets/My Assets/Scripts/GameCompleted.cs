using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.Video;

public class GameCompleted : MonoBehaviour {

	public PostProcessingProfile profileToChangeTo;
	public VideoPlayer vid;
	public AudioSource trackOn;
	
	public AudioSource clock;

	private void OnTriggerEnter(Collider other)
	{
		other.GetComponentInChildren<PostProcessingBehaviour>().profile = profileToChangeTo;
		vid.Play();
		clock.Pause();
		trackOn.Play();
	}
}
