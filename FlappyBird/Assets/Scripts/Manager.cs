using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject bird;
    float height = 10;
    float spawnInterval = 3.5f; // Interval in seconds
    float timeSinceLastSpawn = 0f; // Timer to track time since last spawn
    public static int score = 0; // Score variable
    Queue<float> upcomingPipeX = new Queue<float>(); // Stack to keep track of upcoming pipes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bird.transform.position.y > height-0.5f)
        {
            bird.transform.position = new Vector3(bird.transform.position.x, height-0.5f, bird.transform.position.z);
            bird.GetComponent<FlappyBird>().verticalSpeed = 0f; // Stop the bird from going higher than the height
        }

        if(bird.transform.position.y < -height+0.5f)
        {
            bird.transform.position = new Vector3(bird.transform.position.x, -height+0.5f, bird.transform.position.z);
            bird.GetComponent<FlappyBird>().verticalSpeed = 0f; // Stop the bird from going lower than the height
        }

        // Increment the timer
        timeSinceLastSpawn += Time.deltaTime;

        if(upcomingPipeX.Count != 0)
        {
            // Check if the bird has passed the next pipe
            if (bird.transform.position.x >= upcomingPipeX.Peek())
            {
                score++;
                Debug.Log("Score: " + score);
                upcomingPipeX.Dequeue(); // Remove the passed pipe from the stack
            }
        }
        // Spawn a pipe if the interval has passed
        if (timeSinceLastSpawn >= spawnInterval)
        {
            upcomingPipeX.Enqueue(SpawnPipe()); // Get the X position of the next pipe
            timeSinceLastSpawn = 0f; // Reset the timer
        }

    }

    float SpawnPipe()
    {
        float randomGapWidth = Random.Range(2, 4f);
        float randomY = Random.Range(-height+randomGapWidth, height-randomGapWidth);
        float topPipeHeight = height-(randomY+randomGapWidth);
        float bottomPipeHeight = Mathf.Abs(randomY-randomGapWidth+height);
        GameObject topPipe = Instantiate(pipePrefab, new Vector3(bird.transform.position.x + 20, height-(topPipeHeight/2), 0), Quaternion.identity);
        GameObject bottomPipe = Instantiate(pipePrefab, new Vector3(bird.transform.position.x + 20, -height+(bottomPipeHeight/2), 0), Quaternion.identity);
        topPipe.transform.localScale = new Vector3(3, topPipeHeight, 1);
        bottomPipe.transform.localScale = new Vector3(3, bottomPipeHeight, 1);
        Debug.Log("Spawned pipe at: " + bird.transform.position.x + 20 + ", " + randomY);
        return topPipe.transform.position.x;
    }
}
