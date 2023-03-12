using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void OnStep()
    {
        audioSource.Play();
    }
}
