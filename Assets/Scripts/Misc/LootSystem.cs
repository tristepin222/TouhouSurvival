using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    [SerializeField] GameObject[] loots;
    GameObject currentLoot;
    // Start is called before the first frame update

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        foreach (GameObject loot in loots)
        {
            currentLoot = Instantiate(loot);
            currentLoot.transform.position = transform.position;
        }
    }
}
