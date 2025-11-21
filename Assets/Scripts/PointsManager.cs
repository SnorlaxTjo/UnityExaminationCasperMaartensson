using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;

    private int currentPoints;

    public void AddPoints(int points)
    {
        currentPoints += points;
        pointsText.text = "Points: " + currentPoints;
    }
}
