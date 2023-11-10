using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;


    }
    private void OnBecameInvisible()
    {

        Destroy(this.gameObject);

    }
}
