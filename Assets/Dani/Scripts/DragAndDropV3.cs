using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropV3 : MonoBehaviour {

    GameObject gObj = null;
    Plane objPlane;
    Vector3 lastPos;
    Vector3 velocity;
    Vector3 m0;

    Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);

        return mr;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = GenerateMouseRay();
            RaycastHit hit;

            if(Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit) && hit.transform.gameObject.tag == "Trash")
            {
                gObj = hit.transform.gameObject;
                gObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                objPlane = new Plane(Vector3.up, gObj.transform.position);

                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                objPlane.Raycast(mRay, out rayDistance);
                m0 = gObj.transform.position - mRay.GetPoint(rayDistance);
            }
        }    	
        else if (Input.GetMouseButton(0) && gObj)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if(objPlane.Raycast(mRay, out rayDistance))
            {
                gObj.transform.position = mRay.GetPoint(rayDistance) + m0;
                velocity = gObj.transform.position - lastPos;
                lastPos = gObj.transform.position;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            gObj.GetComponent<Rigidbody>().AddForce(velocity * 1000);
            gObj = null;
        }
	}
}
