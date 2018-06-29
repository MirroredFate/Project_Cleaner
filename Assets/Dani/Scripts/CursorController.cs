using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour {

    public GameObject spongeSprite;
    public Sponge sponge;
    public DragAndDrop grab;
    public bool grabber = true;
    public bool cleaner = false;
    public Sprite grabSprite;
    public Sprite cleanerSprite;

    Image sprite;

    // Use this for initialization
    void Start () {
        sprite = spongeSprite.GetComponent<Image>();
        sprite.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (grabber && grab.isGrabbing)
        {
            sprite.sprite = grabSprite;
            sprite.gameObject.SetActive(true);
        }
        else if(cleaner && sponge.isDragging)
        {
            sprite.sprite = cleanerSprite;
            sprite.gameObject.SetActive(true);
        }
        else
        {
            sprite.gameObject.SetActive(false);
        }
        

        spongeSprite.transform.position = Input.mousePosition;
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
