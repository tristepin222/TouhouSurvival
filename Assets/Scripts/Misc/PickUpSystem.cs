using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
        {
            loot.MoveTowards();
        }
    }
}
