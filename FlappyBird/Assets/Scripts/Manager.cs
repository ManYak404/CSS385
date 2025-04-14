using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;  // Required for UI Toolkit

public class Manager : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject bird;
    private Camera mainCamera; // Reference to the main camera
    public GameObject background1; // Reference to the background1
    public GameObject background2; // Reference to the background1
    private bool isBackground1 = true; // Flag to track which background is currently active
    private float background1Position = 0; // Width of the background
    private float background2Position = 48; // Width of the background
    private float backgroundWidth = 24; // Width of the background
    float height = 10;
    float spawnInterval = 3.5f; // Interval in seconds
    float timeSinceLastSpawn = 0f; // Timer to track time since last spawn
    public static int score = 0; // Score variable
    Queue<float> upcomingPipeX = new Queue<float>(); // Stack to keep track of upcoming pipes
    public UIDocument uiDoc; // Reference to the UI document
    string statsText; // Text to display in the UI
    Label myLabel; // Label to display the stats text

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        myLabel = new Label(""); // Create a new label with the text to display
    }

    // Update is called once per frame
    void Update()
    {
        statsText = "Score: " + score; // display the score
        myLabel.text = statsText; // Update the label text with the current stats
        uiDoc.rootVisualElement.Add(myLabel); // Add the label to the UI document
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
        spawnBackground(); // Spawn the background
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

    void spawnBackground(){
        if(bird.transform.position.x >= background1Position && isBackground1)
        {
            background2Position = background1Position + backgroundWidth*2; // Move background2 to the right
            isBackground1 = false; // Set the flag to false
        }
        if(bird.transform.position.x >= background2Position && !isBackground1)
        {
            background1Position = background2Position + backgroundWidth*2; // Move background1 to the right
            isBackground1 = true; // Set the flag to true
        }
        background1.transform.position = new Vector3(background1Position, 0, 0); // Set the position of background1
        background2.transform.position = new Vector3(background2Position, 0, 0); // Set the position of background2
    }
}
