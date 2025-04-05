using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TrailRendererManager trailRenderer;

    private void Start()
    {
        trailRenderer = FindObjectOfType<TrailRendererManager>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (trailRenderer.trailRenderer.emitting)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (trailRenderer.trailRenderer.emitting)
        {
            this.gameObject.SetActive(false);
        }
    }


}
