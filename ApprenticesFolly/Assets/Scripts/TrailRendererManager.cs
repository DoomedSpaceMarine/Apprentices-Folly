using UnityEngine;

public class TrailRendererManager : MonoBehaviour
{
    private Vector3 position;

    public float zOffset;

    public TrailRenderer trailRenderer;

    private void Awake()
    {
       trailRenderer = this.gameObject.GetComponent<TrailRenderer>();
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
        
    }
}
