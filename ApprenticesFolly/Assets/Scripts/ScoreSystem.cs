using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    EventManager eventManager;

    private int currentScore;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onCountScore += CountScore;
        eventManager.onAddScore += AddScore;
    }

    private void OnDisable()
    {
        eventManager.onCountScore -= CountScore;
        eventManager.onAddScore -= AddScore;
    }

    private void CountScore()
    {

    }

    private void AddScore(int addition)
    {
        currentScore += addition;   
    }
}
