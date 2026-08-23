using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   
    public AudioSource touchsound;
    public float keyinput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       touchsound = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame  
    void Update()
    {
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Canday"))
        touchsound.Play();
    }
}
