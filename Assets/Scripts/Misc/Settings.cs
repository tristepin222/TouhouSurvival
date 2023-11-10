using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    float soundValue = 0.5f;
    float musicValue = 0.5f;

    [SerializeField] AudioSource music;
    [SerializeField] SoundSetter Set;
    // Start is called before the first frame update
    void Start()
    {
        Set= FindFirstObjectByType<SoundSetter>();
        Set.SetSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (music != null)
        {
            music.volume = musicValue;
        }
    }


    public void changeSound(float value)
    {
        soundValue = value;
        GlobalController.Instance.soundValue = value;
    }

    public void changeMusic(float value)
    {
        musicValue = value;
        GlobalController.Instance.musicValue = value;
    }
}
