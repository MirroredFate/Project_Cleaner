using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private bool mouseState;
    private bool IsColliding = false;
    private Vector3 lastPos;

    public GameObject Target;
    public Vector3 screenSpace;
    public Vector3 offset;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Target == GetClickedObject(out hitInfo))
            {
                mouseState = true;
                screenSpace = Camera.main.WorldToScreenPoint(Target.transform.position);
                offset = Target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseState = false;
        }
        if (mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world

            if(IsColliding == false)
            {
                Target.transform.position = curPosition;

            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        lastPos = Target.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        IsColliding = true;
        Target.transform.position = lastPos;
    }

    private void OnTriggerExit(Collider other)
    {
        IsColliding = false;
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
