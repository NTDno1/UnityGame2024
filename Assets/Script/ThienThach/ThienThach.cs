using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThienThach : MonoBehaviour
{
    public GameObject objectToSpawn;  // Vật thể cần spawn
    public float spawnInterval = 1f;  // Thời gian giữa các lần spawn

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // Spawn một object mới
            SpawnObject();
            timer = 0f;  // Reset timer
        }
    }

    void SpawnObject()
    {
        // Lấy tọa độ góc trên bên trái màn hình
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        
        // Lấy tọa độ góc trên bên phải màn hình
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
        // Tạo một vị trí ngẫu nhiên giữa góc trên bên trái và góc trên bên phải
        float randomX = Random.Range(topLeft.x, topRight.x);
        Vector3 spawnPosition = new Vector3(randomX, topLeft.y, 0);  // Z = 0 vì là game 2D

        // Spawn object tại vị trí ngẫu nhiên
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
