using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float range;
    public GameObject playerg;
    public GameObject bullet;
    public float timebeetweenshots;
    private float tmbtshts;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        tmbtshts=timebeetweenshots;
        player=playerg.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (tmbtshts <= 0)
        {
            Instantiate(bullet,transform.position, Quaternion.identity);
            tmbtshts=timebeetweenshots;
        }else
        {
            tmbtshts-=Time.deltaTime;
        }
    }
}