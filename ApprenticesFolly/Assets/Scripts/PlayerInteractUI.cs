using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject playerInteractionTextPrompt;

    [SerializeField] private TextMeshProUGUI interactionText;

    public void EnableTextPrompt()
    {
        playerInteractionTextPrompt.SetActive(true);
    }

    public void DisableTextPrompt()
    {
        playerInteractionTextPrompt.SetActive(false);
    }

    public void SetTextForPrompt(string text)
    {
        interactionText.text = text;
    }
}
