using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            weapon.Hit(collision.GetComponent<HealthSystem>());
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
