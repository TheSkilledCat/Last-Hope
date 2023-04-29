using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTowardPlayer : MonoBehaviour
{
    private Transform player; 

    public float rotationSpeed; 
 
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    // Calculate the angle between the player and this object 
        Vector2 direction = player.position - transform.position; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
 
        // Rotate the object in 2D without the z axis 
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); 

    }
}
