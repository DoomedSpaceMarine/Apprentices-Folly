using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    EventManager eventManager;

    private float currentScore;
    private float maxScore;
    private float finalScore;

    [SerializeField] private TMP_Text scoreText;

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

    private void Start()
    {
        scoreText.gameObject.SetActive(false);
    }

    private void CountScore()
    {
        finalScore = currentScore / maxScore * 100;
        ShowScore();
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

    private void ShowScore()
    {
        scoreText.gameObject.SetActive(true);
        StartCoroutine(DisableScoreText());
        if(finalScore >= 85f)
        {
            scoreText.text = finalScore.ToString("0.0") + " Great";
        }

        else if(finalScore >= 50 && finalScore < 85)
        {
            scoreText.text = finalScore.ToString("0.0") + " Average";
        }

        else if(finalScore < 50)
        {
            scoreText.text = finalScore.ToString("0.0") + " Fail";
        }
    }

    private IEnumerator DisableScoreText()
    {
        yield return new WaitForSeconds(3);
        scoreText.gameObject.SetActive(false);
    }
}
