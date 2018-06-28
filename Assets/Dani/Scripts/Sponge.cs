using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {

    public ScoreManager scoreManager;
    public CursorController cursorController;

    [Range(0.1f, 1f)]
    public float cleaningSpeed = 0.5f;

    float alpha = 255f;
    bool isDragging = false;
    bool foundDirt;
    GameObject target;


    // Use this for initialization
    void Start () {
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
            {
                target = hit.collider.gameObject;
                isDragging = true;
            }
        }

        if (isDragging && cursorController.cleaner)
        {
            Renderer renderer = target.GetComponent<Renderer>();
            cursorController.spongeSprite.transform.position = Input.mousePosition;
            cursorController.spongeSprite.SetActive(true);
            Clean(renderer);
        }

        if (!cursorController.cleaner)
        {
            cursorController.spongeSprite.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }


    }

    private void Clean(Renderer rend)
    {
        Color color = rend.material.color;
        color.a -= Time.deltaTime * cleaningSpeed;
        rend.material.color = color;
        Debug.Log("Alpha: " + color.a);

        if (color.a <= 0f)
        {
            Destroy(rend.gameObject);
            scoreManager.score += 100;
        }
    }

}
