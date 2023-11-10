using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetter : MonoBehaviour
{
    private GameObject[] audioSources;
    private GameObject[] musicSources;
    // Start is called before the first frame update
    void Start()
    {
        SetSound();
    }

    public void SetSound()
    {
        audioSources = GameObject.FindGameObjectsWithTag("Enemy");
        
        musicSources = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject gameobject in audioSources)
        {
            AudioSource audioSource = gameobject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = GlobalController.Instance.soundValue;
            }
        }
        foreach (GameObject gameobject in musicSources)
        {
            AudioSource audioSource = gameobject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = GlobalController.Instance.musicValue;
            }
        }
        audioSources = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gameobject in audioSources)
        {
            AudioSource audioSource = gameobject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = GlobalController.Instance.soundValue;
            }
        }
    }
}
