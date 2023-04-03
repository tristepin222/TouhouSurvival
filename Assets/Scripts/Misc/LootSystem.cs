using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    [SerializeField] GameObject loot;
    // Start is called before the first frame update

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        GameObject currentLoot = Instantiate(loot);
        currentLoot.transform.position = transform.position;
    }
}
