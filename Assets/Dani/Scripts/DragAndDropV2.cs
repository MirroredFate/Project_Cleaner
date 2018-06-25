using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropV2 : MonoBehaviour {

    Vector3 gameObjectScreenPoint;
    Vector3 mousePreviousLocation;
    Vector3 mouseCurLocation;
    Vector3 force;
    Vector3 objectCurrentPosition;
    Vector3 objectTargetPosition;
    public float topSpeed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This prevents your thrown object from ascending to infinity and beyond. Disable if you're trying to throw Buzz Lightyear.
        if (force.y > 0.0f)
        {
            force.y -= 0.01f;
        }
    }
    
    void OnMouseDown()
    {
        //This grabs the position of the object in the world and turns it into the position on the screen
        gameObjectScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //Sets the mouse pointers vector3
        mousePreviousLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectScreenPoint.z);
    }

    
    void OnMouseDrag()
    {
        mouseCurLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectScreenPoint.z);
        force = mouseCurLocation - mousePreviousLocation;//Changes the force to be applied
        mousePreviousLocation = mouseCurLocation;
    }

    public void OnMouseUp()
    {
        //Makes sure there isn't a ludicrous speed
        if (GetComponent<Rigidbody>().velocity.magnitude > topSpeed)
            force = GetComponent<Rigidbody>().velocity.normalized * topSpeed;
    }

    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = force;
    }

}
