using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost;

    public bool CreateTower(Tower _tower, Vector3 _position)
    {
        Coin coin = FindObjectOfType<Coin>();

        if(coin == null) { return false; }

        if(coin.CurrentCoin >= cost)
        {
            Instantiate(_tower, _position, Quaternion.identity);
            coin.Withdraw(cost);
            return true;
        }

        return false;
    }
}
