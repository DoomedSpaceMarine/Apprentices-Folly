using UnityEngine;

public class TrailRenderer : MonoBehaviour
{
    private Vector3 position;

    public float zOffset;

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        position.z = zOffset;   
        transform.position = Camera.main.ScreenToWorldPoint(position);  
    }
}
