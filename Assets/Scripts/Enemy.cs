using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            print("El enemigo ha muerto");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            print("TOQUE AL JUGADOR AAAAAAAAAAAAAAAAA");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
