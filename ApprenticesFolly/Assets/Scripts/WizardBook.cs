using UnityEngine;
using UnityEngine.InputSystem;

public class WizardBook : MonoBehaviour
{
    EventManager eventManager;

    [SerializeField] private GameObject[] pagesLeft;
    [SerializeField] private GameObject[] pagesRight;

    private int maxPages = 0;
    private int pageState;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onAddToMaxPages += AddToMaxPages;
    }

    private void OnDisable()
    {
        eventManager.onAddToMaxPages -= AddToMaxPages;
    }

    private void Update()
    {
        if(pageState == 0)
        {
            pagesLeft[0].SetActive(true);
            pagesRight[0].SetActive(true);
            pagesLeft[1].SetActive(false);
            pagesRight[1].SetActive(false);
            pagesLeft[2].SetActive(false);
            pagesRight[2].SetActive(false);
            pagesLeft[3].SetActive(false);
            pagesRight[3].SetActive(false);
        }

        if (pageState == 1)
        {
            pagesLeft[0].SetActive(false);
            pagesRight[0].SetActive(false);
            pagesLeft[1].SetActive(true);
            pagesRight[1].SetActive(true);
            pagesLeft[2].SetActive(false);
            pagesRight[2].SetActive(false);
            pagesLeft[3].SetActive(false);
            pagesRight[3].SetActive(false);
        }

        if (pageState == 2)
        {
            pagesLeft[0].SetActive(false);
            pagesRight[0].SetActive(false);
            pagesLeft[1].SetActive(false);
            pagesRight[1].SetActive(false);
            pagesLeft[2].SetActive(true);
            pagesRight[2].SetActive(true);
            pagesLeft[3].SetActive(false);
            pagesRight[3].SetActive(false);
        }

        if (pageState == 3)
        {
            pagesLeft[0].SetActive(false);
            pagesRight[0].SetActive(false);
            pagesLeft[1].SetActive(false);
            pagesRight[1].SetActive(false);
            pagesLeft[2].SetActive(false);
            pagesRight[2].SetActive(false);
            pagesLeft[3].SetActive(true);
            pagesRight[3].SetActive(true);
        }
    }

    public void PagesForward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (pageState < maxPages)
            {
                pageState++;
            }
        }
        
    }
    public void PagesBackward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (pageState > 0)
            {
                pageState--;
            }
        }
        
    }

    private void AddToMaxPages()
    {
        maxPages++;
    }
}
