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

    [SerializeField] private AudioSource sealUnlocked;

    RecognitionManager recognitionManager;
    ToggleBook toggleBook;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();
        recognitionManager = FindObjectOfType<RecognitionManager>();
        toggleBook = FindObjectOfType<ToggleBook>();

        eventManager.onCountScore += CountScore;
        eventManager.onAddScore += AddScore;
        eventManager.onGetMaxScore += GetMaxScore;
        eventManager.onResetScore += ResetScore;
        eventManager.onSubstractScore += SubstractScore;
    }

    private void OnDisable()
    {
        eventManager.onCountScore -= CountScore;
        eventManager.onAddScore -= AddScore;
        eventManager.onGetMaxScore -= GetMaxScore;
        eventManager.onResetScore -= ResetScore;
        eventManager.onSubstractScore -= SubstractScore;
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

    private void SubstractScore(float substraction)
    {
        currentScore -= substraction;   
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
        if(recognitionManager.zonePattern != "")
        {
            scoreText.gameObject.SetActive(true);
            StartCoroutine(DisableScoreText());
            if (finalScore >= 80f)
            {
                scoreText.text = finalScore.ToString("0.0") + " Success";

                if(recognitionManager.zonePattern == "triangle" && !toggleBook.bookIsOpen && recognitionManager.spellcastingMode)
                {
                    eventManager.GlyphDrawn("triangle");
                    sealUnlocked.Play();
                }

                if (recognitionManager.zonePattern == "m" && !toggleBook.bookIsOpen && recognitionManager.spellcastingMode)
                {
                    eventManager.GlyphDrawn("m");
                    sealUnlocked.Play();
                }

                if (recognitionManager.zonePattern == "rune" && !toggleBook.bookIsOpen && recognitionManager.spellcastingMode)
                {
                    eventManager.GlyphDrawn("rune");
                    sealUnlocked.Play();
                }
            }

            else if (finalScore < 80f)
            {
                scoreText.text = finalScore.ToString("0.0") + " Fail";
            }
        }
        
    }

    private IEnumerator DisableScoreText()
    {
        yield return new WaitForSeconds(5);
        scoreText.gameObject.SetActive(false);
    }
}
