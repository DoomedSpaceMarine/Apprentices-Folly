using UnityEngine;
using UnityEngine.EventSystems;

public class MinusPoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
            eventManager.SubstractScore(1);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (trailRenderer.trailRenderer.emitting)
        {
            this.gameObject.SetActive(false);
            eventManager.SubstractScore(1);
        }
    }
}
