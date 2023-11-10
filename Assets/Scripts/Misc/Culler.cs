using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edgar.Unity;

public class Culler : DungeonGeneratorPostProcessingComponentGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] gameObjects2 = GameObject.FindGameObjectsWithTag("Cullable");
        foreach(GameObject gameObject in gameObjects)
        {
            if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.sortingOrder *= (int)gameObject.transform.position.y;
            }
        }
        foreach (GameObject gameObject in gameObjects2)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder *= (int)gameObject.transform.position.y;
        }
    }
}
