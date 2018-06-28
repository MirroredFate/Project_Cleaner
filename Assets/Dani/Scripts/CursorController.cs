using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

    public GameObject spongeSprite;
    public bool grabber = true;
    public bool cleaner = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GrabIconClick()
    {
        grabber = true;
        cleaner = false;
    }

    public void CleanerIconClick()
    {
        grabber = false;
        cleaner = true;
    }
}
