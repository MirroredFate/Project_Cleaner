﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private bool _mouseState;

    //[HideInInspector]
    public bool isGrabbing = false;

    public PhoneBehaviour Intro;
    public TimerBehaviour gameOver;
    public Vector3 screenSpace;
    public Vector3 offset;
    public CursorController cursorController;

    GameObject target = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Intro.intro && !gameOver.gameOver)
        {
            // Debug.Log(_mouseState);
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
                {
                    target = hit.collider.gameObject;
                    if (target.tag == "Trash")
                    {
                        _mouseState = true;
                        screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                        offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                    }
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                _mouseState = false;
                isGrabbing = false;
            }
            if (_mouseState && cursorController.grabber)
            {
                isGrabbing = true;
                //keep track of the mouse position
                var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

                //convert the screen mouse position to world point and adjust with offset
                var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

                //update the position of the object in the world
                target.transform.position = curPosition;
            }
        }
    }

}
