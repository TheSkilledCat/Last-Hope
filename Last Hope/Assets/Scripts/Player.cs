using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public class Boundary
{
    public float xMin, xMax, yMax, yMin;//  andazashoon motagier nesbat be unity
}
public class Player : MonoBehaviour
{
    public AudioSource ac;
    public AudioSource ac1;
    public AudioSource ac2;
    public AudioSource ac3;
    public int fireLevel = 1;//power shelik
    public Boundary boundary;
    public float speed;
    private Rigidbody2D rig;
    public GameObject playerBullet;//motagier esm bullet
    public Transform[] firepoints;
    public float fireRate;//zaman maks har shelik
    private float nextFire;//tir bad
    private string tempstr;

    public TextMeshProUGUI scoreText; // text for score
    public TextMeshProUGUI YourScoreText; // text for score
    public TextMeshProUGUI HighestScoreDeath; // text for score
    public Text Scoretxt;
    public TextMeshProUGUI highestScoreText;
    public Text health_txt;

    public GameObject DeadMenuUI;
    public GameObject GameScene;

    public Animator animator;

    public float bulletSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        highestScoreText.text = GameVars.highestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //player rotation begins
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;    
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //player rotation done
        rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;//harekat
        rig.position = new  Vector2(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax),
                                   Mathf.Clamp(rig.position.y, boundary.yMin, boundary.yMax));//marze
        //when we push left mouse button then we should shoot
        if (Input.GetButton("Fire1") && Time.time> nextFire)//braye bullet va mostamar boodanesh   //GetButtonDown
        {
            //zaman bandi golole
            nextFire = Time.time + fireRate;
            //-----------------------------------------------
            if (fireLevel >= 1)
            {
                animator.Play("player-shoot");
                //copy of object prefab and send itfrom firepoint position
                //ba ijad folder prefab va drag crakter too folder prefab mishe
                GameObject bullet = Instantiate(playerBullet, firepoints[0].position, firepoints[0].rotation);
                bullet.transform.rotation = transform.rotation;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * bulletSpeed; 
                ac1.Play();
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
                ac2.Play();
            }
            if (fireLevel >= 3)
            {
                Instantiate(playerBullet, firepoints[0].position, firepoints[0].rotation);
                Instantiate(playerBullet, firepoints[1].position, firepoints[1].rotation);
                Instantiate(playerBullet, firepoints[2].position, firepoints[2].rotation);
                ac3.Play();
            }
        }
        scoreText.SetText(GameVars.score.ToString());
        YourScoreText.SetText(GameVars.score.ToString());
        // scoreText.text = GameVars.score.ToString();
    }
        //Declare variables
    public int maxHealth = 100;
    public int currentHealth;
    public Image[] hearts;

    //Function for health
    public void TakeDamage(int damage){
        currentHealth -= damage;
        GameVars.health -= damage;
        tempstr = "" ;
        Debug.Log(GameVars.health);
        for (int i = 0; i < currentHealth; i++)
        {
            tempstr = tempstr + "❤";
        }
        Debug.Log(tempstr);
        health_txt.text = tempstr;
        if(currentHealth <= 0){
            currentHealth = 0;
            Die();
        }
        UpdateHearts();
    }

    public void Heal(int healAmount){
        currentHealth += healAmount;
        GameVars.health += healAmount;
        tempstr = "" ;
        Debug.Log(GameVars.health);
        for (int i = 0; i < currentHealth; i++)
        {
            tempstr = tempstr + "❤";
        }
        Debug.Log(tempstr);
        health_txt.text = tempstr;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        UpdateHearts();
    }

    public void Die(){
        //Do something when player dies
        if (GameVars.score >= GameVars.highestScore){
            GameVars.highestScore = GameVars.score;
            highestScoreText.text = GameVars.score.ToString();
            PlayerPrefs.SetInt("highestScore", GameVars.highestScore);
            GameVars.health=10;
        }
        HighestScoreDeath.SetText(GameVars.highestScore.ToString());
        GameVars.score = 0;
        GameScene.SetActive(false);
        DeadMenuUI.SetActive(true);
        Pause();
        Destroy(gameObject);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
