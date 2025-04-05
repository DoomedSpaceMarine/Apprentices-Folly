using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleBook : MonoBehaviour
{
    public bool bookIsOpen;

    [SerializeField] private GameObject wizardBook;

    private void Start()
    {
        wizardBook.SetActive(false);
    }

    private void ToggleWizardBook()
    {
        bookIsOpen = !bookIsOpen;

        if(bookIsOpen)
        {
            wizardBook.SetActive(true);
        }
        else
        {
            wizardBook.SetActive(false);    
        }
    }

    public void ToggleBookInput(InputAction.CallbackContext context)
    {
        ToggleWizardBook();
    }
    }
