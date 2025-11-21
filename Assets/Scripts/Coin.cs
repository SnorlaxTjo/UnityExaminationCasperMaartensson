using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int pointsToGive;
    
    PointsManager pointsManager;

    private void Start()
    {
        pointsManager = FindFirstObjectByType<PointsManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pointsManager.AddPoints(pointsToGive);
            Destroy(gameObject);
        }
    }
}
