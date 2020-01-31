using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskExplode : MonoBehaviour {

	public GameObject splatters, objectToSnap, active, explosion;
    public AudioSource explosionSound;

	private void OnTriggerEnter(Collider other)
    {
        if (other == objectToSnap.GetComponent<Collider>() && active.activeInHierarchy == true)
        {
            splatters.SetActive(true);
            explosion.SetActive(true);
            explosion.GetComponent<ParticleSystem>().Play();
            explosionSound.Play();
			Destroy(objectToSnap);
            Destroy(explosion, 2f);
            Destroy(this.gameObject, 2.1f);
        }
    }
}
