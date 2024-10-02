using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
 public float minSpeed = 2f;   // Tốc độ tối thiểu
    public float maxSpeed = 5f;   // Tốc độ tối đa
    private float fallSpeed;      // Tốc độ rơi ngẫu nhiên

    private Camera mainCamera;    // Camera chính
    private float screenBottom;   // Tọa độ y của đáy màn hình

    void Start()
    {
        // Khởi tạo tốc độ rơi ngẫu nhiên giữa minSpeed và maxSpeed
        fallSpeed = Random.Range(minSpeed, maxSpeed);
        
        // Lấy camera chính
        mainCamera = Camera.main;

        // Lấy tọa độ y của cạnh dưới màn hình (bottom) trong hệ tọa độ thế giới (world coordinates)
        screenBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(-1, -1).normalized;  

        transform.Translate(moveDirection * fallSpeed * Time.deltaTime);

        if (transform.position.y < screenBottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }
}
