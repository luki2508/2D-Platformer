using System;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public PlayerHealth PlayerHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHealth.OnhealthChanged += OnHealthChanged;
        PlayerHealth.OnhealthInitialised += OnHealthInit;
    }

    private void OnHealthInit(float newHelth)
    {
        HealthText.text = newHelth.ToString();
    }

    public void OnHealthChanged(float newHelth, float ammountChanged)
    {
        // Debug.Log("On Health Changed Event");
       HealthText.text = newHelth.ToString();
    }
    

   

    



}
