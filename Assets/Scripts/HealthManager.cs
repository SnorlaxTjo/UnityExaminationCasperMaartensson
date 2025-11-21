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
    public bool canTakeDamage { get; set; } = true;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!canTakeDamage) { return; }
        
        health -= damage;
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            Debug.Log("ded");
        }
    }
}
