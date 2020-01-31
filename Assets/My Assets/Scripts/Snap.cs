using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour {

	public GameObject snappedObject;
	public GameObject objectToSnap;

	private void OnTriggerEnter(Collider other)
    {
        if (other == objectToSnap.GetComponent<Collider>())
        {
            snappedObject.SetActive(true);
			Destroy(objectToSnap);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
