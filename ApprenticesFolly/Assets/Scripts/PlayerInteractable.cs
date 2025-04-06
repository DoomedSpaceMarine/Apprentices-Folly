using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactorDistance = 3f;
    [SerializeField] private LayerMask mask;

    private PlayerInteractUI interactUI;

    // Start is called before the first frame update
    void Start()
    {
        interactUI = FindObjectOfType<PlayerInteractUI>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactorDistance);
        //Variable to store collision information
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, interactorDistance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactables>() != null)
            {
                Interactables interactableObject = hitInfo.collider.GetComponent<Interactables>();
                interactUI.EnableTextPrompt();
                interactUI.SetTextForPrompt(interactableObject.interactionPrompt);
                if (Input.GetMouseButtonDown(1))
                {
                    interactableObject.BaseInteract();
                }
            }

        }
        else
        {
            interactUI.DisableTextPrompt();
        }
    }
}
