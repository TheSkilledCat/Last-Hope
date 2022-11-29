using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text dis;
    // Start is called before the first frame update
    private double distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance += 0.002;
        dis.text= distance.ToString();
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(8 * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-8 * Time.deltaTime, 0));
        }
    }
}
