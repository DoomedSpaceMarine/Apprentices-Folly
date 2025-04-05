using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    //interaction text prompt
    public string interactionPrompt;

    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //no code is written here, this is a template function which will be overidden by subclasses-
    }
}
