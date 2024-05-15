using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Meleeenemyguard : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] Transform Target;
    [SerializeField] int hp;
    [SerializeField] float speed;

    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) <= sightRange)
        {
            transform.up =(Target.position - transform.position).normalized;
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        if (canMove) 
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("El enemigo ha muerto");
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy (gameObject);
        }
    }

}
