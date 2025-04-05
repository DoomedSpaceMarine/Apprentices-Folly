using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    EventManager eventManager;

    private int currentScore;
    private int maxScore;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onCountScore += CountScore;
        eventManager.onAddScore += AddScore;
        eventManager.onGetMaxScore += GetMaxScore;
    }

    private void OnDisable()
    {
        eventManager.onCountScore -= CountScore;
        eventManager.onAddScore -= AddScore;
        eventManager.onGetMaxScore -= GetMaxScore;
    }

    private void CountScore()
    {

    }

    private void AddScore(int addition)
    {
        currentScore += addition;   
    }

    private void GetMaxScore(int shapeListLenght)
    {
        maxScore = shapeListLenght;
    }
}
