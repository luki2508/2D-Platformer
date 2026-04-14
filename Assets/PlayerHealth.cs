using System;
using System.Collections;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float Health;
    private bool canReciveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHelth, float ammountChanged);
    public event HealthChangedHandler OnhealthChanged;

    public delegate void HealthInitialisedHandler(float newHelth);
    public event HealthInitialisedHandler OnhealthInitialised;


    public void AddDamage(float damage)
    {
        if (canReciveDamage)
        {
            Health -= damage;
            OnhealthChanged?.Invoke(Health, -damage);
            canReciveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(Health);
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canReciveDamage = true;
    }

    void Start()
    {
        Health = maxHealth;
        OnhealthInitialised?.Invoke(Health);
    }

    public void AddHealth(float healthToAdd)
    {
        Health += healthToAdd;
        OnhealthChanged?.Invoke(Health, healthToAdd);
        Debug.Log(Health);
    }
}