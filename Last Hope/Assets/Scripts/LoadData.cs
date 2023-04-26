using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("highestscore")){
            PlayerPrefs.SetInt("highestscore",0);
        }
        GameVars.highestscore = PlayerPrefs.GetInt("highestscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
