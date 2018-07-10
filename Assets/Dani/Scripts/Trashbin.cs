﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : MonoBehaviour {

    public Transform target;

    public ScoreManager scoreManager;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float zOffset = 0f;


    bool clicked = false;
    Vector3 linePos;

	// Use this for initialization
	void Start () {
        linePos = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z + zOffset);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }


        RaycastHit hit;

        Debug.DrawLine(linePos, target.position, Color.red);

        if (Physics.Linecast(linePos, target.position, out hit))
        {
            Debug.Log("blocked by: " + hit.transform.gameObject.name);
            if(clicked == false)
            {
                Debug.Log("giving you score... ");
                Destroy(hit.transform.gameObject);
                scoreManager.cleanedTrash += 1;
                scoreManager.score += 100;
                
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (clicked == false)  
        {
            if (other.tag == "Trash")
            {
                Debug.Log("Destroying Trash");
                Destroy(other.transform.gameObject);
                scoreManager.score += 100;
                scoreManager.cleanedTrash += 1;
            }
        }
    }
}
