using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] private int maxHealth;
    [SerializeField] private float damageBuffer;

    private int health;
    private bool canTakeDamage = true;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("ded");
        }
        StartCoroutine(DamageBufferRoutine());
    }

    private IEnumerator DamageBufferRoutine()
    {
        canTakeDamage = false;
        
        yield return new WaitForSeconds(damageBuffer);
        
        canTakeDamage = true;
    }
}
