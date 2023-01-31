using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Point> path = new List<Point>();
    [SerializeField] [Range(0f, 5f)]float speed;

    [Header("Health")]
    [SerializeField] int maxHealth;
    [SerializeField] int difficultHealth;
    int currentHealth;

    [Header("Coin")]
    [SerializeField] int coinReward;
    [SerializeField] int coinPenalty;
    Coin coin;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PrintPoint());
        currentHealth = maxHealth;
    }

    void Start()
    {
        coin = FindObjectOfType<Coin>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] wayPoint = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in wayPoint)
        {
            path.Add(waypoint.GetComponent<Point>());
        }
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator PrintPoint()
    {
        foreach(Point point in path)
        {
            Vector3 start = transform.position;
            Vector3 end = point.transform.position;
            float percent = 0f;

            transform.LookAt(end);

            while(percent < 1f)
            {
                percent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(start, end, percent);
                yield return new WaitForEndOfFrame();
            }

            //transform.position = point.transform.position;
        }

        // 적이 끝에 도달하면 개체 사라짐
        gameObject.SetActive(false);
        coin.Withdraw(coinPenalty);
    }

    void OnParticleCollision(GameObject other)
    {
        ParticleHit();
    }
    void ParticleHit()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            maxHealth += difficultHealth;
            if (coin == null) { return; }
            coin.Deposit(coinReward);
        }
    }

}
