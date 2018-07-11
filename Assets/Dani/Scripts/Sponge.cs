using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {

    public ScoreManager scoreManager;
    public CursorController cursorController;
    public PhoneBehaviour Intro;
    public TimerBehaviour gameOver;

    public GameObject floatUpText;
    public GameObject canvas;

    [Range(0.1f, 1f)]
    public float cleaningSpeed = 0.5f;

    public bool isDragging = false;

    GameObject target;


    // Use this for initialization
    void Start () {
    }


    private void Update()
    {
        if (!Intro.intro && !gameOver.gameOver && cursorController.cleaner)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction * 100, out hit))
                {
                    //Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.tag == "Dirt")
                    {
                        //Debug.Log("Dreck!");
                        target = hit.collider.gameObject;
                        isDragging = true;
                    }

                }
            }

            if (isDragging)
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
        //Debug.Log("Alpha: " + color.a);

        if (color.a <= 0f)
        {
            SpawnText();
            Destroy(rend.gameObject);
            scoreManager.score += 100;
            scoreManager.cleanedTrash++;
            isDragging = false;
        }
    }

    void SpawnText()
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(target.transform.position);
        GameObject UI_Text = Instantiate(floatUpText, screenPoint, Quaternion.identity) as GameObject;
        UI_Text.transform.SetParent(canvas.transform);
        //UI_Text.GetComponent<RectTransform>().anchoredPosition = screenPoint - this.GetComponent<RectTransform>().sizeDelta / 2f;
    }

}
