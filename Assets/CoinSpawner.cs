using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject prefab = null;
    public float spawnDelay = 5.0f;
    public float timer = 0.0f;

    public float pipeReposition = 0.0f;  //numbers 0~5

    private int coinRarity = 0;  //increase number to make coins more rare
    void Start()
    {
        
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= spawnDelay)
        {
            if (Random.Range(0, coinRarity) == coinRarity)
            {
                pipeReposition = Random.Range(0, 5);
                gameObject.GetComponent<Transform>().Translate(0,pipeReposition,0);
                Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
                gameObject.GetComponent<Transform>().Translate(0,pipeReposition*(-1),0);   
            }
            timer = 0.0f;
        }
    }
}
