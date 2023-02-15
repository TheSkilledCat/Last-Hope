using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void BackMenu()
    {
        Debug.Log("Back!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
