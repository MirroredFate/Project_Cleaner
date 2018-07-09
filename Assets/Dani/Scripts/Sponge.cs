using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {

    public ScoreManager scoreManager;
    public CursorController cursorController;
    public PhoneBehaviour Intro;
    public TimerBehaviour gameOver;

    [Range(0.1f, 1f)]
    public float cleaningSpeed = 0.5f;

    public bool isDragging = false;

    GameObject target;


    // Use this for initialization
    void Start () {
    }


    private void Update()
    {
        if (!Intro.intro && !gameOver.gameOver)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
                {
                    if (hit.transform.tag == "Dirt")
                    {
                        target = hit.collider.gameObject;
                        isDragging = true;
                    }

                }
            }

            if (isDragging && cursorController.cleaner)
            {
                Renderer renderer = target.GetComponent<Renderer>(); ;
                Clean(renderer);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
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
            isDragging = false;
        }
    }

}
