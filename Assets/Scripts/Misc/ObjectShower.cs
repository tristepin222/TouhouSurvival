using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShower : MonoBehaviour
{
    [SerializeField] GameObject objectToShow;
    [SerializeField] UIShopSystem uIShopSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            objectToShow.SetActive(true);
            if(uIShopSystem != null)
            {
                uIShopSystem.enabled = true;
            }
        }
    }
}
