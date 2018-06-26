using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : MonoBehaviour {

    public Transform target;

    public ScoreManager scoreManager;

    bool clicked = false;

	// Use this for initialization
	void Start () {
		
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

        Debug.DrawLine(transform.position, target.position, Color.red);

        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            Debug.Log("blocked by: " + hit.transform.gameObject.name);
            if(clicked == false)
            {
                Destroy(hit.transform.gameObject);
                scoreManager.score += 100;
            }

        }
    }
}
