using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : MonoBehaviour {

    public Transform target;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        Debug.DrawLine(transform.position, target.position, Color.red);

        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            Debug.Log("blocked by: " + hit.transform.gameObject.name);
        }
    }
}
