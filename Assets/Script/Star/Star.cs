using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    SpawnStar  spawnStar;
    public float moveSpeed = 5f;
    public float timeDestroy = 5f;
    [SerializeField] GameObject gameobject;

    private float timer = 0f;
    void Start()
    {
       spawnStar = gameobject.GetComponent<SpawnStar>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= timeDestroy)
        {
            if(spawnStar.getNumberStar() == 1){
                spawnStar.UpdateNumberStar(-1);
                Destroy(gameObject);
                timer = 0f; 
            }
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
