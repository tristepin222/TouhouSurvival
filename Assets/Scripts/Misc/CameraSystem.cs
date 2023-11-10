using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CinemachineVirtualCamera[] gameObjects = FindObjectsByType<CinemachineVirtualCamera>(FindObjectsSortMode.None);


        foreach (CinemachineVirtualCamera camera in gameObjects)
        {
            camera.Follow = this.gameObject.transform;
        }
    }
}
