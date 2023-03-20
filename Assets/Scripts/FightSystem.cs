using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    [SerializeField] float fistDamage;
    [SerializeField] protected Animator animator;
    [SerializeField] Collider2D[] collider2Ds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("FistAttacks");
            foreach (Collider2D collider2D in collider2Ds)
            {
                collider2D.enabled = true;
            }
            StartCoroutine(DisableAttack());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.TryGetComponent(out IDamageable hit))
        {
            hit.Damage(fistDamage);
        }
    }

   private IEnumerator DisableAttack()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (Collider2D collider2D in collider2Ds)
        {
            collider2D.enabled = false;
        }
    }
}
