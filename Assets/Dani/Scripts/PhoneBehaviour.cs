using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PhoneBehaviour : MonoBehaviour {

    public Animator phoneAnimator;
    public GameObject phoneObject;
    public GameObject introText;

    //[HideInInspector]
    public bool intro = true;

    bool textTimer;
    float textTime;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if(phoneAnimator != null && intro)
        {
            AnimatorClipInfo[] clipInfo = phoneAnimator.GetCurrentAnimatorClipInfo(0);

            if (clipInfo[0].clip.name == "PhoneDelete")
            {
                Destroy(phoneObject);
                introText.SetActive(true);
                textTimer = true;
            }
        }

        if (textTimer)
        {
            textTime += Time.deltaTime;

            if(textTime >= 5f)
            {
                Destroy(introText);
                intro = false;
            }
        }
    }

    public void ClosePhone()
    {
        phoneAnimator.SetBool("Closing", true);
    }
}
