using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] int startCoin = 150;
    [SerializeField] int currentCoin;
    public int CurrentCoin { get { return currentCoin; } }

    [SerializeField] TextMeshProUGUI displayCoin;

    void Awake()
    {
        currentCoin = startCoin;
        UpdateDisplay();
    }
    public void Deposit(int _coin)
    {
        // - 기호 삭제
        currentCoin += Mathf.Abs(_coin);
        UpdateDisplay();
    }
    public void Withdraw(int _coin)
    {
        currentCoin -= Mathf.Abs(_coin);
        UpdateDisplay();

        if (currentCoin < 0)
        {
            // Lose GAME;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    void UpdateDisplay()
    {
        displayCoin.text = "coin: " + currentCoin;
    }
}
