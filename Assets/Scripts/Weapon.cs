using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;

    private void Start()
    {
        Damage = damage;
    }
    public int Damage{ get; set; }
}
