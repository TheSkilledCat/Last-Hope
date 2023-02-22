using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float minX;
    public float maxX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float SpawnTime;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime) 
        {
            spawn();
            SpawnTime= Time.time + timeBetweenSpawn;
        }
    }
    void spawn()
    {
        float randomx = Random.Range(minX,maxX);
        float randomy = Random.Range(minY, maxY);
        Instantiate(obstacle, transform.position + new Vector3(randomx,randomy,0), transform.rotation);
    }
}