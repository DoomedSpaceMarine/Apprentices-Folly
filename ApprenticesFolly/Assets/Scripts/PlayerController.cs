using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float walkForwardSpeed;
    [SerializeField] private float walkBackwardSpeed;
    private Vector3 movementDirection;
    private Vector3 playerVelocity;
    private bool speedCooldown;

    [Header("Smooth Movement")]
    [SerializeField] private float smoothInputSpeed = 0.2f;
    private float currentSmooth;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    [Header("References")]
    private CharacterController characterController;
    [SerializeField] private TrailRendererManager trailRendererManager;

    private void Awake()
    {
        //Reference to character controller component
        characterController = GetComponent<CharacterController>();

        //Store initial input smoothSpeed. 
        currentSmooth = smoothInputSpeed;
    }

    private void Update()
    {
        //Processing movement
        ProcessMovement();

        //Set movement speeds 
        SetMovementSpeeds();
    }

    private void ProcessMovement()
    {
        if (!trailRendererManager.trailRenderer.emitting)
        {
            currentInputVector = Vector2.SmoothDamp(currentInputVector, movementDirection, ref smoothInputVelocity, smoothInputSpeed);
            Vector3 move = new Vector3(currentInputVector.x, 0, currentInputVector.y);
            characterController.Move(transform.TransformDirection(move) * Time.deltaTime * movementSpeed);
        }
    }

    private void SetMovementSpeeds()
    {
        //Walk backwards
        if (Input.GetKey(KeyCode.S))
        {
            movementSpeed = walkBackwardSpeed;
        }
        //Fixes problem where speed change after stopping walking backwards is too sudden. Makes the change smooth
        else if (Input.GetKeyUp(KeyCode.S))
        {
            speedCooldown = true;
            StartCoroutine(SpeedCooldown());
        }
        //Set walk forward speed
        else if (!Input.GetKey(KeyCode.S) && !speedCooldown)
        {
            movementSpeed = walkForwardSpeed;
        }
    }

    private IEnumerator SpeedCooldown()
    {
        yield return new WaitForSeconds(smoothInputSpeed);
        speedCooldown = false;
    }

    //Read movement inputs from PlayerInputs input action
    public void MoveInput(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }
}
