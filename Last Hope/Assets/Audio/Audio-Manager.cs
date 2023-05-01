using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{
    public AudioSource ac1;
    public AudioSource ac2;
    public AudioSource ac3;
    public int firerate;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(firerate== 1)
                ac1.Play();
            else if(firerate == 1)
                ac2.Play();
            else if (firerate == 3) 
                ac3.Play(); 
        }
    }
}
