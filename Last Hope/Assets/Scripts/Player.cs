using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Boundary
{
    public float xMin, xMax, yMax, yMin;//  andazashoon motagier nesbat be unity
}
public class Player : MonoBehaviour
{
    public int fireLevel = 1;//power shelik
    public Boundary boundary;
    public float speed;
    private Rigidbody2D rig;
    public GameObject playerBullet;//motagier esm bullet
    public Transform[] firepoints;
    public float fireRate;//zaman maks har shelik
    private float nextFire;//tir bad
    private string tempstr;

    public Text score_txt; // text for score

    public Text health_txt;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;//harekat
        rig.position = new Vector2(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax),
                                   Mathf.Clamp(rig.position.y, boundary.yMin, boundary.yMax));//marze
        //when we push left mouse button then we should shoot
        if(Input.GetButton("Fire1")&&Time.time> nextFire)//braye bullet va mostamar boodanesh   //GetButtonDown
        {
            //zaman bandi golole
            nextFire = Time.time + fireRate;
            //-----------------------------------------------
            if (fireLevel >= 1)
            {
                //copy of object prefab and send itfrom firepoint position
                //ba ijad folder prefab va drag crakter too folder prefab mishe
                Instantiate(playerBullet, firepoints[0].position, firepoints[0].rotation);
            }
            //*******************************************************************************
            //copy of object prefab and send itfrom firepoint position
            //ba ijad folder prefab va drag crakter too folder prefab mishe
            //Instantiate(playerBullet, firepoints[0].position, firepoints[0].rotation);
            //*********************************************************************************
            if (fireLevel >= 2)
            {
                Instantiate(playerBullet, firepoints[0].position, firepoints[0].rotation);
                Instantiate(playerBullet, firepoints[1].position, firepoints[1].rotation);
            }
            if (fireLevel >= 3)
            {
                Instantiate(playerBullet, firepoints[0].position, firepoints[0].rotation);
                Instantiate(playerBullet, firepoints[1].position, firepoints[1].rotation);
                Instantiate(playerBullet, firepoints[2].position, firepoints[2].rotation);
            }
        }
        score_txt.text = GameVars.score.ToString();
    }
        //Declare variables
    public int maxHealth = 100;
    public int currentHealth;

    //Function for health
    public void TakeDamage(int damage){
        currentHealth -= damage;
        GameVars.health -= damage;
        tempstr = "" ;
        Debug.Log(GameVars.health);
        for (int i = 0; i < GameVars.health; i++)
        {
            tempstr = tempstr + "❤";
        }
        Debug.Log(tempstr);
        health_txt.text = tempstr;
        if(currentHealth <= 0){
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(int healAmount){
        currentHealth += healAmount;
        GameVars.health += healAmount;
        tempstr = "" ;
        Debug.Log(GameVars.health);
        for (int i = 0; i < GameVars.health; i++)
        {
            tempstr = tempstr + "❤";
        }
        Debug.Log(tempstr);
        health_txt.text = tempstr;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    public void Die(){
        //Do something when player dies
        Destroy(gameObject);
    }
}
