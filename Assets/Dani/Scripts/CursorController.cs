using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour {

    public GameObject spongeSprite;
    public Sponge sponge;
    public DragAndDropV3 grab;
    public bool grabber = true;
    public bool cleaner = false;
    public Sprite grabSprite;
    public Sprite cleanerSprite;
    int spriteCount;

    Image sprite;

    [SerializeField]
    GameObject spriteObject;

    // Use this for initialization
    void Start () {
        sprite = spongeSprite.GetComponent<Image>();
        sprite.gameObject.SetActive(false);
        spriteCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //if (grabber && grab.isGrabbing)
        //{
        //    if(spriteCount < 1)
        //    {
        //        CreateSprite();
        //    }
        //    sprite.sprite = grabSprite;
        //    sprite.gameObject.SetActive(true);
        //}
        if(cleaner && sponge.isDragging)
        {
            if (spriteCount < 1)
            {
                CreateSprite();
            }
            sprite.sprite = cleanerSprite;
            sprite.gameObject.SetActive(true);
        }
        else
        {
            Destroy(spriteObject);
            spriteCount = 0;
        }
        
        if(spriteCount == 1)
        {
            spriteObject.transform.position = Input.mousePosition;
        }
    }

    private void CreateSprite()
    {
        spriteObject = Instantiate(spongeSprite, Input.mousePosition, Quaternion.identity, transform);
        //spriteObject.transform.localScale *= 10;
        //spriteObject.transform.parent = transform;
        sprite = spriteObject.GetComponent<Image>();
        spriteCount++;
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
