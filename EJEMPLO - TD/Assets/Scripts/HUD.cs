using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldLabel;

    Bank bank;
    
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGoldUI();
    }

    void UpdateGoldUI()
    {
        if (bank == null) { return; }
        goldLabel.text = "Gold " + bank.CurrentBalance;
    }
}
