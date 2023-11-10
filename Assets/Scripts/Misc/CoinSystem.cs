using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] UICoinSystem uICoinSystem;

    private void Start()
    {
        uICoinSystem = FindFirstObjectByType<UICoinSystem>();
        uICoinSystem.SetCoin(GlobalController.Instance.coin);
    }


    private void AddCoin(float amount)
    {
        GlobalController.Instance.coin += amount;
        uICoinSystem.SetCoin(GlobalController.Instance.coin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
        {
            if (loot.item.itemType == Item.ItemType.Coin)
            {
                AddCoin(2f);
                Destroy(collision.gameObject);
            }
        }
    }
}
