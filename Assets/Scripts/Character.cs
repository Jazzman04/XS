using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 1.5f;
    public float gravity = -19.62f;

    private CharacterController controller;
    private Vector3 velocity; // For gravity/jumping
    private bool isGrounded;
    private Vector3 movement;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    void Update()
    {
        HandleMovement();
        HandleGravityAndJump();

        Vector3 finalMove = movement + (Vector3.up * velocity.y);
        controller.Move(finalMove * Time.deltaTime);
    }

    private void HandleMovement()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 camForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;

        // Save the horizontal direction to the class variable
        movement = (camForward * input.y + camRight * input.x) * moveSpeed;

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleGravityAndJump()
    {
         bool isGrounded = controller.isGrounded;

         if (isGrounded && velocity.y < 0)
         {
            velocity.y = -2f; 
         }

         if (jumpAction.action.WasPressedThisFrame() && isGrounded)
         {
                 velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
         }
                velocity.y += gravity * Time.deltaTime;
    }
}
