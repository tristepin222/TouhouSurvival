using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class Menu : MonoBehaviour
{
    [SerializeField] bool startANew;
    [SerializeField] SoundSetter soundSetter;
    public void Play(string sceneName)
    {
        if(soundSetter != null)
        {
            soundSetter.SetSound();
            FindFirstObjectByType<FightSystem>().menuShowed = false;
        }
        if (startANew)
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    private void Start()
    {
        soundSetter = FindFirstObjectByType<SoundSetter>();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
