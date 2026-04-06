using UnityEngine;
using UnityEngine.InputSystem;

public class IndependentCamera : MonoBehaviour
{
    [Header("Follow Target")]
    [SerializeField] private Transform playerTransform; // Drag your player here

    [Header("Input Actions")]
    [SerializeField] private InputActionReference lookAction;

    [Header("Settings")]
    public float sensitivity = 0.1f;
    public float minY = -30f;
    public float maxY = 60f;
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Position the pivot at player's head/chest

    private float pitch, yaw;

    void OnEnable() => lookAction.action.Enable();
    void OnDisable() => lookAction.action.Disable();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        if (playerTransform == null) return;

        // 1. Follow the player's position (plus an offset)
        // This keeps the pivot centered on the player without inheriting their rotation
        transform.position = playerTransform.position + offset;

        // 2. Handle Independent Rotation
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();
        yaw += lookInput.x * sensitivity;
        pitch -= lookInput.y * sensitivity;
        pitch = Mathf.Clamp(pitch, minY, maxY);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // This will print numbers in your Console if the mouse is working
        if (lookInput != Vector2.zero)
            Debug.Log("Mouse Delta: " + lookInput);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
