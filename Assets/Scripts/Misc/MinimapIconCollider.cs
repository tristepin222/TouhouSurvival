using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconCollider : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite srToReplace;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (srToReplace != null)
            {
                sr.sprite = srToReplace;
            }
            else
            {
                sr.enabled = false;
            }
        }
    }
}
