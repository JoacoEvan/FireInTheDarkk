using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] float sightRange = 4;
    [SerializeField] int hp;
    [SerializeField] GameObject Player;
    [SerializeField] int asadasd;
    float distance;
    //AIPath aipath;

    // Start is called before the first frame update
    void Awake()
    {
        //aipath = Enemy.GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        if(distance < sightRange)
        {
            //aipath.canMove = true;
        }
        else
        {
            //aipath.canMove = false;
        }
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
