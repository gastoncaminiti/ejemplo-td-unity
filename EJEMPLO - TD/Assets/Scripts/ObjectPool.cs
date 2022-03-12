using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(0,50)]int poolSize = 5;
    [SerializeField] [Range(0.1f,10f)] private float spawnDelay = 1f;
    // Start is called before the first frame update
    GameObject[] poll;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        poll = new GameObject[poolSize];
        for (int i = 0; i < poll.Length; i++)
        {
            poll[i] = Instantiate(enemyPrefab, transform);
            poll[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < poll.Length; i++)
        {
            GameObject enemy = poll[i];
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
