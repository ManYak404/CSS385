using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < mainCamera.transform.position.x - 20f)
        {
            Destroy(gameObject); // Destroy the pipe if it goes out of the camera view
        }
    }
}
