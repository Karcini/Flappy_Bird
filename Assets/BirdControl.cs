using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdControl : MonoBehaviour
{
    public float flapPower = 200.0f;
    //Remember gravity pulls down at 9.8 m/s^2
    
    private List<string> praise = new List<string>();
    public int score = 0;
    private int scoreChecker = 0;

    private AudioSource birdCrash;
    void Start()
    {
        praise.Add("Wow");
        praise.Add("Good Job!");
        praise.Add("Amazing");
        praise.Add("Good!");
        praise.Add("Keep it Up!");
        birdCrash = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Object requires the ability to receive force to use this
        //In other words, object attached must be a rigid body
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //This statement checks the current Velocity and makes it zero to not compound velocity per press
            gameObject.GetComponent<Rigidbody>().velocity = (Vector3.zero);
            
            //This statement adds force in the upward direction (1) and multiplies it by flap Power force
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * flapPower);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            print("Congrats, you got"+score+" points!");
            birdCrash.Play();
            Invoke("ReloadLevel",1);
        }

        if (other.gameObject.tag == "Pipe")
        {
            print("Congrats, you got "+score+" points!");
            birdCrash.Play();
            Invoke("ReloadLevel",1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            //score a point
            score++; scoreChecker++;
            if (scoreChecker == 5)
            {
                print(praise[Random.Range(0,4)]);
                scoreChecker = 0;
            }
        }
    }

    private void ReloadLevel()
    {
        Application.LoadLevel(("SampleScene"));
    }
    
}
