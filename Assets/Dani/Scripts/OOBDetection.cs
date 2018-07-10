using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBDetection : MonoBehaviour {

   // public Collider oobDetection;

    Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
        spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaving the Zone");
        other.transform.position = spawnPosition;
    }
}
