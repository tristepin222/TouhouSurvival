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
    // Start is called before the first frame update
    void Start()
    {
        indexWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFighting)
            {
                StartCoroutine(CoolDown());
            }
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
    private IEnumerator CoolDown()
    {
        isFighting = true;
        weapons[indexWeapon].Attack();
        indexWeapon++;
        if (indexWeapon >= weapons.Length)
        {
            indexWeapon = 0;
        }
        yield return new WaitForSeconds(0.5f);
        isFighting = false;
    }

    public void DisableWeapons()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.Disable();
        }
    }
    
}
