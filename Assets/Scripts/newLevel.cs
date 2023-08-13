using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }
}
