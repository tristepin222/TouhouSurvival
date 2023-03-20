using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] bool trackMouse;
    [SerializeField] GameObject player;
    [SerializeField] string animationName;
    [SerializeField] Animator animator;

    private bool canAttack;
    private void Start()
    {
        Damage = damage;
    }
    public int Damage{ get; set; }

    private void Update()
    {
        if (trackMouse)
        {
            Vector3 vector3 = Camera.main.WorldToScreenPoint(player.transform.position);
            vector3 = Input.mousePosition - vector3;
            float angle = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;

            this.transform.position = player.transform.position;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.07f);
            this.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }
    public void Attack()
    {
        GetComponentInChildren<Collider2D>().enabled = true;
        trackMouse = false;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.z = 0;
        mousePosition -= objectPosition;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        animator.Play(animationName);
    }

    public void ResetAnimation()
    {
        GetComponentInChildren<Collider2D>().enabled = false;
        trackMouse = true;
    }

}
