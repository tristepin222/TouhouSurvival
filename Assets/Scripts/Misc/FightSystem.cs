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
    private float maxDistance;

    public float attackSpeedRation = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 1.5f + (GlobalController.Instance.bonusRange / 10);
        indexWeapon = 0;
        SetWeapons();
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
        if (weapons[indexWeapon] != null)
        {
            isFighting = true;
            Transform enemy = GetClosestEnemy();
            if (enemy != null)
            {
                weapons[indexWeapon].Attack(enemy);
            }
            yield return new WaitForSeconds(attackSpeedRation / (GlobalController.Instance.bonusAttackSpeed / 100 + 1));
            indexWeapon++;
            isFighting = false;
        }
    }

    public void DisableWeapons()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.Disable();
        }
    }

    public void HardDisableWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.HardDisable();
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

    public void SetWeapons()
    {
        int index = 0;
        foreach (Weapon weapon in weapons)
        {
            if (GlobalController.Instance.weapons[index] != null)
            {
                weapon.gameObject.SetActive(true);
                weapon.SetWeapon(GlobalController.Instance.weapons[index]);
            }
            else
            {
                weapon.HardDisable();
            }
            index++;
        }
    }
    private void getAllEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
