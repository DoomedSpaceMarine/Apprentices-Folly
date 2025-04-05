using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TrailRendererManager trailRenderer;
    EventManager eventManager;

    private void Start()
    {
        trailRenderer = FindObjectOfType<TrailRendererManager>();
        eventManager = FindObjectOfType<EventManager>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (trailRenderer.trailRenderer.emitting)
        {
            this.gameObject.SetActive(false);
            eventManager.AddScore(1);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (trailRenderer.trailRenderer.emitting)
        {
            this.gameObject.SetActive(false);
            eventManager.AddScore(1);
        }
    }


}
