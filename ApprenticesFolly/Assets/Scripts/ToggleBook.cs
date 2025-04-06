using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleBook : MonoBehaviour
{
    public bool bookIsOpen;
    public bool wizardBookCollected;

    [SerializeField] private GameObject wizardBook;

    [SerializeField] private RecognitionManager recognitionManager; 

    private void Start()
    {
        wizardBook.SetActive(false);
    }

    private void ToggleWizardBook()
    {
        if (wizardBookCollected)
        {
            bookIsOpen = !bookIsOpen;

            if (bookIsOpen)
            {
                wizardBook.SetActive(true);
                recognitionManager.spellcastingMode = true;
            }
            else
            {
                wizardBook.SetActive(false);
                if (!recognitionManager.spellcastingKeyIsheld)
                {
                    recognitionManager.spellcastingMode = false;
                }
            }
        }
       
    }

    public void ToggleBookInput(InputAction.CallbackContext context)
    {
        ToggleWizardBook();
    }
    }
