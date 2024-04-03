using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public Transform cameraTransform; // Reference to the camera's transform
    public Vector3 firstPersonOffset; // Offset for first-person view
    public Vector3 thirdPersonOffset; // Offset for third-person view

    private Rigidbody rb; // Reference to the player's Rigidbody component
    private bool isFirstPerson = true; // Flag to track camera view

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the player's Rigidbody component
    }

    void FixedUpdate()
    {
        // Find the main camera's transform if it hasn't been assigned yet
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
            if (cameraTransform == null)
            {
                Debug.LogError("Main camera not found.");
                return;
            }
        }

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(movement));

        // Toggle camera view when the specified input is detected (e.g., press "C" key)
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson; // Toggle between first-person and third-person view
        }

        // Calculate target position based on the selected camera view
        Vector3 targetPosition = isFirstPerson ? transform.position + firstPersonOffset : transform.position + thirdPersonOffset;

        // Set the camera position directly to the target position
        cameraTransform.position = targetPosition;

        // Ensure the player's rotation matches the camera's rotation to prevent falling over
        transform.rotation = Quaternion.Euler(0f, cameraTransform.rotation.eulerAngles.y, 0f);
    }
}
