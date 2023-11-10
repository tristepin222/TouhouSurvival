using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] int bulletAmount;
    [SerializeField] float spreecooldown;
    [SerializeField] AIMovement aiMovement;
    GameObject player;
    Vector3 target;
    Vector3 difference;
    bool launched;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerHealthSystem>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindAnyObjectByType<PlayerHealthSystem>().gameObject;
        }
        if (aiMovement.isTriggered)
        {
            
            if (!launched)
            {
                
                launched = true;
                target = player.transform.position;
                difference = target - this.transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();

                StartCoroutine(LaunchProjectile(direction, rotationZ, bulletAmount, spreecooldown));
            }
        }
    }

    private IEnumerator LaunchProjectile(Vector2 direction, float rotationZ, int amount, float spreeCoolDown)
    {

        yield return new WaitForSeconds(spreeCoolDown);
        for (int i = 0; i <= amount; i++)
        {
            this.GetComponent<AudioSource>().Play();
            GameObject b = Instantiate(projectile) as GameObject;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.transform.position = this.GetComponent<Transform>().position;
        }
        launched = false;
    }
}
