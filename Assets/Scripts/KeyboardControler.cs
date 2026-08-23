using UnityEngine;                  // Gives us Unity classes like MonoBehaviour, Rigidbody, Vector3.
using UnityEngine.InputSystem;      // Gives us the New Input System classes like InputAction.

public class KeyboardControler : MonoBehaviour
{
    // ================= PLAYER SPEED SETTINGS =================

    public float moveSpeed = 1f;    // Controls how fast the player moves.
    public float jumpForce = 2f;    // Controls how strong the jump is.

    // ================= INPUT VALUES =================

    public float keyinput1;         // Stores A/D input: -1 = left, 0 = nothing, +1 = right.
    public float keyinput2;         // Stores S/W input: -1 = backward, 0 = nothing, +1 = forward.

    // ================= COMPONENTS =================

    private Rigidbody rb;           // Stores the player's Rigidbody so we can control its physics.

    // ================= INPUT ACTIONS =================

    private InputAction move1;      // Input Action for A/D movement.
    private InputAction move2;      // Input Action for S/W movement.
    private InputAction jump;       // Input Action for Space jump.


    void Start()
    {
        // Get the Rigidbody attached to the same GameObject as this script.
        rb = GetComponent<Rigidbody>();


        // ================= A / D MOVEMENT =================

        // Create a 1D input action for horizontal movement.
        move1 = new InputAction("Move1", InputActionType.Value);

        // Create a 1D axis: A = -1 and D = +1.
        move1.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/d");

        // Turn the input action on so it can receive keyboard input.
        move1.Enable();


        // ================= S / W MOVEMENT =================

        // Create another 1D input action for forward/backward movement.
        move2 = new InputAction("Move2", InputActionType.Value);

        // Create a 1D axis: S = -1 and W = +1.
        move2.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/s")
            .With("Positive", "<Keyboard>/w");

        // Turn the input action on.
        move2.Enable();


        // ================= JUMP =================

        // Create a button input action for jumping.
        jump = new InputAction("Jump", InputActionType.Button);

        // Connect the Space key to the jump action.
        jump.AddBinding("<Keyboard>/space");

        // Turn the jump action on.
        jump.Enable();
    }


    void Update()
    {
        // Read the current A/D value and store it in keyinput1.
        keyinput1 = move1.ReadValue<float>();

        // Read the current S/W value and store it in keyinput2.
        keyinput2 = move2.ReadValue<float>();


        // Check if Space was pressed during this frame.
        if (jump.WasPressedThisFrame())
        {
            // Push the player upward using an instant physics impulse.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    void FixedUpdate()
    {
        // Calculate X and Z movement using the input values multiplied by our speed.
        float xMovement = keyinput1 * moveSpeed;
        // float xMovement = keyinput1 * UnityEngine.Random.Range(1f, 3f);// Controls how fast the player moves left/right/forward/backward.
        float zMovement = keyinput2 * moveSpeed;

        // Set the player's velocity:
        // X = A/D movement.
        // Y = keep the existing physics/gravity velocity.
        // Z = W/S movement.
        rb.linearVelocity = new Vector3(
            xMovement,
            rb.linearVelocity.y,
            zMovement
        );
    }


    void OnDisable()
    {
        // Turn off the A/D input action.
        move1.Disable();

        // Turn off the S/W input action.
        move2.Disable();

        // Turn off the jump input action.
        jump.Disable();
    }
}