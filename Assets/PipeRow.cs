using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeRow : MonoBehaviour
{
    public float pipeSpeed = 1.0f;
    void Start()
    {
        
    }

    //Careful, update will be run as often as your computer can
    //If you run on a good computer, it's not fair for the update to run quicker on other people than slower
    //This is where the time declaration comes in "Time.deltaTime"
        //represents the time difference between 2 frames
        //for fast computers, it is tiny, convenient because their update is called many times
        //for slow computers, it is large, convenient because their update is called fewer times
        //this function acts as an equalizer
    void Update()
    {
        gameObject.transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
    }
    
}
