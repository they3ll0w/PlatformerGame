using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newLevel : MonoBehaviour
{
    public bool lastLevel = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(lastLevel == false)
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextLevel);
        } else
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
