using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] private int maxHealth;
    [SerializeField] private float damageBuffer;

    [Space] 
    
    [SerializeField] private UnityEvent whatToDoUponDeath;

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
            whatToDoUponDeath.Invoke();
        }
    }
}
