using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacklight : MonoBehaviour {

	public Material reveal;
	public Light _light;
	
	void Update () {
		reveal.SetVector("_LightPosition", _light.transform.position);
		reveal.SetVector("_LightDirection", -_light.transform.forward);
		reveal.SetFloat("_LightAngle", _light.spotAngle);
	}
}
