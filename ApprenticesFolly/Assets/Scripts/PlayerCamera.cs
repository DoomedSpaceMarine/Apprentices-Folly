using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    [SerializeField] private TrailRendererManager trailRendererManager; 

    private float xRotation;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private Vector2 mouse;

    private void LateUpdate()
    {
        if (!trailRendererManager.trailRenderer.emitting) 
        {
            //calculate camera rotation for looking up and down
            xRotation -= (mouse.y * Time.deltaTime) * xSensitivity;
            xRotation = Mathf.Clamp(xRotation, -70f, 70f);

            //apply xRotation to camera transform
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            //rotate player to look left and right
            transform.Rotate(Vector3.up * (mouse.x * Time.deltaTime) * xSensitivity);
        }
        
    }

    public void Look(InputAction.CallbackContext context)
    {
        mouse = context.ReadValue<Vector2>();
    }
}
