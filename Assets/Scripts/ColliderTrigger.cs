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
            if(collision.TryGetComponent(out HealthSystem healthSystem))
            {
                weapon.Hit(healthSystem);
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
