using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] protected Animator animator;
    [SerializeField] Weapon[] weapons;
    [SerializeField] GameObject menu;
    private int indexWeapon;
    private bool isFighting;
    private bool menuShowed;
    private GameObject[] enemies;
    private float maxDistance = 10f;

    public float attackSpeedRation = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        indexWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFighting)
        {
            StartCoroutine(AttackEach());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuShowed)
            {
                menuShowed = true;
                Instantiate(menu);
            }
        }
        
    }
    private IEnumerator AttackEach()
    {
        if (indexWeapon >= weapons.Length)
        {
            indexWeapon = 0;
        }
        isFighting = true;
        Transform enemy = GetClosestEnemy();
        if (enemy != null)
        {
            weapons[indexWeapon].Attack(enemy);
        }
        yield return new WaitForSeconds(weapons[indexWeapon].attackSpeed/attackSpeedRation);
        indexWeapon++;
        isFighting = false;
    }

    public void DisableWeapons()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.Disable();
        }
    }

    Transform GetClosestEnemy()
    {
        getAllEnemies();
        if (enemies.Length > 0)
        {
            Transform bestTarget = null;
            float closestDistanceSqr = maxDistance;
            Vector3 currentPosition = transform.position;
            foreach (GameObject potentialTarget in enemies)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget.transform;
                }
            }
            return bestTarget;
        }

        return null;
    }
    private void getAllEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
