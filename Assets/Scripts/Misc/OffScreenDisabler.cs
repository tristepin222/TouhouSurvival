using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenDisabler : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    private void OnBecameVisible()
    {
        transform.parent.GetComponent<Animator>().enabled = true;
        if(enemyManager != null)
        {
            enemyManager.enabled = true;
        }
    }
    private void OnBecameInvisible()
    {
        transform.parent.GetComponent<Animator>().enabled = false;
        if (enemyManager != null)
        {
            enemyManager.enabled = false;
        }
    }
}
