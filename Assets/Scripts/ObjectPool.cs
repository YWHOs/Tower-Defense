using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 20f)] float time;

    GameObject[] pool;

    void Awake()
    {
        Pool();
    }

    void Start()
    {
        StartCoroutine(Enemy());
    }

    void Pool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }
    void EnablePool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator Enemy()
    {
        while (true)
        {
            EnablePool();
            yield return new WaitForSeconds(time);
        }

    }
}
