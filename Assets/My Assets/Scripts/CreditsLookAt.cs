using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLookAt : MonoBehaviour {

    public Transform target;

    void Update()
    {
        // Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z) ;
        this.transform.LookAt(target);
        transform.Rotate(new Vector3(90f,0,0));
    }
}