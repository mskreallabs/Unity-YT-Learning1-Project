using UnityEngine;                  // Gives us Unity classes like MonoBehaviour, Rigidbody, Vector3.
using UnityEngine.SceneManagement;        // Gives us the SceneManager class so we can load scenes.
public class Platform : MonoBehaviour
{
    // ================= PLATFORM SETTINGS =================
    public int CurrentSceneIndex; // The index of the scene to load when the player collides with this platform.
    public int NextSceneIndex; // The index of the next scene to load when the player collides with this platform.
    public float speed = 1f;        // Controls how fast the platform moves.

    public Vector3 direction = Vector3.left;
    // Stores the platform's movement direction.
    // Vector3.left  = (-1, 0, 0) → moves left.
    // Vector3.right = (1, 0, 0)  → moves right.


    void Start()
    {
        // Get the Rigidbody attached to this platform.
        Rigidbody rb = GetComponent<Rigidbody>();

        // Give the platform a starting velocity.
        // direction decides WHERE it moves.
        // speed decides HOW FAST it moves.
        rb.linearVelocity = direction * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Canday"))
        {
            SceneManager.LoadScene(NextSceneIndex);
        }
                if (collision.gameObject.CompareTag("Colid"))
        {
            SceneManager.LoadScene(NextSceneIndex);
        }
    }
}