using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    public string scene = "MainGame";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            SceneManager.LoadScene(scene);
        }
    }
}
