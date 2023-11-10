using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossSystem : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private FixedSpawner fixedSpawner;
    [SerializeField] AIPath aIPath;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] AudioSource stageTheme;
    [SerializeField] AudioSource bossTheme;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        stageTheme = GameObject.Find("StageTheme").GetComponent<AudioSource>();
        bossTheme = GameObject.Find("BossTheme").GetComponent<AudioSource>();
        sceneLoader.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (aIPath.hasPath)
        {
            timer += Time.deltaTime;
            if (timer > spawnTimer)
            {
                fixedSpawner.Spawn();
                timer = 0;
            }
        }
    }

    public void Die()
    {
        sceneLoader.enabled = true;
        bossTheme.Stop();
        stageTheme.Play();
    }
    private void OnBecameVisible()
    {
        stageTheme.Stop();
        bossTheme.Play();
    }
}
