using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab = null;
    public float spawnDelay = 5.0f;
    public float timer = 0.0f;

    public float pipeReposition = 0.0f;  //numbers 0~5
    void Start()
    {
        
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= spawnDelay)
        {
            pipeReposition = Random.Range(0, 5);
            gameObject.GetComponent<Transform>().Translate(0,pipeReposition,0);
            Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
            timer = 0.0f;
            gameObject.GetComponent<Transform>().Translate(0,pipeReposition*(-1),0);
        }
    }
}
