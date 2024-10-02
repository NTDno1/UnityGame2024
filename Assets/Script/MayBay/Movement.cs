using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public int diem = 10;
    void Start()
    {

    }

    public float moveSpeed = 5f;  // Speed at which the object moves
    public GameObject itemPrefab;  // Prefab của item muốn spawn

    void SpawnItemAtCurrentPosition()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, -90);
        Instantiate(itemPrefab, transform.position, rotation);
    }

    void Update()
    {
        // Get the vertical input (Up/Down keys)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 movement = new Vector3(0, verticalInput, 0);

        // Move the object
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            // Spawn item tại vị trí của object hiện tại
            SpawnItemAtCurrentPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rock")
        {
            diem -= 5;
        }
        if (other.tag == "star")
        {
            diem += 10;
        }
        if (diem <= 0)
        {
            SceneManager.LoadScene("EndGame");
            Time.timeScale = 0;
        }
    }
}
