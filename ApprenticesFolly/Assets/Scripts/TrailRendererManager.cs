using UnityEngine;

public class TrailRendererManager : MonoBehaviour
{
    EventManager eventManager;

    private Vector3 position;

    public float zOffset;

    public TrailRenderer trailRenderer;

    private void Awake()
    {
       trailRenderer = this.gameObject.GetComponent<TrailRenderer>();

       eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        position.z = zOffset;   
        transform.position = Camera.main.ScreenToWorldPoint(position);
        
        if(Input.GetMouseButton(0))
        {
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }

        if(Input.GetMouseButtonUp(0))
        {
            eventManager.CountScore();
        }
        
    }
}
