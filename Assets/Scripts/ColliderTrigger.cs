using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<HealthSystem>().Damage(damage);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
