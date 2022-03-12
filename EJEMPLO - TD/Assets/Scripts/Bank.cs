using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalence = 150;

    [SerializeField] private int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Start()
    {
        currentBalance = startingBalence;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0)
        {
           ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currenteScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currenteScene.buildIndex);
    }
}
