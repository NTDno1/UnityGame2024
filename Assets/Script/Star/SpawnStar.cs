using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab của object muốn spawn
    public float minY = -4f; // Giá trị Y nhỏ nhất
    public float maxY = 4f; // Giá trị Y lớn nhất

    public float spawnInterval = 50f;  // Thời gian giữa các lần spawn

    public float numberStar = 0;

    private float timer = 0f;
    void Start()
    {
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {

            SpawnObjectFromRight();
            timer = 0f;
        }
    }

    public float getNumberStar() { { return numberStar; } }
    public void UpdateNumberStar(int number)
    {
        numberStar += number;
    }
    void SpawnObjectFromRight()
    {
        // Lấy tọa độ cạnh bên phải của màn hình
        Vector2 screenRight = new Vector2(Screen.width, Screen.height);
        Vector2 worldRight = Camera.main.ScreenToWorldPoint(screenRight);

        // Tạo tọa độ Y ngẫu nhiên trong khoảng từ minY đến maxY
        float randomY = Random.Range(minY, maxY);

        // Tạo một vị trí mới với tọa độ X tại cạnh bên phải và Y ngẫu nhiên
        Vector2 spawnPosition = new Vector2(worldRight.x, randomY);

        // Spawn object tại vị trí đã tính toán
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
