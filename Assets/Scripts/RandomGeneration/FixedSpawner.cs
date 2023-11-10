using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    [SerializeField] Transform[] transforms;
    public void Spawn()
    {
        foreach(Transform t in transforms)
        {
            GameObject gm = Instantiate(spawn, t);
            gm.transform.position = t.position;
        }
    }
}
