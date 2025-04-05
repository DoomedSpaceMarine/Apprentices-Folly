using UnityEngine;

public class PickupPage : Interactables
{
    EventManager eventManager;

    [SerializeField] private GameObject page;

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }
    protected override void Interact()
    {
        eventManager.AddToMaxPages();
        page.SetActive(false);
    }
}

