using UnityEngine;

public class VRControllerMovement : MonoBehaviour
{
    public Transform headset; // Reference to the VR headset
    public float movementSpeed = 1.0f; // Adjust movement speed as needed

    private Vector3 initialControllerPosition;

    void Start()
    {
        initialControllerPosition = transform.position;
    }

    void Update()
    {
        // Get input from the left joystick
        float horizontalInput = Input.GetAxis("LeftJoystickHorizontal");
        float verticalInput = Input.GetAxis("LeftJoystickVertical");

        // Create a direction vector from joystick input
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Transform the direction vector based on the headset's forward direction
        Vector3 headsetForward = headset.forward;
        headsetForward.y = 0; // Ignore vertical component
        Quaternion rotationToHeadset = Quaternion.LookRotation(headsetForward);
        moveDirection = rotationToHeadset * moveDirection;

        // Apply the movement direction to the hand controller
        transform.position += movementSpeed * Time.deltaTime * moveDirection;
    }
}
