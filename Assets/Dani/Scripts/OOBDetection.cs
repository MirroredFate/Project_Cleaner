using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trash")
        {
            ObjectSpawnBehaviour spawner = other.gameObject.GetComponent<ObjectSpawnBehaviour>();
            other.transform.position = spawner.spawnPosition;
        }
    }



}
