using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    public AudioSource ac;
    public float range;
    private GameObject playerg;
    public GameObject bullet;
    public float timebeetweenshots;
    private float tmbtshts;
    private Transform[] player;
    public float lifetime;
    public GameObject medkit;
    public GameObject supermedkit;
    public float medkitspawnchance;
    public float supermedkitspawnchance;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        tmbtshts = timebeetweenshots;
    }

    // Update is called once per frame
    void Update()
    {
        playerg = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(playerg.transform.position, transform.position);
        if (tmbtshts <= 0 && distance <= range)
        {
            animator.Play("enemy-shoot");
            Instantiate(bullet,transform.position, Quaternion.identity);
            ac.Play();
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
        float generatedChance = Random.Range(0f, 1f);
        if (generatedChance <= supermedkitspawnchance) {
            Instantiate(supermedkit, transform.position, Quaternion.identity);
        }
        else if (generatedChance <= medkitspawnchance) {
            Instantiate(medkit, transform.position, Quaternion.identity);
        }

        //Do something when player dies
        Destroy(gameObject);
        GameVars.score += 1;
    }
}
