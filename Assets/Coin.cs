using System;
using System.Collections;
using System.Collections.Generic;
//using System.Media;
using UnityEngine;
//using Pixelplacement;
    //removed folders

public class Coin : MonoBehaviour
{
    public float pipeSpeed = 1.0f;
    private AudioSource coinSound;
    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bird")
        {
            //Animation
            gameObject.transform.Translate(0,0,10);
            gameObject.GetComponent<CapsuleCollider>().transform.localScale = Vector3.zero;

            //Tween.LocalScale(transform, Vector3.one, Vector3.zero, 1.0f, 0.0f, Tween.EaseBounce);
                //bug, Currently removed line
                //This line results in point abuse, you can get coin multiple times before it vanishes
                
            //Sound
            coinSound.Play();
            
        }
    }
}
