using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EventManager eventManager;

    private bool glyph1Drawn;
    private bool glyph2Drawn;
    private bool glyph3Drawn;

    public string sceneName;

    [SerializeField] private GameObject winScreen;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onGlyphDrawn += GlyphDrawn;
    }

    private void OnDisable()
    {
        eventManager.onGlyphDrawn -= GlyphDrawn;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void GlyphDrawn(string glyph)
    {
        switch (glyph)
        {
            case "triangle":
                glyph1Drawn = true;
                break;
            case "m":
                glyph2Drawn = true; 
                break;
            case "rune":
                glyph3Drawn = true;
                break;
        }
       CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if(glyph1Drawn && glyph2Drawn && glyph3Drawn)
        {
            WinScreen();
        }
    }

    private void WinScreen()
    {
        winScreen.SetActive(true);
        StartCoroutine(RestartDelay());
    }

    private IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(5);
        winScreen.SetActive(false);
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

  

    
}
