using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("highestScore")){
            PlayerPrefs.SetInt("highestScore",0);
        }
        GameVars.highestScore = PlayerPrefs.GetInt("highestScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
