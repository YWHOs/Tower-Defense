using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Point> path = new List<Point>();
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintPoint());
    }

    IEnumerator PrintPoint()
    {
        foreach(Point point in path)
        {
            transform.position = point.transform.position;
            yield return new WaitForSeconds(time);
        }
    }

}
