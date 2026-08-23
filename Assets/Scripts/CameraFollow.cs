using UnityEngine;                  // Gives us Unity classes like Transform, Rigidbody, Vector3, Quaternion.

public class CameraFollow : MonoBehaviour
{
    // ================= CAMERA TARGET =================

    [SerializeField] private Transform target;
    // The object the camera follows, normally your sphere/player.


    // ================= CAMERA DATA =================

    private Rigidbody targetRb;
    // Stores the player's Rigidbody so we can follow its physics position.

    private Vector3 offset;
    // Stores the original distance between the camera and the player.

    private Quaternion fixedRotation;
    // Stores the camera's original rotation so it never rotates with the sphere.


    void Awake()
    {
        // Check whether a target was assigned in the Inspector.
        if (target == null)
        {
            // Show an error if no target was assigned.
            Debug.LogError("CameraFollow: Target is not assigned!");

            // Stop this script from running.
            enabled = false;

            // Exit Awake immediately.
            return;
        }


        // Get the Rigidbody from the target/player.
        targetRb = target.GetComponent<Rigidbody>();


        // Check whether the target actually has a Rigidbody.
        if (targetRb == null)
        {
            // Show an error if there is no Rigidbody.
            Debug.LogError("CameraFollow: Target needs a Rigidbody!");

            // Stop this script from running.
            enabled = false;

            // Exit Awake immediately.
            return;
        }


        // Remember the camera's original position relative to the player.
        offset = transform.position - target.position;


        // Remember the camera's original rotation.
        fixedRotation = transform.rotation;


        // Smooth the Rigidbody's movement for the camera.
        targetRb.interpolation = RigidbodyInterpolation.Interpolate;
    }


    void LateUpdate()
    {
        // Move the camera with the player's position plus the original offset.
        transform.position = targetRb.position + offset;


        // Keep the camera's original rotation.
        // Therefore, the sphere can rotate without rotating the camera.
        transform.rotation = fixedRotation;
    }
}