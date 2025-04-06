using Unity.VisualScripting;
using UnityEngine;

public class PickupTome : Interactables
{
    [SerializeField] private ToggleBook toggleBook;

    protected override void Interact()
    {
        toggleBook.wizardBookCollected = true;
        this.gameObject.SetActive(false);
    }
}
