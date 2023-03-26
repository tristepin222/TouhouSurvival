using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSPawn : MonoBehaviour
{
    [SerializeField] List<ObjectSpawn> objectSpawns = new List<ObjectSpawn>();
    [SerializeField] float minRadius;
    [SerializeField] float maxRadius;
    [SerializeField] GameObject player;

    const int MAX_SPAWN_COUNT = 25;

    private bool isChecking;
    private int spawnCount;
    // Update is called once per frame
    void Update()
    {
        if (spawnCount <= MAX_SPAWN_COUNT)
        {
            if (!isChecking)
            {
                StartCoroutine(CheckWeight());
                spawnCount++;
            }
        }
    }

    private IEnumerator CheckWeight()
    {
        isChecking = true;
        float weightTotal = CalculateWeightTotal();
        float random = Random.Range(0, weightTotal);
        foreach (ObjectSpawn objectSpawn in objectSpawns)
        {
            
            if (random <= objectSpawn.weight)
            {
               
                Spawn(objectSpawn.gameObject);
                yield return new WaitForSeconds(3f);
                isChecking = false;
            }
            else
            {
                random -= objectSpawn.weight;
            }
        }
        yield return new WaitForSeconds(3f);
        isChecking = false;
    }

    private float CalculateWeightTotal()
    {
        float weightTotal = 0f;
        foreach (ObjectSpawn objectSpawn in objectSpawns)
        {
            weightTotal += objectSpawn.weight;
        }
        return weightTotal;
    }

    private void Spawn(GameObject gameObject)
    {
        Instantiate(gameObject);
        gameObject.transform.position = Random.insideUnitCircle.normalized * Random.Range(minRadius, maxRadius);
       
    }
}
