using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject pipePrefab;
    int height = 30;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pipePrefab, new Vector3(15, 10, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
