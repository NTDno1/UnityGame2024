using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
     private Camera mainCamera;    // Camera chính
    private float screenBottom;   // Tọa độ y của đáy màn hình
     private float timer = 0f;

    void Start (){
          mainCamera = Camera.main;

        // Lấy tọa độ y của cạnh dưới màn hình (bottom) trong hệ tọa độ thế giới (world coordinates)
        screenBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        // Di chuyển vật thể sang phải theo tốc độ đã định
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        // Kiểm tra nếu đã vượt quá 5 giây
        if (timer >= 3f)
        {
            Destroy(gameObject); // Hủy object
        }
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rock")
        {
            Destroy(gameObject);
        }

    }
}
