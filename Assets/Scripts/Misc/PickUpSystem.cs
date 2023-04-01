using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "XPOrb")
        {
            levelSystem.addXP(1);
            Destroy(collision.gameObject);
        }
    }
}
