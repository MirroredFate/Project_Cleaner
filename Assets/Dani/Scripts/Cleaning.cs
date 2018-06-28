using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour {

    [Range(0.1f, 1f)]
    public float cleaningSpeed = 0.5f;

    float alpha = 255f;

    bool isDragging;
    bool foundDirt;


	// Use this for initialization
	void Start () {

    }


    private void Update()
    {
        Clean();
    }


    private void Clean(Renderer rend)
    {
        Color color = rend.material.color;
        color.a -= Time.deltaTime * cleaningSpeed;
        rend.material.color = color;
    }
}
