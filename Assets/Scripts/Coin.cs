using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int pointsToGive;
    [SerializeField] private AudioClip coinSound;
    
    PointsManager pointsManager;

    private void Start()
    {
        pointsManager = FindFirstObjectByType<PointsManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindFirstObjectByType<SFXManager>().PlaySound(coinSound);
            pointsManager.AddPoints(pointsToGive);
            Destroy(gameObject);
        }
    }
}
