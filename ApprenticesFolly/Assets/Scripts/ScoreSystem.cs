using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    EventManager eventManager;

    private float currentScore;
    private float maxScore;
    private float finalScore;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onCountScore += CountScore;
        eventManager.onAddScore += AddScore;
        eventManager.onGetMaxScore += GetMaxScore;
        eventManager.onResetScore += ResetScore;
    }

    private void OnDisable()
    {
        eventManager.onCountScore -= CountScore;
        eventManager.onAddScore -= AddScore;
        eventManager.onGetMaxScore -= GetMaxScore;
        eventManager.onResetScore -= ResetScore;
    }

    private void CountScore()
    {
        finalScore = currentScore / maxScore * 100;
    }

    private void AddScore(float addition)
    {
        currentScore += addition;   
    }

    private void GetMaxScore(float shapeListLenght)
    {
        maxScore = shapeListLenght;
    }

    private void ResetScore()
    {
        currentScore = 0;
        maxScore = 0;
        finalScore = 0;
    }
}
