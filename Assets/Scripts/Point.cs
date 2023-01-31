using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] bool isPlace;
    public bool IsPlace { get { return isPlace; } }

    void OnMouseDown()
    {
        if (isPlace)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            isPlace = !isPlaced;
        }
    }
}
