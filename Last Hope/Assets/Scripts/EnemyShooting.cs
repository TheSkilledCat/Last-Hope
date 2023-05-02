using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    public float range;
    private GameObject playerg;
    public GameObject bullet;
    public float timebeetweenshots;
    private float tmbtshts;
    private Transform player;
    public float lifetime;

    public GameObject medkit;
    public float medkitspawnchance;


    // Start is called before the first frame update
    void Start()
    {
        tmbtshts = timebeetweenshots;
    }

    // Update is called once per frame
    void Update()
    {
        playerg=GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(playerg.transform.position, transform.position);
        if (tmbtshts <= 0 && distance <= range)
        {
            Instantiate(bullet,transform.position, Quaternion.identity);
            tmbtshts = timebeetweenshots;
        }else
        {
            tmbtshts -= Time.deltaTime;
        }
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    //Declare variables
    public int maxHealth = 10;
    public int currentHealth =10;

    //Function for health
    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(int healAmount){
        currentHealth += healAmount;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
    public void Die(){
        if (Random.Range(0f, 1f) <= medkitspawnchance) {
            Instantiate(medkit,transform.position, Quaternion.identity);
        }
        //Do something when player dies
        Destroy(gameObject);
        GameVars.score += 10;
    }
}
