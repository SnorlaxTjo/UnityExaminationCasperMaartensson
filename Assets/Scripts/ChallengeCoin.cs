using System;
using UnityEngine;
using System.Collections.Generic;

public class ChallengeCoin : MonoBehaviour
{
    [SerializeField] private float challengeTime;
    [SerializeField] GameObject coin;
    [SerializeField] private List<Vector2> spawnPositions;
    
    [SerializeField] bool showSpawnPositions;
    
    private List<GameObject> coins = new List<GameObject>();
    private float timeLeft;
    private bool challengeStarted;

    private void Update()
    {
        if (challengeStarted)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                foreach (GameObject coin in coins)
                {
                    coin.SetActive(false);
                    Destroy(coin);
                }
            }
        }
    }

    public void SpawnCoins()
    {
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            GameObject spawnedCoin = Instantiate(coin);
            spawnedCoin.transform.position = spawnPositions[i];
            coins.Add(spawnedCoin);
        }
        timeLeft = challengeTime;
        challengeStarted = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (showSpawnPositions)
        {
            Gizmos.color = Color.green;
            foreach (Vector2 pos in spawnPositions)
            {
                Gizmos.DrawWireSphere(pos, 0.2f);
            }
        }
    }
}
