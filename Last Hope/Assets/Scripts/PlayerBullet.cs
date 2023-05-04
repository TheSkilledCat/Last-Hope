using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifetime;
    public int damage;
    
    private Transform Enemy;
    private Vector3 target;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector3(Enemy.position.x ,Enemy.position.y, Enemy.position.z); 
        direction = Enemy.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyShooting>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
