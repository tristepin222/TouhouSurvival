using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class Menu : MonoBehaviour
{
    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);   
    }
    public void Quit()
    {
        Application.Quit();
    }
}
